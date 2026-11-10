using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>
/// Добавление и изменение пациента в справочнике. Все поля размещены в конструкторе форм:
/// ФИО, дата рождения (выбор из календаря), пол (список), телефон и примечание.
/// </summary>
public partial class PatientForm : Form
{
    private readonly AppSession? session;
    private readonly Patient? patient;
    private bool saving;

    public PatientForm()
    {
        InitializeComponent(); Theme.Apply(this);
        birthDatePicker.MaxDate = DateTime.Today;
        sexBox.SelectedIndex = 0;
    }

    /// <summary>New patient (patient = null) or change of an existing one.</summary>
    public PatientForm(AppSession session, Patient? patient) : this()
    {
        this.session = session; this.patient = patient;
        birthDatePicker.MaxDate = session.Db.Now().Date;
        if (patient == null) return;
        titleLabel.Text = "Пациент " + patient.CardNumber;
        lastNameBox.Text = patient.LastName; firstNameBox.Text = patient.FirstName; middleNameBox.Text = patient.MiddleName ?? "";
        birthDatePicker.Value = patient.BirthDate.ToDateTime(TimeOnly.MinValue);
        sexBox.SelectedIndex = patient.Sex == Sex.Male ? 1 : 0;
        phoneBox.Text = patient.Phone ?? ""; noteBox.Text = patient.Note ?? "";
    }

    /// <summary>The patient as stored, after a successful save.</summary>
    public Patient? Saved { get; private set; }

    /// <summary>Opens the form; returns the saved patient or null when cancelled.</summary>
    public static Patient? Edit(IWin32Window? owner, AppSession session, Patient? patient)
    {
        using var form = new PatientForm(session, patient);
        return form.ShowDialog(owner) == DialogResult.OK ? form.Saved : null;
    }

    private async void SaveClick(object? sender, EventArgs e)
    {
        if (saving || session == null) return;
        if (lastNameBox.Text.Trim().Length == 0) { Error("Заполните поле «Фамилия».", lastNameBox); return; }
        if (firstNameBox.Text.Trim().Length == 0) { Error("Заполните поле «Имя».", firstNameBox); return; }
        var input = new PatientInput(lastNameBox.Text.Trim(), firstNameBox.Text.Trim(), middleNameBox.Text.Trim(), DateOnly.FromDateTime(birthDatePicker.Value),
            sexBox.SelectedIndex == 1 ? Sex.Male : Sex.Female, phoneBox.Text.Trim(), noteBox.Text.Trim());
        saving = true; saveButton.Enabled = false; errorLabel.ForeColor = Theme.Muted; errorLabel.Text = "Сохранение…";
        var (result, error) = patient == null
            ? await AppSession.Try(() => session.Db.CreatePatientAsync(session.Actor, input))
            : await AppSession.Try(() => session.Db.UpdatePatientAsync(session.Actor, patient.Id, input));
        saving = false;
        if (IsDisposed) return;
        saveButton.Enabled = true;
        if (error != null) { Error(error, null); return; }
        Saved = result;
        DialogResult = DialogResult.OK; Close();
    }

    /// <summary>The message about a field disappears as soon as the user starts correcting it.</summary>
    private void FieldChanged(object? sender, EventArgs e) { if (!saving && errorLabel.ForeColor == Theme.Rust) errorLabel.Text = ""; }

    private void Error(string text, Control? field)
    {
        errorLabel.ForeColor = Theme.Rust; errorLabel.Text = text;
        field?.Focus();
    }
}
