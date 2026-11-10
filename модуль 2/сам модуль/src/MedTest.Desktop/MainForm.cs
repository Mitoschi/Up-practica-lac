using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>
/// Рабочее место: вкладки «Пациенты» (список и карточка справа) и «Сотрудники» (для администратора).
/// Все таблицы, кнопки и фильтры размещены в конструкторе форм; код только заполняет их данными.
/// </summary>
public partial class MainForm : Form
{
    public const string Patients = "Пациенты", Staff = "Сотрудники";

    private readonly AppSession? session;
    private string section = Patients, chip = "all";
    private List<PatientRow> patients = [];
    private List<Indicator> indicators = [];
    private List<SamplePoint> points = [];
    private List<AppUser> users = [];
    private Dictionary<int, IndicatorStats> stats = [];
    private bool busy, initialized, rendering;
    private int? shownPatient;

    /// <summary>True after the current section has loaded and no load is running.</summary>
    public bool DataReady { get; private set; }
    public string Section => section;
    public IReadOnlyDictionary<int, IndicatorStats> CurrentStats => stats;

    /// <summary>The table of the current section (each section has its own table in the Designer).</summary>
    public DataGridView CurrentGrid => section switch
    {
        Staff => staffGrid,
        _ => patientsGrid
    };

    public MainForm()
    {
        InitializeComponent(); Theme.Apply(this);
        patientCard.Message += ShowMessage;
    }

    public MainForm(AppSession session) : this()
    {
        this.session = session;
        var user = session.Actor;
        userLabel.Text = user.FullName; roleLabel.Text = user.RoleTitle; avatarLabel.Text = Theme.Initials(user.FullName);
        navStaff.Visible = session.IsAdmin;
        ApplyNavigation();
        initialized = true;
    }

    private async void MainShown(object? sender, EventArgs e) { if (session != null) await RefreshAsync(); }

    private async void NavigationClick(object? sender, EventArgs e)
    {
        if (!initialized || busy || sender is not Button { Tag: string target }) return;
        section = target;
        chip = "all";
        searchBox.Clear(); ApplyNavigation();
        await RefreshAsync();
    }

    private void ApplyNavigation()
    {
        foreach (var b in navigationPanel.Controls.OfType<Button>()) Theme.Navigation(b, b.Tag?.ToString() == section);
    }

    public async Task RefreshAsync()
    {
        if (session == null || busy || IsDisposed) return;
        busy = true; DataReady = false; SetEnabled(false); UseWaitCursor = true;
        bool loaded = false;
        try
        {
            string? error;
            (indicators, error) = await LoadList(() => session.Db.ListIndicatorsAsync(session.Actor));
            if (error == null) (points, error) = await LoadList(() => session.Db.SamplePointsAsync(session.Actor));
            if (error == null && section == Patients) (patients, error) = await LoadList(() => session.Db.ListPatientsAsync(session.Actor));
            if (error == null && section == Staff) (users, error) = await LoadList(() => session.Db.ListUsersAsync(session.Actor));
            if (IsDisposed) return;
            ComputeStats();
            Configure();
            RenderRows();
            if (error != null) ShowMessage(error, true);
            loaded = error == null;
        }
        finally
        {
            if (!IsDisposed) { busy = false; SetEnabled(true); UseWaitCursor = false; DataReady = loaded; }
        }
        if (loaded) await ShowSelectionAsync(force: true);
    }

    private static async Task<(List<T>, string?)> LoadList<T>(Func<Task<List<T>>> call)
    {
        var (list, error) = await AppSession.Try(call);
        return (list ?? [], error);
    }

    /// <summary>Statistics of every indicator over the chosen sample (the card compares a patient with the group).</summary>
    private void ComputeStats() =>
        stats = indicators.ToDictionary(i => i.Id, i => Statistics.Compute(Statistics.Sample(points, i.Id, SampleMode.LatestPerPatient), i));

    private void SetEnabled(bool enabled) { navigationPanel.Enabled = enabled; actionBar.Enabled = enabled; filterChips.Enabled = enabled; gridFrame.Enabled = enabled; }

    private void Configure()
    {
        bool admin = session?.IsAdmin == true;
        headingLabel.Text = section;
        searchBox.PlaceholderText = section == Patients ? "ФИО, номер карты или телефон" : section == Staff ? "Логин или ФИО" : "Название, код или группа";
        openButton.Visible = section == Patients || (admin && section != Patients);
        openButton.Text = section == Patients ? "Открыть карту" : "Изменить";
        addButton.Visible = section == Patients || (admin && section != Patients);
        addButton.Text = section == Patients ? "Добавить пациента" : section == Staff ? "Добавить сотрудника" : "Добавить показатель";
        foreach (var c in new[] { chipAll, chipDeviation, chipNoExam, chipArchive }) c.Visible = section == Patients;
        chipsRow.Visible = section == Patients;
        foreach (var grid in gridFrame.Controls.OfType<DataGridView>()) grid.Visible = grid == CurrentGrid;
        bodyLayout.ColumnStyles[1].Width = section == Patients ? 680 : 0;
        dossierPanel.Visible = section == Patients;
        patientCard.Visible = section == Patients;
        UpdateChips();
    }

    private void UpdateChips()
    {
        chipAll.Count = patients.Count(r => !r.Patient.IsArchived);
        chipDeviation.Count = patients.Count(r => !r.Patient.IsArchived && r.Deviations > 0);
        chipNoExam.Count = patients.Count(r => !r.Patient.IsArchived && r.ExamCount == 0);
        chipArchive.Count = patients.Count(r => r.Patient.IsArchived);
        foreach (var c in filterChips.Controls.OfType<FilterChip>()) c.Active = c.Tag?.ToString() == chip;
    }

    private async void ChipClick(object? sender, EventArgs e)
    {
        if (busy || sender is not FilterChip { Tag: string key }) return;
        chip = key;
        UpdateChips(); RenderRows();
        await ShowSelectionAsync(force: section != Patients);
    }

    /// <summary>The card follows the filtered list: after a search it shows the patient that is now selected.</summary>
    private async void SearchChanged(object? sender, EventArgs e)
    {
        if (!initialized || busy) return;
        RenderRows();
        await ShowSelectionAsync(force: false);
    }

    private bool Matches(params string?[] fields)
    {
        var q = searchBox.Text.Trim();
        if (q.Length == 0) return true;
        var digits = new string(q.Where(char.IsDigit).ToArray());
        return fields.Any(f => f != null && (f.Contains(q, StringComparison.CurrentCultureIgnoreCase)
            || (digits.Length >= 3 && new string(f.Where(char.IsDigit).ToArray()).Contains(digits))));
    }

    /// <summary>Fills the table of the current section, keeping the selected record.</summary>
    private void RenderRows()
    {
        var grid = CurrentGrid;
        var keep = grid.CurrentRow?.Tag;
        rendering = true;
        try
        {
            grid.Rows.Clear();
            var today = DateOnly.FromDateTime(session?.Db.Now() ?? DateTime.Now);
            recordCountLabel.Text = "";
            if (section == Patients)
                foreach (var r in patients.Where(PatientFilter).Where(r => Matches(r.Patient.FullName, r.Patient.CardNumber, r.Patient.Phone)))
                    Add(grid, r, r.Patient.CardNumber, r.Patient.FullName, r.Patient.AgeOn(today), r.Patient.Sex == Sex.Male ? "М" : "Ж", r.LastExamAt is { } at ? Texts.Date(at) : "—", "");
            if (section == Staff)
                foreach (var u in users.Where(u => Matches(u.Login, u.FullName)))
                    Add(grid, u, u.Login, u.FullName, u.RoleTitle, u.IsActive ? "активен" : "заблокирован");
                recordCountLabel.Text = (recordCountLabel.Text.Length > 0 ? recordCountLabel.Text + " · " : "") + "записей: " + grid.Rows.Count;
            // Restore the selection, or select the patient that was just added.
            foreach (DataGridViewRow row in grid.Rows)
            {
                bool added = pendingSelect != null && row.Tag is PatientRow pr && pr.Patient.Id == pendingSelect;
                if (added || (pendingSelect == null && SameRecord(row.Tag, keep))) { grid.CurrentCell = row.Cells[0]; break; }
            }
            pendingSelect = null;
        }
        finally { rendering = false; }
    }

    private static void Add(DataGridView grid, object tag, params object[] cells) { int r = grid.Rows.Add(cells); grid.Rows[r].Tag = tag; }

    private static bool SameRecord(object? a, object? b) => (a, b) switch
    {
        (PatientRow x, PatientRow y) => x.Patient.Id == y.Patient.Id,
        (Indicator x, Indicator y) => x.Id == y.Id,
        (AppUser x, AppUser y) => x.Id == y.Id,
        _ => false
    };

    private bool PatientFilter(PatientRow r) => chip switch
    {
        "archive" => r.Patient.IsArchived,
        "deviation" => !r.Patient.IsArchived && r.Deviations > 0,
        "noexam" => !r.Patient.IsArchived && r.ExamCount == 0,
        _ => !r.Patient.IsArchived
    };

    /// <summary>Initials square before the name, a coloured tag for the state, the card number in a quiet font.</summary>
    private void PatientsCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || patientsGrid.Rows[e.RowIndex].Tag is not PatientRow r) return;
        int band = patientsGrid.RowTemplate.Height;
        if (e.ColumnIndex == personColumn.Index) GridPaint.Person(e, r.Patient.FullName, Theme.PersonColor(r.Patient.Id), Theme.CellFont, band);
        else if (e.ColumnIndex == stateColumn.Index) GridPaint.Tag(e, r.Patient.IsArchived ? Theme.Neutral("В архиве") : Theme.Deviations(r.Deviations, r.ExamCount), band);
        else if (e.ColumnIndex == cardColumn.Index) GridPaint.Text(e, r.Patient.CardNumber, Theme.CodeFont, Theme.Muted, band);
    }

    private async void RecordsSelectionChanged(object? sender, EventArgs e) { if (!rendering && !busy && sender == CurrentGrid) await ShowSelectionAsync(force: false); }

    /// <summary>The right panel follows the selected row: the patient card or the distribution of an indicator.</summary>
    private async Task ShowSelectionAsync(bool force)
    {
        if (session == null) return;
        var tag = CurrentGrid.CurrentRow?.Tag;
        if (section == Patients)
        {
            int? id = (tag as PatientRow)?.Patient.Id;
            if (!force && id == shownPatient) return;
            shownPatient = id;
            await patientCard.LoadAsync(session, id, indicators, stats);
        }
    }

    private async void CardChanged(object? sender, EventArgs e) => await RefreshAsync();

    private async void RefreshClick(object? sender, EventArgs e) => await RefreshAsync();

    private async void AddClick(object? sender, EventArgs e)
    {
        if (session == null || busy) return;
        bool saved = false;
        if (section == Patients && PatientForm.Edit(this, session, null) is { } p) saved = Select(p.Id);
        if (section == Staff) saved = StaffForm.Edit(this, session, null);
        if (saved) { ShowMessage("Сохранено.", false); await RefreshAsync(); }
    }

    /// <summary>Remembers a patient to select after the next refresh.</summary>
    private bool Select(int patientId)
    {
        chip = "all";
        searchBox.Clear();
        pendingSelect = patientId;
        return true;
    }
    private int? pendingSelect;

    private async void OpenClick(object? sender, EventArgs e)
    {
        if (session == null || busy) return;
        switch (CurrentGrid.CurrentRow?.Tag)
        {
            case PatientRow r:
                using (var window = new PatientWindow(session, r.Patient.Id, indicators, stats))
                {
                    window.ShowDialog(this);
                    if (window.ChangedData) await RefreshAsync();
                }
                break;
            case AppUser u when session.IsAdmin:
                if (StaffForm.Edit(this, session, u)) { ShowMessage("Сотрудник сохранён.", false); await RefreshAsync(); }
                break;
        }
    }

    private void GridDoubleClick(object? sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0 && openButton.Visible) openButton.PerformClick(); }

    private void LogoutClick(object? sender, EventArgs e) { if (!busy) Close(); }

    private void MainKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5) { refreshButton.PerformClick(); e.Handled = true; }
        if (e.Control && e.KeyCode == Keys.F) { searchBox.Focus(); e.Handled = true; }
        if (e.Control && e.KeyCode == Keys.N && addButton.Visible) { addButton.PerformClick(); e.Handled = true; }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter && CurrentGrid.ContainsFocus && openButton.Visible) { openButton.PerformClick(); return true; }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ShowMessage(string text, bool error) { messageLabel.ForeColor = error ? Theme.Rust : Theme.Muted; messageLabel.Text = text; }
}
