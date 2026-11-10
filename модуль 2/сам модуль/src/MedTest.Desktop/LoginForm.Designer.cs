#nullable enable
namespace MedTest.Desktop;
partial class LoginForm
{
    private System.ComponentModel.IContainer? components;
    private TableLayoutPanel layout = null!, identityPanel = null!, formPanel = null!;
    private FlowLayoutPanel roleSelector = null!;
    private BrandMark brandMark = null!;
    private Label headingLabel = null!, welcomeLabel = null!, roleLabel = null!, loginLabel = null!, passwordLabel = null!, errorLabel = null!;
    private TextBox loginBox = null!, passwordBox = null!;
    private UiButton loginButton = null!;
    private SegmentButton adminModeButton = null!, doctorModeButton = null!;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.identityPanel = new System.Windows.Forms.TableLayoutPanel();
        this.formPanel = new System.Windows.Forms.TableLayoutPanel();
        this.roleSelector = new System.Windows.Forms.FlowLayoutPanel();
        this.brandMark = new MedTest.Desktop.BrandMark();
        this.welcomeLabel = new System.Windows.Forms.Label();
        this.headingLabel = new System.Windows.Forms.Label();
        this.roleLabel = new System.Windows.Forms.Label();
        this.loginLabel = new System.Windows.Forms.Label();
        this.passwordLabel = new System.Windows.Forms.Label();
        this.errorLabel = new System.Windows.Forms.Label();
        this.loginBox = new System.Windows.Forms.TextBox();
        this.passwordBox = new System.Windows.Forms.TextBox();
        this.loginButton = new MedTest.Desktop.UiButton();
        this.adminModeButton = new MedTest.Desktop.SegmentButton();
        this.doctorModeButton = new MedTest.Desktop.SegmentButton();
        this.layout.SuspendLayout();
        this.identityPanel.SuspendLayout();
        this.formPanel.SuspendLayout();
        this.roleSelector.SuspendLayout();
        this.SuspendLayout();
        //
        // layout
        //
        this.layout.ColumnCount = 2;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
        this.layout.Controls.Add(this.identityPanel, 0, 0);
        this.layout.Controls.Add(this.formPanel, 1, 0);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Margin = new System.Windows.Forms.Padding(0);
        this.layout.Name = "loginLayout";
        this.layout.RowCount = 1;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // identityPanel
        //
        this.identityPanel.BackColor = System.Drawing.Color.FromArgb(16, 34, 28);
        this.identityPanel.ColumnCount = 1;
        this.identityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.identityPanel.Controls.Add(this.brandMark, 0, 0);
        this.identityPanel.Controls.Add(this.welcomeLabel, 0, 1);
        this.identityPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.identityPanel.Margin = new System.Windows.Forms.Padding(0);
        this.identityPanel.Name = "identityPanel";
        this.identityPanel.Padding = new System.Windows.Forms.Padding(28, 28, 20, 28);
        this.identityPanel.RowCount = 2;
        this.identityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        this.identityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // brandMark
        //
        this.brandMark.BackColor = System.Drawing.Color.FromArgb(16, 34, 28);
        this.brandMark.Dock = System.Windows.Forms.DockStyle.Fill;
        this.brandMark.Font = new System.Drawing.Font("Georgia", 15F);
        this.brandMark.ForeColor = System.Drawing.Color.FromArgb(233, 241, 238);
        this.brandMark.Margin = new System.Windows.Forms.Padding(0);
        this.brandMark.Name = "brandMark";
        this.brandMark.Text = "МедТест";
        //
        // welcomeLabel
        //
        this.welcomeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(147, 173, 164);
        this.welcomeLabel.Margin = new System.Windows.Forms.Padding(2, 8, 0, 0);
        this.welcomeLabel.Name = "welcomeLabel";
        this.welcomeLabel.Text = "Медицинские тесты";
        //
        // formPanel
        //
        this.formPanel.BackColor = System.Drawing.Color.White;
        this.formPanel.ColumnCount = 1;
        this.formPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.formPanel.Controls.Add(this.headingLabel, 0, 0);
        this.formPanel.Controls.Add(this.roleLabel, 0, 1);
        this.formPanel.Controls.Add(this.roleSelector, 0, 2);
        this.formPanel.Controls.Add(this.loginLabel, 0, 3);
        this.formPanel.Controls.Add(this.loginBox, 0, 4);
        this.formPanel.Controls.Add(this.passwordLabel, 0, 5);
        this.formPanel.Controls.Add(this.passwordBox, 0, 6);
        this.formPanel.Controls.Add(this.loginButton, 0, 7);
        this.formPanel.Controls.Add(this.errorLabel, 0, 8);
        this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.formPanel.Margin = new System.Windows.Forms.Padding(0);
        this.formPanel.Name = "formPanel";
        this.formPanel.Padding = new System.Windows.Forms.Padding(44, 40, 44, 24);
        this.formPanel.RowCount = 9;
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
        this.formPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // headingLabel
        //
        this.headingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.headingLabel.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
        this.headingLabel.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.headingLabel.Margin = new System.Windows.Forms.Padding(0);
        this.headingLabel.Name = "loginHeading";
        this.headingLabel.Text = "Вход";
        //
        // roleLabel
        //
        this.roleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.roleLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.roleLabel.Margin = new System.Windows.Forms.Padding(0);
        this.roleLabel.Name = "roleLabel";
        this.roleLabel.Text = "Режим";
        //
        // roleSelector
        //
        this.roleSelector.Controls.Add(this.doctorModeButton);
        this.roleSelector.Controls.Add(this.adminModeButton);
        this.roleSelector.Dock = System.Windows.Forms.DockStyle.Fill;
        this.roleSelector.Margin = new System.Windows.Forms.Padding(0);
        this.roleSelector.Name = "roleSelector";
        this.roleSelector.WrapContents = false;
        //
        // adminModeButton
        //
        this.adminModeButton.Margin = new System.Windows.Forms.Padding(0);
        this.adminModeButton.Name = "adminModeButton";
        this.adminModeButton.Size = new System.Drawing.Size(160, 38);
        this.adminModeButton.TabStop = false;
        this.adminModeButton.Text = "Администратор";
        //
        // doctorModeButton
        //
        this.doctorModeButton.Checked = true;
        this.doctorModeButton.Margin = new System.Windows.Forms.Padding(0);
        this.doctorModeButton.Name = "doctorModeButton";
        this.doctorModeButton.Size = new System.Drawing.Size(140, 38);
        this.doctorModeButton.TabStop = false;
        this.doctorModeButton.Text = "Врач";
        //
        // loginLabel
        //
        this.loginLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.loginLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.loginLabel.Margin = new System.Windows.Forms.Padding(0);
        this.loginLabel.Name = "loginLabel";
        this.loginLabel.Text = "Логин";
        //
        // loginBox
        //
        this.loginBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.loginBox.Margin = new System.Windows.Forms.Padding(0);
        this.loginBox.MaxLength = 32;
        this.loginBox.Name = "loginBox";
        this.loginBox.TabIndex = 0;
        //
        // passwordLabel
        //
        this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.passwordLabel.Margin = new System.Windows.Forms.Padding(0);
        this.passwordLabel.Name = "passwordLabel";
        this.passwordLabel.Text = "Пароль";
        //
        // passwordBox
        //
        this.passwordBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.passwordBox.Margin = new System.Windows.Forms.Padding(0);
        this.passwordBox.MaxLength = 128;
        this.passwordBox.Name = "passwordBox";
        this.passwordBox.TabIndex = 1;
        this.passwordBox.UseSystemPasswordChar = true;
        //
        // loginButton
        //
        this.loginButton.Dock = System.Windows.Forms.DockStyle.Fill;
        this.loginButton.Margin = new System.Windows.Forms.Padding(0);
        this.loginButton.Name = "loginButton";
        this.loginButton.TabIndex = 2;
        this.loginButton.Text = "Войти";
        this.loginButton.Tone = MedTest.Desktop.ButtonTone.Primary;
        this.loginButton.Click += new System.EventHandler(this.LoginClick);
        //
        // errorLabel
        //
        this.errorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(181, 82, 62);
        this.errorLabel.Margin = new System.Windows.Forms.Padding(0);
        this.errorLabel.Name = "errorLabel";
        this.errorLabel.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
        //
        // LoginForm
        //
        this.AcceptButton = this.loginButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(860, 540);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.MinimumSize = new System.Drawing.Size(760, 540);
        this.Name = "LoginForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "МедТест — вход";
        this.layout.ResumeLayout(false);
        this.identityPanel.ResumeLayout(false);
        this.formPanel.ResumeLayout(false);
        this.formPanel.PerformLayout();
        this.roleSelector.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
