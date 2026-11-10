using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>
/// Учётная запись сотрудника: логин, ФИО, роль (список), пароль и признак «Активен».
/// При изменении пустой пароль оставляет прежний.
/// </summary>
public partial class StaffForm : Form
{
    private readonly AppSession? session;
    private readonly AppUser? user;
    private bool saving;

    public StaffForm()
    {
        InitializeComponent(); Theme.Apply(this);
        roleBox.SelectedIndex = 0;
    }

    public StaffForm(AppSession session, AppUser? user) : this()
    {
        this.session = session; this.user = user;
        if (user == null) return;
        titleLabel.Text = "Сотрудник " + user.Login;
        loginBox.Text = user.Login; fullNameBox.Text = user.FullName;
        roleBox.SelectedIndex = user.Role == Role.Admin ? 1 : 0;
        activeCheck.Checked = user.IsActive;
        passwordLabel.Text = "Новый пароль (пусто — оставить прежний)";
    }

    /// <summary>Opens the form; returns true when the account was saved.</summary>
    public static bool Edit(IWin32Window? owner, AppSession session, AppUser? user)
    {
        using var form = new StaffForm(session, user);
        return form.ShowDialog(owner) == DialogResult.OK;
    }

    private async void SaveClick(object? sender, EventArgs e)
    {
        if (saving || session == null) return;
        if (loginBox.Text.Trim().Length == 0) { Error("Заполните поле «Логин».", loginBox); return; }
        if (fullNameBox.Text.Trim().Length == 0) { Error("Заполните поле «ФИО».", fullNameBox); return; }
        if (user == null && passwordBox.Text.Length == 0) { Error("Задайте пароль нового сотрудника.", passwordBox); return; }
        var input = new UserInput(loginBox.Text.Trim(), fullNameBox.Text.Trim(), roleBox.SelectedIndex == 1 ? Role.Admin : Role.Doctor, activeCheck.Checked, passwordBox.Text);
        saving = true; saveButton.Enabled = false; errorLabel.ForeColor = Theme.Muted; errorLabel.Text = "Сохранение…";
        var (_, error) = await AppSession.Try(() => session.Db.SaveUserAsync(session.Actor, user?.Id, input));
        saving = false;
        if (IsDisposed) return;
        saveButton.Enabled = true;
        if (error != null) { Error(error, null); return; }
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
