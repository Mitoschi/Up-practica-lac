#nullable enable
namespace MedTest.Desktop;

partial class PatientCard
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!, headingPanel = null!, infoTable = null!;
    private System.Windows.Forms.Label nameLabel = null!, statusLabel = null!, subLabel = null!, footerLabel = null!;
    private System.Windows.Forms.Label cardCaption = null!, birthCaption = null!, sexCaption = null!, phoneCaption = null!, noteCaption = null!, stateCaption = null!;
    private System.Windows.Forms.Label cardValue = null!, birthValue = null!, sexValue = null!, phoneValue = null!, noteValue = null!, stateValue = null!;
    private System.Windows.Forms.FlowLayoutPanel actions = null!;
    private UiButton editButton = null!, archiveButton = null!, deleteButton = null!;
    private UiTabs tabs = null!;
    private System.Windows.Forms.TabPage infoTab = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.headingPanel = new System.Windows.Forms.TableLayoutPanel();
        this.nameLabel = new System.Windows.Forms.Label();
        this.statusLabel = new System.Windows.Forms.Label();
        this.subLabel = new System.Windows.Forms.Label();
        this.actions = new System.Windows.Forms.FlowLayoutPanel();
        this.editButton = new MedTest.Desktop.UiButton();
        this.archiveButton = new MedTest.Desktop.UiButton();
        this.deleteButton = new MedTest.Desktop.UiButton();
        this.tabs = new MedTest.Desktop.UiTabs();
        this.infoTab = new System.Windows.Forms.TabPage();
        this.infoTable = new System.Windows.Forms.TableLayoutPanel();
        this.cardCaption = new System.Windows.Forms.Label();
        this.cardValue = new System.Windows.Forms.Label();
        this.birthCaption = new System.Windows.Forms.Label();
        this.birthValue = new System.Windows.Forms.Label();
        this.sexCaption = new System.Windows.Forms.Label();
        this.sexValue = new System.Windows.Forms.Label();
        this.phoneCaption = new System.Windows.Forms.Label();
        this.phoneValue = new System.Windows.Forms.Label();
        this.noteCaption = new System.Windows.Forms.Label();
        this.noteValue = new System.Windows.Forms.Label();
        this.stateCaption = new System.Windows.Forms.Label();
        this.stateValue = new System.Windows.Forms.Label();
        this.footerLabel = new System.Windows.Forms.Label();
        this.layout.SuspendLayout();
        this.headingPanel.SuspendLayout();
        this.actions.SuspendLayout();
        this.tabs.SuspendLayout();
        this.infoTab.SuspendLayout();
        this.infoTable.SuspendLayout();
        this.SuspendLayout();
        //
        // layout: heading, actions, tabs, footer
        //
        this.layout.BackColor = System.Drawing.Color.White;
        this.layout.ColumnCount = 1;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.Controls.Add(this.headingPanel, 0, 0);
        this.layout.Controls.Add(this.actions, 0, 1);
        this.layout.Controls.Add(this.tabs, 0, 2);
        this.layout.Controls.Add(this.footerLabel, 0, 3);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Margin = new System.Windows.Forms.Padding(0);
        this.layout.Name = "cardLayout";
        this.layout.Padding = new System.Windows.Forms.Padding(18, 12, 18, 4);
        this.layout.RowCount = 4;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        //
        // headingPanel
        //
        this.headingPanel.ColumnCount = 2;
        this.headingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.headingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.headingPanel.Controls.Add(this.nameLabel, 0, 0);
        this.headingPanel.Controls.Add(this.statusLabel, 1, 0);
        this.headingPanel.Controls.Add(this.subLabel, 0, 1);
        this.headingPanel.SetColumnSpan(this.subLabel, 2);
        this.headingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.headingPanel.Margin = new System.Windows.Forms.Padding(0);
        this.headingPanel.Name = "headingPanel";
        this.headingPanel.RowCount = 2;
        this.headingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        this.headingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // nameLabel
        //
        this.nameLabel.AutoEllipsis = true;
        this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.nameLabel.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Bold);
        this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
        this.nameLabel.Name = "nameLabel";
        this.nameLabel.Text = "Пациент";
        this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // statusLabel (tag: in the norm / outside the norm)
        //
        this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.statusLabel.AutoSize = true;
        this.statusLabel.BackColor = System.Drawing.Color.FromArgb(226, 236, 232);
        this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
        this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(30, 90, 74);
        this.statusLabel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.statusLabel.Name = "statusLabel";
        this.statusLabel.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
        this.statusLabel.Text = "В норме";
        //
        // subLabel
        //
        this.subLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.subLabel.Font = new System.Drawing.Font("Consolas", 9.75F);
        this.subLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.subLabel.Margin = new System.Windows.Forms.Padding(0);
        this.subLabel.Name = "subLabel";
        this.subLabel.Text = "";
        this.subLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        //
        // actions
        //
        this.actions.AutoSize = true;
        this.actions.Controls.Add(this.editButton);
        this.actions.Controls.Add(this.archiveButton);
        this.actions.Controls.Add(this.deleteButton);
        this.actions.Dock = System.Windows.Forms.DockStyle.Fill;
        this.actions.Margin = new System.Windows.Forms.Padding(0, 4, 0, 6);
        this.actions.Name = "actions";
        //
        // editButton
        //
        this.editButton.AutoSize = true;
        this.editButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
        this.editButton.MinimumSize = new System.Drawing.Size(96, 34);
        this.editButton.Name = "editButton";
        this.editButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
        this.editButton.Text = "Изменить данные";
        this.editButton.Click += new System.EventHandler(this.EditPatientClick);
        //
        // archiveButton
        //
        this.archiveButton.AutoSize = true;
        this.archiveButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
        this.archiveButton.MinimumSize = new System.Drawing.Size(96, 34);
        this.archiveButton.Name = "archiveButton";
        this.archiveButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
        this.archiveButton.Text = "В архив";
        this.archiveButton.Click += new System.EventHandler(this.ArchiveClick);
        //
        // deleteButton
        //
        this.deleteButton.AutoSize = true;
        this.deleteButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
        this.deleteButton.MinimumSize = new System.Drawing.Size(96, 34);
        this.deleteButton.Name = "deleteButton";
        this.deleteButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
        this.deleteButton.Text = "Удалить";
        this.deleteButton.Tone = MedTest.Desktop.ButtonTone.Danger;
        this.deleteButton.Click += new System.EventHandler(this.DeleteClick);
        //
        // tabs
        //
        this.tabs.Controls.Add(this.infoTab);
        this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabs.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        this.tabs.Margin = new System.Windows.Forms.Padding(0);
        this.tabs.Name = "cardTabs";
        //
        // latest columns
        //
        //
        // history columns
        //
        //
        // infoTab
        //
        this.infoTab.BackColor = System.Drawing.Color.White;
        this.infoTab.Controls.Add(this.infoTable);
        this.infoTab.Name = "infoTab";
        this.infoTab.Padding = new System.Windows.Forms.Padding(4, 10, 8, 4);
        this.infoTab.Text = "Сведения";
        //
        // infoTable
        //
        this.infoTable.ColumnCount = 2;
        this.infoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
        this.infoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.infoTable.Controls.Add(this.cardCaption, 0, 0);
        this.infoTable.Controls.Add(this.cardValue, 1, 0);
        this.infoTable.Controls.Add(this.birthCaption, 0, 1);
        this.infoTable.Controls.Add(this.birthValue, 1, 1);
        this.infoTable.Controls.Add(this.sexCaption, 0, 2);
        this.infoTable.Controls.Add(this.sexValue, 1, 2);
        this.infoTable.Controls.Add(this.phoneCaption, 0, 3);
        this.infoTable.Controls.Add(this.phoneValue, 1, 3);
        this.infoTable.Controls.Add(this.stateCaption, 0, 4);
        this.infoTable.Controls.Add(this.stateValue, 1, 4);
        this.infoTable.Controls.Add(this.noteCaption, 0, 5);
        this.infoTable.Controls.Add(this.noteValue, 1, 5);
        this.infoTable.Dock = System.Windows.Forms.DockStyle.Fill;
        this.infoTable.Name = "infoTable";
        this.infoTable.RowCount = 6;
        this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // info captions and values
        //
        this.cardCaption.Dock = System.Windows.Forms.DockStyle.Fill; this.cardCaption.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100); this.cardCaption.Name = "cardCaption"; this.cardCaption.Text = "Номер карты";
        this.birthCaption.Dock = System.Windows.Forms.DockStyle.Fill; this.birthCaption.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100); this.birthCaption.Name = "birthCaption"; this.birthCaption.Text = "Дата рождения";
        this.sexCaption.Dock = System.Windows.Forms.DockStyle.Fill; this.sexCaption.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100); this.sexCaption.Name = "sexCaption"; this.sexCaption.Text = "Пол";
        this.phoneCaption.Dock = System.Windows.Forms.DockStyle.Fill; this.phoneCaption.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100); this.phoneCaption.Name = "phoneCaption"; this.phoneCaption.Text = "Телефон";
        this.stateCaption.Dock = System.Windows.Forms.DockStyle.Fill; this.stateCaption.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100); this.stateCaption.Name = "stateCaption"; this.stateCaption.Text = "Состояние";
        this.noteCaption.Dock = System.Windows.Forms.DockStyle.Fill; this.noteCaption.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100); this.noteCaption.Name = "noteCaption"; this.noteCaption.Text = "Примечание";
        this.cardValue.Dock = System.Windows.Forms.DockStyle.Fill; this.cardValue.Font = new System.Drawing.Font("Consolas", 9.75F); this.cardValue.Name = "cardValue";
        this.birthValue.Dock = System.Windows.Forms.DockStyle.Fill; this.birthValue.Name = "birthValue";
        this.sexValue.Dock = System.Windows.Forms.DockStyle.Fill; this.sexValue.Name = "sexValue";
        this.phoneValue.Dock = System.Windows.Forms.DockStyle.Fill; this.phoneValue.Name = "phoneValue";
        this.stateValue.Dock = System.Windows.Forms.DockStyle.Fill; this.stateValue.Name = "stateValue";
        this.noteValue.Dock = System.Windows.Forms.DockStyle.Fill; this.noteValue.Name = "noteValue";
        //
        // footerLabel
        //
        this.footerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.footerLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.footerLabel.Name = "footerLabel";
        this.footerLabel.Text = "";
        this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // PatientCard
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.Name = "PatientCard";
        this.Size = new System.Drawing.Size(660, 760);
        this.infoTable.ResumeLayout(false);
        this.infoTab.ResumeLayout(false);
        this.tabs.ResumeLayout(false);
        this.actions.ResumeLayout(false);
        this.actions.PerformLayout();
        this.headingPanel.ResumeLayout(false);
        this.headingPanel.PerformLayout();
        this.layout.ResumeLayout(false);
        this.layout.PerformLayout();
        this.ResumeLayout(false);
    }
}
