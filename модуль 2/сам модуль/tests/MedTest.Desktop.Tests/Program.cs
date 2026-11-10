using System.Drawing.Imaging;
using Microsoft.Data.SqlClient;
using MedTest.Core;
using MedTest.Data;
using MedTest.Desktop;

namespace MedTest.Desktop.Tests;

/// <summary>
/// Проверка интерфейса на настоящей базе: окна открываются, кнопки нажимаются, данные сохраняются.
/// Создаёт тестовую базу MedTest_Test_App_*, заполняет её примерами, проходит сценарии врача и администратора,
/// сохраняет снимки окон и удаляет базу. Сервер: MEDTEST_TEST_SERVER (строка подключения без базы), иначе LocalDB.
/// </summary>
internal static class Program
{
    const string Password = "Проверка-2026!";
    static string shots = "";
    static int passed, failed;
    static readonly List<string> failures = [];

    [STAThread]
    static int Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Async handlers continue on this thread, as under Application.Run in the real program.
        WindowsFormsSynchronizationContext.AutoInstall = false;
        SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
        shots = Environment.GetEnvironmentVariable("MEDTEST_SHOTS") ?? Path.Combine(AppContext.BaseDirectory, "screens");
        Directory.CreateDirectory(shots);
        var server = Environment.GetEnvironmentVariable("MEDTEST_TEST_SERVER");
        var database = "MedTest_Test_App_" + Guid.NewGuid().ToString("N");
        var b = string.IsNullOrWhiteSpace(server)
            ? new SqlConnectionStringBuilder(DatabaseSetup.ConnectionString(DatabaseSetup.DefaultServer, database))
            : new SqlConnectionStringBuilder(server) { InitialCatalog = database };
        b.TrustServerCertificate = true;
        var cs = b.ConnectionString;
        Console.WriteLine("TEST DATABASE " + database);
        try
        {
            Wait(DatabaseSetup.EnsureAsync(cs));
            Wait(DatabaseSetup.CreateFirstUserAsync(cs, Role.Admin, "ui_admin", "Соколова Ирина Павловна", Password));
            Wait(DatabaseSetup.CreateFirstUserAsync(cs, Role.Doctor, "ui_doctor", "Лебедев Андрей Викторович", Password));
            var db = new MedDatabase(cs);
            var admin = Wait(db.LoginAsync("ui_admin", Password, Role.Admin));
            Wait(db.SaveUserAsync(admin, null, new UserInput("ui_doctor2", "Морозова Елена Игоревна", Role.Doctor, true, Password)));
            Wait(SampleData.FillAsync(cs, "ui_doctor2"));

            Run("Вход: неверный пароль и режим", () => LoginChecks(db));
            Run("Справочник пациентов: поиск, фильтры, добавление", () => PatientDirectory(db));
            Run("Карточка пациента: изменение данных и архив", () => PatientChanges(db));
            Run("Карта пациента", () => Card(db));
            Run("Администратор", () => AdminChecks(db));
        }
        finally
        {
            try { Wait(DatabaseSetup.DropTestDatabaseAsync(cs)); Console.WriteLine("TEST DATABASE DROPPED"); }
            catch (Exception ex) { Console.WriteLine("DROP FAILED " + ex.Message); }
        }
        Console.WriteLine();
        Console.WriteLine($"ИТОГ: проверок пройдено {passed}, не пройдено {failed}. Снимки: {shots}");
        foreach (var f in failures) Console.WriteLine("  FAIL " + f);
        return failed == 0 ? 0 : 1;
    }

    // ---------------- Сценарии ----------------

    static void LoginChecks(MedDatabase db)
    {
        var session = new AppSession(db);
        using var login = new LoginForm(session);
        login.Show(); Pump(() => login.Visible);
        Find<TextBox>(login, "loginBox").Text = "ui_doctor";
        Find<TextBox>(login, "passwordBox").Text = "неверный-пароль";
        Find<Button>(login, "loginButton").PerformClick();
        var error = Find<Label>(login, "errorLabel");
        Pump(() => error.Text.Contains("Неверный"));
        Check(error.Text == "Неверный логин или пароль.", "неверный пароль: " + error.Text);
        Find<RadioButton>(login, "adminModeButton").Checked = true;
        Find<TextBox>(login, "passwordBox").Text = Password;
        Find<Button>(login, "loginButton").PerformClick();
        Pump(() => error.Text.Contains("Врач"));
        Check(error.Text.Contains("«Врач»"), "врач в режиме администратора получает подсказку: " + error.Text);
        Shot(login, "00-вход");
        login.Close();
    }

    static MainForm OpenMain(MedDatabase db, string login, Role role)
    {
        var session = new AppSession(db);
        Check(Wait(session.LoginAsync(login, Password, role)) == null, "вход " + login);
        var main = new MainForm(session) { WindowState = FormWindowState.Normal, Size = new Size(1600, 940), StartPosition = FormStartPosition.Manual, Location = new Point(0, 0) };
        main.Show();
        Pump(() => main.DataReady);
        return main;
    }

    static void PatientDirectory(MedDatabase db)
    {
        using var main = OpenMain(db, "ui_doctor", Role.Doctor);
        var grid = main.CurrentGrid;
        Check(main.Section == MainForm.Patients && grid.Name == "patientsGrid", "врач начинает с пациентов");
        Check(grid.Columns.Count == 6 && grid.Columns.Cast<DataGridViewColumn>().All(c => c.Name.EndsWith("Column")), "колонки таблицы пациентов заданы в конструкторе");
        Check(grid.Rows.Count == 36, "в списке 36 пациентов: " + grid.Rows.Count);
        Check(!Find<Button>(main, "navStaff").Visible, "вкладка «Сотрудники» скрыта от врача");
        var card = Find<PatientCard>(main, "patientCard");
        Pump(() => card.Patient != null);
        Check(card.Patient != null && Find<Label>(card, "nameLabel").Text == card.Patient.FullName, "справа карта выбранного пациента");

        var chip = Find<FilterChip>(main, "chipDeviation");
        chip.PerformClick(); Pump(() => main.DataReady);
        Check(grid.Rows.Count == chip.Count && grid.Rows.Cast<DataGridViewRow>().All(r => ((PatientRow)r.Tag!).Deviations > 0), "фильтр «С отклонениями»: " + grid.Rows.Count);
        Find<FilterChip>(main, "chipAll").PerformClick();

        var search = Find<TextBox>(main, "searchBox");
        search.Text = "PT-000003"; Pump(() => grid.Rows.Count == 1);
        Check(grid.Rows.Count == 1 && ((PatientRow)grid.Rows[0].Tag!).Patient.CardNumber == "PT-000003", "поиск по номеру карты");
        search.Text = "";

        Modal<PatientForm>(() => Find<Button>(main, "addButton").PerformClick(), form =>
        {
            var birth = Find<DateTimePicker>(form, "birthDatePicker");
            Check(birth.MinDate == new DateTime(1900, 1, 1) && birth.MaxDate <= DateTime.Today, "дата рождения выбирается из календаря: с 01.01.1900 по сегодня");
            Check(Find<ComboBox>(form, "sexBox").Items.Count == 2, "пол выбирается из списка");
            Find<TextBox>(form, "firstNameBox").Text = "Мария";
            Find<Button>(form, "saveButton").PerformClick();
            var error = Find<Label>(form, "errorLabel");
            Pump(() => error.Text.Length > 0);
            Check(error.Text.Contains("Фамилия"), "без фамилии пациент не сохраняется: " + error.Text);
            Find<TextBox>(form, "lastNameBox").Text = "Белова";
            Find<TextBox>(form, "middleNameBox").Text = "Сергеевна";
            birth.Value = new DateTime(1990, 4, 12);
            Find<TextBox>(form, "phoneBox").Text = "8 (913) 555-12-34";
            Find<TextBox>(form, "noteBox").Text = "Аллергия на пенициллин";
            Shot(form, "02-новый-пациент");
            Find<Button>(form, "saveButton").PerformClick();
        });
        Pump(() => main.DataReady && card.Patient?.LastName == "Белова");
        Check(grid.Rows.Count == 37, "пациент добавлен в список");
        Check(card.Patient?.LastName == "Белова" && card.Patient.Phone == "+79135551234" && card.Patient.BirthDate == new DateOnly(1990, 4, 12), "новый пациент выбран и открыт справа");
        Check(Find<Label>(card, "statusLabel").Text == "Нет обследований", "статус нового пациента");
        main.Close();
    }

    static void PatientChanges(MedDatabase db)
    {
        using var main = OpenMain(db, "ui_doctor", Role.Doctor);
        var grid = main.CurrentGrid;
        var search = Find<TextBox>(main, "searchBox");
        search.Text = "Белова"; Pump(() => grid.Rows.Count == 1);
        var card = Find<PatientCard>(main, "patientCard");
        Pump(() => card.Patient?.LastName == "Белова");
        var tabs = Find<TabControl>(card, "cardTabs");
        tabs.SelectedTab = Find<TabPage>(card, "infoTab"); Pump(() => true);
        Shot(main, "03-карточка-сведения");
        Modal<PatientForm>(() => Find<Button>(card, "editButton").PerformClick(), form =>
        {
            Check(Find<TextBox>(form, "lastNameBox").Text == "Белова" && Find<DateTimePicker>(form, "birthDatePicker").Value.Date == new DateTime(1990, 4, 12), "форма изменения заполнена данными пациента");
            Find<TextBox>(form, "phoneBox").Text = "+7 913 555-00-11";
            Shot(form, "04-изменение-пациента");
            Find<Button>(form, "saveButton").PerformClick();
        });
        Pump(() => main.DataReady && card.Patient?.Phone == "+79135550011");
        Check(card.Patient?.Phone == "+79135550011" && Find<Label>(card, "phoneValue").Text == "+79135550011", "телефон изменён через форму");
        Find<Button>(card, "archiveButton").PerformClick();
        Pump(() => main.DataReady && grid.Rows.Count == 0);
        var archive = Find<FilterChip>(main, "chipArchive");
        Check(archive.Count == 1, "пациент переведён в архив");
        archive.PerformClick(); Pump(() => main.DataReady && card.Patient != null);
        Shot(main, "05-архив");
        Find<Button>(card, "archiveButton").PerformClick();
        Pump(() => main.DataReady && Find<FilterChip>(main, "chipArchive").Count == 0);
        Check(Find<FilterChip>(main, "chipArchive").Count == 0, "пациент возвращён из архива");
        main.Close();
    }


    static void Card(MedDatabase db)
    {
        using var main = OpenMain(db, "ui_doctor", Role.Doctor);
        var grid = main.CurrentGrid;
        // Пациент с несколькими обследованиями другого врача.
        var row = grid.Rows.Cast<DataGridViewRow>().OrderByDescending(r => ((PatientRow)r.Tag!).ExamCount).ThenByDescending(r => ((PatientRow)r.Tag!).Deviations).First();
        grid.CurrentCell = row.Cells[0];
        var card = Find<PatientCard>(main, "patientCard");
        var id = ((PatientRow)row.Tag!).Patient.Id;
        Pump(() => card.Patient?.Id == id);
        Check(card.Examinations.Count >= 3, "у выбранного пациента несколько обследований: " + card.Examinations.Count);
        var tabs = Find<TabControl>(card, "cardTabs");
        Check(tabs.TabPages.Count == 1 && tabs.TabPages[0].Name == "infoTab", "в карточке только сведения о пациенте");
        Check(!All(card).Any(c => c.Name is "newExamButton" or "printButton"), "кнопок обследований и печати в этой версии нет");
        Shot(main, "01-пациенты");
        tabs.SelectedTab = Find<TabPage>(card, "infoTab"); Pump(() => true);
        Shot(main, "08-карта-сведения");
        main.Close();
    }


    static void AdminChecks(MedDatabase db)
    {
        using var main = OpenMain(db, "ui_admin", Role.Admin);
        var card = Find<PatientCard>(main, "patientCard");
        Pump(() => card.Patient != null);

        Find<Button>(main, "navStaff").PerformClick();
        Pump(() => main.DataReady && main.Section == MainForm.Staff);
        var staff = main.CurrentGrid;
        Check(staff.Name == "staffGrid" && staff.Rows.Count == 3, "сотрудников 3: " + staff.Rows.Count);
        Modal<StaffForm>(() => Find<Button>(main, "addButton").PerformClick(), form =>
        {
            Check(Find<ComboBox>(form, "roleBox").Items.Count == 2 && Find<CheckBox>(form, "activeCheck").Checked, "роль выбирается из списка, новый сотрудник активен");
            Find<TextBox>(form, "loginBox").Text = "ui_nurse";
            Find<TextBox>(form, "fullNameBox").Text = "Новикова Ольга Андреевна";
            Find<TextBox>(form, "passwordBox").Text = Password;
            Shot(form, "15-новый-сотрудник");
            Find<Button>(form, "saveButton").PerformClick();
        });
        Pump(() => main.DataReady && staff.Rows.Count == 4);
        Check(staff.Rows.Count == 4, "сотрудник добавлен");
        Shot(main, "14-сотрудники");
        Check(!All(main).Any(c => c.Name is "navStats" or "navIndicators"), "в этой версии только разделы «Пациенты» и «Сотрудники»");
        main.Close();
    }

    // ---------------- Помощники ----------------

    static void Set(DataGridView grid, string indicatorName, string value)
    {
        // The value is put into the cell as the grid commits typed text; the form reacts to CellValueChanged.
        var row = grid.Rows.Cast<DataGridViewRow>().Single(r => r.Cells["name"].Value?.ToString() == indicatorName);
        grid.EndEdit();
        row.Cells["value"].Value = value;
        Application.DoEvents();
        if (row.Cells["value"].Value?.ToString() != value) throw new InvalidOperationException("значение не записалось в ячейку " + indicatorName);
    }

    static void Run(string name, Action scenario)
    {
        Console.WriteLine("== " + name);
        try { scenario(); }
        catch (Exception ex) { failed++; failures.Add(name + ": " + ex.Message); Console.WriteLine("  ERROR " + ex); }
        foreach (Form f in Application.OpenForms.Cast<Form>().ToList()) if (f.Modal) f.Close();
        if (SynchronizationContext.Current is not WindowsFormsSynchronizationContext)
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
    }

    static void Check(bool ok, string what)
    {
        if (ok) { passed++; Console.WriteLine("  PASS " + what); }
        else { failed++; failures.Add(what); Console.WriteLine("  FAIL " + what); }
    }

    static T Wait<T>(Task<T> task) { while (!task.IsCompleted) { Application.DoEvents(); Thread.Sleep(5); } return task.GetAwaiter().GetResult(); }
    static void Wait(Task task) { while (!task.IsCompleted) { Application.DoEvents(); Thread.Sleep(5); } task.GetAwaiter().GetResult(); }

    static void Pump(Func<bool> done, int ms = 20000)
    {
        var until = DateTime.UtcNow.AddMilliseconds(ms);
        do { Application.DoEvents(); Thread.Sleep(10); } while (!done() && DateTime.UtcNow < until);
        for (int i = 0; i < 5; i++) { Application.DoEvents(); Thread.Sleep(10); }
    }

    static IEnumerable<Control> All(Control root)
    {
        foreach (Control c in root.Controls) { yield return c; foreach (var d in All(c)) yield return d; }
    }

    static T Find<T>(Control root, string name) where T : Control =>
        All(root).OfType<T>().FirstOrDefault(c => c.Name == name) ?? throw new InvalidOperationException("Не найден элемент " + name + " в " + root.Name);

    /// <summary>Opens a modal window with <paramref name="open"/> and acts on it from a timer inside its message loop.</summary>
    static void Modal<T>(Action open, Action<T> act) where T : Form
    {
        bool handled = false; Exception? error = null;
        using var timer = new System.Windows.Forms.Timer { Interval = 50 };
        timer.Tick += (_, _) =>
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault(f => f.Visible);
            if (form == null || handled) return;
            handled = true; timer.Stop();
            // A modal window hides only when its own loop resumes, so the end of «Save» is its DialogResult or a message.
            bool Done() => !form.Visible || form.DialogResult != DialogResult.None
                || All(form).OfType<Label>().Any(l => l.Name is "errorLabel" or "messageLabel" && l.Text.Length > 0 && l.Text != "Сохранение…" && !l.Text.StartsWith("Внёс"));
            try { Pump(() => true); act(form); Pump(Done, 15000); }
            catch (Exception ex) { error = ex; }
            if (form.Visible && form.DialogResult == DialogResult.None)
            {
                // Still open after «Save»: report what the window says.
                var said = All(form).OfType<Label>().Where(l => l.Name is "errorLabel" or "messageLabel" && l.Text.Length > 0).Select(l => l.Text).FirstOrDefault();
                if (said != null && !said.StartsWith("Внёс")) Console.WriteLine("  NOTE окно осталось открытым: " + said);
                form.Close();
            }
        };
        timer.Start();
        open();
        Check(handled, "окно " + typeof(T).Name + " открылось");
        if (error != null) throw error;
    }

    static void Shot(Form form, string name)
    {
        form.Activate(); form.BringToFront(); Pump(() => true);
        // A copy of the screen shows exactly what the user sees (DrawToBitmap misses custom-painted controls on some systems).
        var bounds = form.Bounds;
        using var bitmap = new Bitmap(bounds.Width, bounds.Height);
        using (var g = Graphics.FromImage(bitmap)) g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
        bitmap.Save(Path.Combine(shots, name + ".png"), ImageFormat.Png);
    }
}
