#nullable enable
namespace MedTest.Desktop;

partial class StaffForm
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!, fieldsPanel = null!;
    private System.Windows.Forms.FlowLayoutPanel buttons = null!;
    private System.Windows.Forms.Label titleLabel = null!, errorLabel = null!, loginLabel = null!, roleLabel = null!, fullNameLabel = null!, passwordLabel = null!;
    private System.Windows.Forms.TextBox loginBox = null!, fullNameBox = null!, passwordBox = null!;
    private System.Windows.Forms.ComboBox roleBox = null!;
    private System.Windows.Forms.CheckBox activeCheck = null!;
    private UiButton saveButton = null!, cancelButton = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.titleLabel = new System.Windows.Forms.Label();
        this.fieldsPanel = new System.Windows.Forms.TableLayoutPanel();
        this.loginLabel = new System.Windows.Forms.Label();
        this.roleLabel = new System.Windows.Forms.Label();
        this.fullNameLabel = new System.Windows.Forms.Label();
        this.passwordLabel = new System.Windows.Forms.Label();
        this.loginBox = new System.Windows.Forms.TextBox();
        this.roleBox = new System.Windows.Forms.ComboBox();
        this.fullNameBox = new System.Windows.Forms.TextBox();
        this.passwordBox = new System.Windows.Forms.TextBox();
        this.activeCheck = new System.Windows.Forms.CheckBox();
        this.errorLabel = new System.Windows.Forms.Label();
        this.buttons = new System.Windows.Forms.FlowLayoutPanel();
        this.saveButton = new MedTest.Desktop.UiButton();
        this.cancelButton = new MedTest.Desktop.UiButton();
        this.layout.SuspendLayout();
        this.fieldsPanel.SuspendLayout();
        this.buttons.SuspendLayout();
        this.SuspendLayout();
        //
        // layout: title, fields, error line, buttons
        //
        this.layout.ColumnCount = 1;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.Controls.Add(this.titleLabel, 0, 0);
        this.layout.Controls.Add(this.fieldsPanel, 0, 1);
        this.layout.Controls.Add(this.errorLabel, 0, 2);
        this.layout.Controls.Add(this.buttons, 0, 3);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Name = "layout";
        this.layout.Padding = new System.Windows.Forms.Padding(28, 22, 28, 18);
        this.layout.RowCount = 4;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
        //
        // titleLabel
        //
        this.titleLabel.AutoEllipsis = true;
        this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.titleLabel.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Text = "Новый сотрудник";
        this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // fieldsPanel: two columns, a caption above every field
        //
        this.fieldsPanel.ColumnCount = 2;
        this.fieldsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.fieldsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.fieldsPanel.Controls.Add(this.loginLabel, 0, 0);
        this.fieldsPanel.Controls.Add(this.loginBox, 0, 1);
        this.fieldsPanel.Controls.Add(this.roleLabel, 1, 0);
        this.fieldsPanel.Controls.Add(this.roleBox, 1, 1);
        this.fieldsPanel.Controls.Add(this.fullNameLabel, 0, 2);
        this.fieldsPanel.Controls.Add(this.fullNameBox, 0, 3);
        this.fieldsPanel.Controls.Add(this.passwordLabel, 0, 4);
        this.fieldsPanel.Controls.Add(this.passwordBox, 0, 5);
        this.fieldsPanel.Controls.Add(this.activeCheck, 1, 5);
        this.fieldsPanel.SetColumnSpan(this.fullNameLabel, 2);
        this.fieldsPanel.SetColumnSpan(this.fullNameBox, 2);
        this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.fieldsPanel.Name = "fieldsPanel";
        this.fieldsPanel.RowCount = 7;
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // loginLabel
        //
        this.loginLabel.AutoSize = true;
        this.loginLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.loginLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.loginLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.loginLabel.Name = "loginLabel";
        this.loginLabel.Text = "Логин *";
        //
        // roleLabel
        //
        this.roleLabel.AutoSize = true;
        this.roleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.roleLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.roleLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.roleLabel.Name = "roleLabel";
        this.roleLabel.Text = "Роль *";
        //
        // fullNameLabel
        //
        this.fullNameLabel.AutoSize = true;
        this.fullNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.fullNameLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.fullNameLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.fullNameLabel.Name = "fullNameLabel";
        this.fullNameLabel.Text = "ФИО *";
        //
        // passwordLabel
        //
        this.passwordLabel.AutoSize = true;
        this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.passwordLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.passwordLabel.Name = "passwordLabel";
        this.passwordLabel.Text = "Пароль (не меньше 8 символов) *";
        //
        // loginBox
        //
        this.loginBox.AccessibleName = "Логин";
        this.loginBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.loginBox.Height = 30;
        this.loginBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.loginBox.MaxLength = 40;
        this.loginBox.Name = "loginBox";
        this.loginBox.TabIndex = 0;
        this.loginBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // roleBox
        //
        this.roleBox.AccessibleName = "Роль";
        this.roleBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.roleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.roleBox.Items.AddRange(new object[] { "Врач", "Администратор" });
        this.roleBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.roleBox.Name = "roleBox";
        this.roleBox.TabIndex = 1;
        //
        // fullNameBox
        //
        this.fullNameBox.AccessibleName = "ФИО";
        this.fullNameBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.fullNameBox.Height = 30;
        this.fullNameBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.fullNameBox.MaxLength = 150;
        this.fullNameBox.Name = "fullNameBox";
        this.fullNameBox.TabIndex = 2;
        this.fullNameBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // passwordBox
        //
        this.passwordBox.AccessibleName = "Пароль (не меньше 8 символов)";
        this.passwordBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.passwordBox.Height = 30;
        this.passwordBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.passwordBox.MaxLength = 128;
        this.passwordBox.UseSystemPasswordChar = true;
        this.passwordBox.Name = "passwordBox";
        this.passwordBox.TabIndex = 3;
        this.passwordBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // activeCheck
        //
        this.activeCheck.AutoSize = true;
        this.activeCheck.Checked = true;
        this.activeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
        this.activeCheck.Dock = System.Windows.Forms.DockStyle.Fill;
        this.activeCheck.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.activeCheck.Text = "Активен: может входить в систему";
        this.activeCheck.UseVisualStyleBackColor = true;
        this.activeCheck.Name = "activeCheck";
        this.activeCheck.TabIndex = 4;
        //
        // errorLabel (validation and database messages)
        //
        this.errorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(181, 82, 62);
        this.errorLabel.Name = "errorLabel";
        this.errorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
        //
        // buttons
        //
        this.buttons.Controls.Add(this.cancelButton);
        this.buttons.Controls.Add(this.saveButton);
        this.buttons.Dock = System.Windows.Forms.DockStyle.Fill;
        this.buttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this.buttons.Name = "buttons";
        this.buttons.WrapContents = false;
        //
        // saveButton
        //
        this.saveButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.saveButton.Name = "saveButton";
        this.saveButton.Size = new System.Drawing.Size(140, 38);
        this.saveButton.TabIndex = 5;
        this.saveButton.Text = "Сохранить";
        this.saveButton.Tone = MedTest.Desktop.ButtonTone.Primary;
        this.saveButton.Click += new System.EventHandler(this.SaveClick);
        //
        // cancelButton
        //
        this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new System.Drawing.Size(120, 38);
        this.cancelButton.TabIndex = 6;
        this.cancelButton.Text = "Отмена";
        //
        // StaffForm
        //
        this.AcceptButton = this.saveButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.cancelButton;
        this.ClientSize = new System.Drawing.Size(720, 560);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(640, 500);
        this.Name = "StaffForm";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "МедТест — сотрудник";
        this.layout.ResumeLayout(false);
        this.fieldsPanel.ResumeLayout(false);
        this.fieldsPanel.PerformLayout();
        this.buttons.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
