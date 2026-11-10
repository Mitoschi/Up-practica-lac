using MedTest.Core;
namespace MedTest.Desktop;

public partial class LoginForm : Form
{
    private readonly AppSession? session;
    private bool busy;
    public LoginForm() { InitializeComponent(); Theme.Apply(this); }
    public LoginForm(AppSession session) : this() { this.session = session; }
    private async void LoginClick(object? sender, EventArgs e)
    {
        if (busy || session == null) return;
        busy = true; loginButton.Enabled = false; roleSelector.Enabled = false; errorLabel.ForeColor = Theme.Muted; errorLabel.Text = "Подключение…";
        var error = await session.LoginAsync(loginBox.Text, passwordBox.Text, adminModeButton.Checked ? Role.Admin : Role.Doctor);
        passwordBox.Clear(); busy = false;
        if (IsDisposed) return;
        loginButton.Enabled = true; roleSelector.Enabled = true;
        if (error != null) { errorLabel.ForeColor = Theme.Rust; errorLabel.Text = error; passwordBox.Focus(); return; }
        errorLabel.Text = ""; Hide();
        using (var main = new MainForm(session)) main.ShowDialog();
        session.Logout();
        if (IsDisposed) return;
        Show(); passwordBox.Focus();
    }
}
