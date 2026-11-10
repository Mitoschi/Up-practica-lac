#nullable enable
namespace MedTest.Desktop;

partial class PatientForm
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!, fieldsPanel = null!;
    private System.Windows.Forms.FlowLayoutPanel buttons = null!;
    private System.Windows.Forms.Label titleLabel = null!, errorLabel = null!, lastNameLabel = null!, firstNameLabel = null!, middleNameLabel = null!, birthDateLabel = null!, sexLabel = null!, phoneLabel = null!, noteLabel = null!;
    private System.Windows.Forms.TextBox lastNameBox = null!, firstNameBox = null!, middleNameBox = null!, phoneBox = null!, noteBox = null!;
    private System.Windows.Forms.DateTimePicker birthDatePicker = null!;
    private System.Windows.Forms.ComboBox sexBox = null!;
    private UiButton saveButton = null!, cancelButton = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.titleLabel = new System.Windows.Forms.Label();
        this.fieldsPanel = new System.Windows.Forms.TableLayoutPanel();
        this.lastNameLabel = new System.Windows.Forms.Label();
        this.firstNameLabel = new System.Windows.Forms.Label();
        this.middleNameLabel = new System.Windows.Forms.Label();
        this.birthDateLabel = new System.Windows.Forms.Label();
        this.sexLabel = new System.Windows.Forms.Label();
        this.phoneLabel = new System.Windows.Forms.Label();
        this.noteLabel = new System.Windows.Forms.Label();
        this.lastNameBox = new System.Windows.Forms.TextBox();
        this.firstNameBox = new System.Windows.Forms.TextBox();
        this.middleNameBox = new System.Windows.Forms.TextBox();
        this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
        this.sexBox = new System.Windows.Forms.ComboBox();
        this.phoneBox = new System.Windows.Forms.TextBox();
        this.noteBox = new System.Windows.Forms.TextBox();
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
        this.titleLabel.Text = "Новый пациент";
        this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // fieldsPanel: two columns, a caption above every field
        //
        this.fieldsPanel.ColumnCount = 2;
        this.fieldsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.fieldsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.fieldsPanel.Controls.Add(this.lastNameLabel, 0, 0);
        this.fieldsPanel.Controls.Add(this.lastNameBox, 0, 1);
        this.fieldsPanel.Controls.Add(this.firstNameLabel, 1, 0);
        this.fieldsPanel.Controls.Add(this.firstNameBox, 1, 1);
        this.fieldsPanel.Controls.Add(this.middleNameLabel, 0, 2);
        this.fieldsPanel.Controls.Add(this.middleNameBox, 0, 3);
        this.fieldsPanel.Controls.Add(this.birthDateLabel, 1, 2);
        this.fieldsPanel.Controls.Add(this.birthDatePicker, 1, 3);
        this.fieldsPanel.Controls.Add(this.sexLabel, 0, 4);
        this.fieldsPanel.Controls.Add(this.sexBox, 0, 5);
        this.fieldsPanel.Controls.Add(this.phoneLabel, 1, 4);
        this.fieldsPanel.Controls.Add(this.phoneBox, 1, 5);
        this.fieldsPanel.Controls.Add(this.noteLabel, 0, 6);
        this.fieldsPanel.Controls.Add(this.noteBox, 0, 7);
        this.fieldsPanel.SetColumnSpan(this.noteLabel, 2);
        this.fieldsPanel.SetColumnSpan(this.noteBox, 2);
        this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.fieldsPanel.Name = "fieldsPanel";
        this.fieldsPanel.RowCount = 9;
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // lastNameLabel
        //
        this.lastNameLabel.AutoSize = true;
        this.lastNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lastNameLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.lastNameLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.lastNameLabel.Name = "lastNameLabel";
        this.lastNameLabel.Text = "Фамилия *";
        //
        // firstNameLabel
        //
        this.firstNameLabel.AutoSize = true;
        this.firstNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.firstNameLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.firstNameLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.firstNameLabel.Name = "firstNameLabel";
        this.firstNameLabel.Text = "Имя *";
        //
        // middleNameLabel
        //
        this.middleNameLabel.AutoSize = true;
        this.middleNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.middleNameLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.middleNameLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.middleNameLabel.Name = "middleNameLabel";
        this.middleNameLabel.Text = "Отчество";
        //
        // birthDateLabel
        //
        this.birthDateLabel.AutoSize = true;
        this.birthDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.birthDateLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.birthDateLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.birthDateLabel.Name = "birthDateLabel";
        this.birthDateLabel.Text = "Дата рождения *";
        //
        // sexLabel
        //
        this.sexLabel.AutoSize = true;
        this.sexLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.sexLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.sexLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.sexLabel.Name = "sexLabel";
        this.sexLabel.Text = "Пол *";
        //
        // phoneLabel
        //
        this.phoneLabel.AutoSize = true;
        this.phoneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.phoneLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.phoneLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.phoneLabel.Name = "phoneLabel";
        this.phoneLabel.Text = "Телефон";
        //
        // noteLabel
        //
        this.noteLabel.AutoSize = true;
        this.noteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.noteLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.noteLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.noteLabel.Name = "noteLabel";
        this.noteLabel.Text = "Примечание";
        //
        // lastNameBox
        //
        this.lastNameBox.AccessibleName = "Фамилия";
        this.lastNameBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.lastNameBox.Height = 30;
        this.lastNameBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.lastNameBox.MaxLength = 60;
        this.lastNameBox.Name = "lastNameBox";
        this.lastNameBox.TabIndex = 0;
        this.lastNameBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // firstNameBox
        //
        this.firstNameBox.AccessibleName = "Имя";
        this.firstNameBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.firstNameBox.Height = 30;
        this.firstNameBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.firstNameBox.MaxLength = 60;
        this.firstNameBox.Name = "firstNameBox";
        this.firstNameBox.TabIndex = 1;
        this.firstNameBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // middleNameBox
        //
        this.middleNameBox.AccessibleName = "Отчество";
        this.middleNameBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.middleNameBox.Height = 30;
        this.middleNameBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.middleNameBox.MaxLength = 60;
        this.middleNameBox.Name = "middleNameBox";
        this.middleNameBox.TabIndex = 2;
        this.middleNameBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // birthDatePicker
        //
        this.birthDatePicker.AccessibleName = "Дата рождения";
        this.birthDatePicker.CustomFormat = "dd.MM.yyyy";
        this.birthDatePicker.Dock = System.Windows.Forms.DockStyle.Top;
        this.birthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.birthDatePicker.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.birthDatePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        this.birthDatePicker.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
        this.birthDatePicker.Name = "birthDatePicker";
        this.birthDatePicker.TabIndex = 3;
        //
        // sexBox
        //
        this.sexBox.AccessibleName = "Пол";
        this.sexBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.sexBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.sexBox.Items.AddRange(new object[] { "Женский", "Мужской" });
        this.sexBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.sexBox.Name = "sexBox";
        this.sexBox.TabIndex = 4;
        //
        // phoneBox
        //
        this.phoneBox.AccessibleName = "Телефон";
        this.phoneBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.phoneBox.Height = 30;
        this.phoneBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.phoneBox.MaxLength = 30;
        this.phoneBox.Name = "phoneBox";
        this.phoneBox.TabIndex = 5;
        this.phoneBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // noteBox
        //
        this.noteBox.AccessibleName = "Примечание";
        this.noteBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.noteBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.noteBox.MaxLength = 2000;
        this.noteBox.Multiline = true;
        this.noteBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.noteBox.Name = "noteBox";
        this.noteBox.TabIndex = 6;
        this.noteBox.TextChanged += new System.EventHandler(this.FieldChanged);
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
        this.saveButton.TabIndex = 7;
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
        this.cancelButton.TabIndex = 8;
        this.cancelButton.Text = "Отмена";
        //
        // PatientForm
        //
        this.AcceptButton = this.saveButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.cancelButton;
        this.ClientSize = new System.Drawing.Size(720, 640);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(640, 580);
        this.Name = "PatientForm";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "МедТест — пациент";
        this.layout.ResumeLayout(false);
        this.fieldsPanel.ResumeLayout(false);
        this.fieldsPanel.PerformLayout();
        this.buttons.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
