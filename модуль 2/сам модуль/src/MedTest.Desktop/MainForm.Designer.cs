#nullable enable
namespace MedTest.Desktop;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!, headerLayout = null!, userBlock = null!, contentLayout = null!, titleRow = null!, chipsRow = null!, bodyLayout = null!;
    private System.Windows.Forms.Panel headerPanel = null!, searchSurface = null!;
    private BrandMark brandMark = null!;
    private System.Windows.Forms.FlowLayoutPanel navigationPanel = null!, actionBar = null!, filterChips = null!;
    private UiButton navPatients = null!, navStaff = null!, logoutButton = null!, refreshButton = null!, openButton = null!, addButton = null!;
    private FilterChip chipAll = null!, chipDeviation = null!, chipNoExam = null!, chipArchive = null!;
    private System.Windows.Forms.TextBox searchBox = null!;
    private System.Windows.Forms.Label avatarLabel = null!, userLabel = null!, roleLabel = null!, headingLabel = null!, recordCountLabel = null!, messageLabel = null!;
    private UiPanel gridFrame = null!, dossierPanel = null!;
    private System.Windows.Forms.DataGridView patientsGrid = null!;
    private System.Windows.Forms.DataGridViewTextBoxColumn cardColumn = null!, personColumn = null!, ageColumn = null!, sexColumn = null!, lastExamColumn = null!, stateColumn = null!;
    private System.Windows.Forms.DataGridView staffGrid = null!;
    private System.Windows.Forms.DataGridViewTextBoxColumn staffLoginColumn = null!, staffNameColumn = null!, staffRoleColumn = null!, staffStateColumn = null!;
    private PatientCard patientCard = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.headerPanel = new System.Windows.Forms.Panel();
        this.headerLayout = new System.Windows.Forms.TableLayoutPanel();
        this.brandMark = new MedTest.Desktop.BrandMark();
        this.navigationPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.navPatients = new MedTest.Desktop.UiButton();
        this.navStaff = new MedTest.Desktop.UiButton();
        this.searchSurface = new System.Windows.Forms.Panel();
        this.searchBox = new System.Windows.Forms.TextBox();
        this.avatarLabel = new System.Windows.Forms.Label();
        this.userBlock = new System.Windows.Forms.TableLayoutPanel();
        this.userLabel = new System.Windows.Forms.Label();
        this.roleLabel = new System.Windows.Forms.Label();
        this.logoutButton = new MedTest.Desktop.UiButton();
        this.contentLayout = new System.Windows.Forms.TableLayoutPanel();
        this.titleRow = new System.Windows.Forms.TableLayoutPanel();
        this.headingLabel = new System.Windows.Forms.Label();
        this.recordCountLabel = new System.Windows.Forms.Label();
        this.actionBar = new System.Windows.Forms.FlowLayoutPanel();
        this.refreshButton = new MedTest.Desktop.UiButton();
        this.openButton = new MedTest.Desktop.UiButton();
        this.addButton = new MedTest.Desktop.UiButton();
        this.chipsRow = new System.Windows.Forms.TableLayoutPanel();
        this.filterChips = new System.Windows.Forms.FlowLayoutPanel();
        this.chipAll = new MedTest.Desktop.FilterChip();
        this.chipDeviation = new MedTest.Desktop.FilterChip();
        this.chipNoExam = new MedTest.Desktop.FilterChip();
        this.chipArchive = new MedTest.Desktop.FilterChip();
        this.bodyLayout = new System.Windows.Forms.TableLayoutPanel();
        this.gridFrame = new MedTest.Desktop.UiPanel();
        this.patientsGrid = new System.Windows.Forms.DataGridView();
        this.cardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.personColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.sexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.lastExamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.stateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.staffGrid = new System.Windows.Forms.DataGridView();
        this.staffLoginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.staffNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.staffRoleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.staffStateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dossierPanel = new MedTest.Desktop.UiPanel();
        this.patientCard = new MedTest.Desktop.PatientCard();
        this.messageLabel = new System.Windows.Forms.Label();
        this.layout.SuspendLayout();
        this.headerPanel.SuspendLayout();
        this.headerLayout.SuspendLayout();
        this.navigationPanel.SuspendLayout();
        this.searchSurface.SuspendLayout();
        this.userBlock.SuspendLayout();
        this.contentLayout.SuspendLayout();
        this.titleRow.SuspendLayout();
        this.actionBar.SuspendLayout();
        this.chipsRow.SuspendLayout();
        this.filterChips.SuspendLayout();
        this.bodyLayout.SuspendLayout();
        this.gridFrame.SuspendLayout();
        this.dossierPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.patientsGrid)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.staffGrid)).BeginInit();
        this.SuspendLayout();
        //
        // layout: top bar, working area, status line
        //
        this.layout.BackColor = System.Drawing.Color.FromArgb(243, 245, 244);
        this.layout.ColumnCount = 1;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.Controls.Add(this.headerPanel, 0, 0);
        this.layout.Controls.Add(this.contentLayout, 0, 1);
        this.layout.Controls.Add(this.messageLabel, 0, 2);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Margin = new System.Windows.Forms.Padding(0);
        this.layout.Name = "layout";
        this.layout.RowCount = 3;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        //
        // headerPanel (dark top bar)
        //
        this.headerPanel.BackColor = System.Drawing.Color.FromArgb(16, 34, 28);
        this.headerPanel.Controls.Add(this.headerLayout);
        this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Padding = new System.Windows.Forms.Padding(16, 0, 12, 0);
        //
        // headerLayout
        //
        this.headerLayout.BackColor = System.Drawing.Color.FromArgb(16, 34, 28);
        this.headerLayout.ColumnCount = 6;
        this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
        this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
        this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.headerLayout.Controls.Add(this.brandMark, 0, 0);
        this.headerLayout.Controls.Add(this.navigationPanel, 1, 0);
        this.headerLayout.Controls.Add(this.searchSurface, 2, 0);
        this.headerLayout.Controls.Add(this.avatarLabel, 3, 0);
        this.headerLayout.Controls.Add(this.userBlock, 4, 0);
        this.headerLayout.Controls.Add(this.logoutButton, 5, 0);
        this.headerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.headerLayout.Margin = new System.Windows.Forms.Padding(0);
        this.headerLayout.Name = "headerLayout";
        this.headerLayout.RowCount = 1;
        this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // brandMark
        //
        this.brandMark.BackColor = System.Drawing.Color.FromArgb(16, 34, 28);
        this.brandMark.Dock = System.Windows.Forms.DockStyle.Fill;
        this.brandMark.Font = new System.Drawing.Font("Georgia", 13F);
        this.brandMark.ForeColor = System.Drawing.Color.FromArgb(233, 241, 238);
        this.brandMark.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
        this.brandMark.Name = "brandMark";
        this.brandMark.Text = "МедТест";
        //
        // navigationPanel (Tag = section key used by MainForm)
        //
        this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(16, 34, 28);
        this.navigationPanel.Controls.Add(this.navPatients);
        this.navigationPanel.Controls.Add(this.navStaff);
        this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.navigationPanel.Margin = new System.Windows.Forms.Padding(0);
        this.navigationPanel.Name = "navigationPanel";
        this.navigationPanel.Padding = new System.Windows.Forms.Padding(4, 9, 0, 0);
        this.navigationPanel.WrapContents = false;
        //
        // navPatients
        //
        this.navPatients.AutoSize = true;
        this.navPatients.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        this.navPatients.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
        this.navPatients.MinimumSize = new System.Drawing.Size(84, 34);
        this.navPatients.Name = "navPatients";
        this.navPatients.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
        this.navPatients.Tag = "Пациенты";
        this.navPatients.Text = "Пациенты";
        this.navPatients.Tone = MedTest.Desktop.ButtonTone.Tab;
        this.navPatients.Click += new System.EventHandler(this.NavigationClick);
        //
        // navStaff
        //
        this.navStaff.AutoSize = true;
        this.navStaff.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        this.navStaff.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
        this.navStaff.MinimumSize = new System.Drawing.Size(84, 34);
        this.navStaff.Name = "navStaff";
        this.navStaff.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
        this.navStaff.Tag = "Сотрудники";
        this.navStaff.Text = "Сотрудники";
        this.navStaff.Tone = MedTest.Desktop.ButtonTone.Tab;
        this.navStaff.Click += new System.EventHandler(this.NavigationClick);
        //
        // searchSurface
        //
        this.searchSurface.BackColor = System.Drawing.Color.FromArgb(26, 50, 41);
        this.searchSurface.Controls.Add(this.searchBox);
        this.searchSurface.Dock = System.Windows.Forms.DockStyle.Fill;
        this.searchSurface.Margin = new System.Windows.Forms.Padding(8, 9, 10, 9);
        this.searchSurface.Name = "searchSurface";
        this.searchSurface.Padding = new System.Windows.Forms.Padding(10, 7, 10, 0);
        //
        // searchBox
        //
        this.searchBox.BackColor = System.Drawing.Color.FromArgb(26, 50, 41);
        this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.searchBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.searchBox.ForeColor = System.Drawing.Color.FromArgb(233, 241, 238);
        this.searchBox.Name = "searchBox";
        this.searchBox.PlaceholderText = "ФИО, номер карты или телефон";
        this.searchBox.TextChanged += new System.EventHandler(this.SearchChanged);
        //
        // avatarLabel
        //
        this.avatarLabel.BackColor = System.Drawing.Color.FromArgb(201, 168, 106);
        this.avatarLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
        this.avatarLabel.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.avatarLabel.Margin = new System.Windows.Forms.Padding(0, 11, 8, 0);
        this.avatarLabel.Name = "avatarLabel";
        this.avatarLabel.Size = new System.Drawing.Size(30, 30);
        this.avatarLabel.Text = "?";
        this.avatarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // userBlock
        //
        this.userBlock.AutoSize = true;
        this.userBlock.ColumnCount = 1;
        this.userBlock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.userBlock.Controls.Add(this.userLabel, 0, 0);
        this.userBlock.Controls.Add(this.roleLabel, 0, 1);
        this.userBlock.Margin = new System.Windows.Forms.Padding(0, 8, 10, 0);
        this.userBlock.Name = "userBlock";
        this.userBlock.RowCount = 2;
        this.userBlock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.userBlock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        //
        // userLabel
        //
        this.userLabel.AutoSize = true;
        this.userLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.userLabel.ForeColor = System.Drawing.Color.FromArgb(233, 241, 238);
        this.userLabel.Margin = new System.Windows.Forms.Padding(0);
        this.userLabel.Name = "userLabel";
        this.userLabel.Text = "Рабочее место";
        //
        // roleLabel
        //
        this.roleLabel.AutoSize = true;
        this.roleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        this.roleLabel.ForeColor = System.Drawing.Color.FromArgb(147, 173, 164);
        this.roleLabel.Margin = new System.Windows.Forms.Padding(0);
        this.roleLabel.Name = "roleLabel";
        this.roleLabel.Text = "";
        //
        // logoutButton
        //
        this.logoutButton.AccessibleName = "Выйти";
        this.logoutButton.AutoSize = true;
        this.logoutButton.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
        this.logoutButton.MinimumSize = new System.Drawing.Size(0, 34);
        this.logoutButton.Name = "logoutButton";
        this.logoutButton.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
        this.logoutButton.Text = "Выйти";
        this.logoutButton.Tone = MedTest.Desktop.ButtonTone.OnDark;
        this.logoutButton.Click += new System.EventHandler(this.LogoutClick);
        //
        // contentLayout: title, quick filters, table with the card
        //
        this.contentLayout.ColumnCount = 1;
        this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.contentLayout.Controls.Add(this.titleRow, 0, 0);
        this.contentLayout.Controls.Add(this.chipsRow, 0, 1);
        this.contentLayout.Controls.Add(this.bodyLayout, 0, 2);
        this.contentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.contentLayout.Margin = new System.Windows.Forms.Padding(0);
        this.contentLayout.Name = "contentLayout";
        this.contentLayout.Padding = new System.Windows.Forms.Padding(16, 8, 16, 0);
        this.contentLayout.RowCount = 3;
        this.contentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
        this.contentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
        this.contentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // titleRow
        //
        this.titleRow.ColumnCount = 3;
        this.titleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.titleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.titleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        this.titleRow.Controls.Add(this.headingLabel, 0, 0);
        this.titleRow.Controls.Add(this.recordCountLabel, 1, 0);
        this.titleRow.Controls.Add(this.actionBar, 2, 0);
        this.titleRow.Dock = System.Windows.Forms.DockStyle.Fill;
        this.titleRow.Margin = new System.Windows.Forms.Padding(0);
        this.titleRow.Name = "titleRow";
        this.titleRow.RowCount = 1;
        this.titleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // headingLabel
        //
        this.headingLabel.AutoSize = true;
        this.headingLabel.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
        this.headingLabel.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.headingLabel.Margin = new System.Windows.Forms.Padding(0, 10, 10, 0);
        this.headingLabel.Name = "headingLabel";
        this.headingLabel.Text = "Пациенты";
        //
        // recordCountLabel
        //
        this.recordCountLabel.AutoSize = true;
        this.recordCountLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.recordCountLabel.Margin = new System.Windows.Forms.Padding(0, 17, 0, 0);
        this.recordCountLabel.Name = "recordCountLabel";
        this.recordCountLabel.Text = "";
        //
        // actionBar
        //
        this.actionBar.AutoSize = true;
        this.actionBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.actionBar.Controls.Add(this.refreshButton);
        this.actionBar.Controls.Add(this.openButton);
        this.actionBar.Controls.Add(this.addButton);
        this.actionBar.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
        this.actionBar.Name = "actionBar";
        this.actionBar.WrapContents = false;
        //
        // refreshButton
        //
        this.refreshButton.AutoSize = true;
        this.refreshButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.refreshButton.MinimumSize = new System.Drawing.Size(96, 34);
        this.refreshButton.Name = "refreshButton";
        this.refreshButton.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
        this.refreshButton.Text = "Обновить";
        this.refreshButton.Click += new System.EventHandler(this.RefreshClick);
        //
        // openButton
        //
        this.openButton.AutoSize = true;
        this.openButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.openButton.MinimumSize = new System.Drawing.Size(96, 34);
        this.openButton.Name = "openButton";
        this.openButton.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
        this.openButton.Text = "Открыть карту";
        this.openButton.Click += new System.EventHandler(this.OpenClick);
        //
        // addButton
        //
        this.addButton.AutoSize = true;
        this.addButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.addButton.MinimumSize = new System.Drawing.Size(96, 34);
        this.addButton.Name = "addButton";
        this.addButton.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
        this.addButton.Text = "Добавить пациента";
        this.addButton.Tone = MedTest.Desktop.ButtonTone.Primary;
        this.addButton.Click += new System.EventHandler(this.AddClick);
        //
        // chipsRow
        //
        this.chipsRow.ColumnCount = 1;
        this.chipsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.chipsRow.Controls.Add(this.filterChips, 0, 0);
        this.chipsRow.Dock = System.Windows.Forms.DockStyle.Fill;
        this.chipsRow.Margin = new System.Windows.Forms.Padding(0);
        this.chipsRow.Name = "chipsRow";
        this.chipsRow.RowCount = 1;
        this.chipsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // filterChips (Tag = quick filter key)
        //
        this.filterChips.AutoSize = true;
        this.filterChips.Controls.Add(this.chipAll);
        this.filterChips.Controls.Add(this.chipDeviation);
        this.filterChips.Controls.Add(this.chipNoExam);
        this.filterChips.Controls.Add(this.chipArchive);
        this.filterChips.Dock = System.Windows.Forms.DockStyle.Fill;
        this.filterChips.Margin = new System.Windows.Forms.Padding(0);
        this.filterChips.Name = "filterChips";
        this.filterChips.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
        this.filterChips.WrapContents = false;
        //
        // chipAll
        //
        this.chipAll.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.chipAll.Name = "chipAll";
        this.chipAll.Size = new System.Drawing.Size(70, 30);
        this.chipAll.Tag = "all";
        this.chipAll.Text = "Все";
        this.chipAll.Click += new System.EventHandler(this.ChipClick);
        //
        // chipDeviation
        //
        this.chipDeviation.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.chipDeviation.Name = "chipDeviation";
        this.chipDeviation.Size = new System.Drawing.Size(150, 30);
        this.chipDeviation.Tag = "deviation";
        this.chipDeviation.Text = "С отклонениями";
        this.chipDeviation.Warn = true;
        this.chipDeviation.Click += new System.EventHandler(this.ChipClick);
        //
        // chipNoExam
        //
        this.chipNoExam.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.chipNoExam.Name = "chipNoExam";
        this.chipNoExam.Size = new System.Drawing.Size(160, 30);
        this.chipNoExam.Tag = "noexam";
        this.chipNoExam.Text = "Без обследований";
        this.chipNoExam.Click += new System.EventHandler(this.ChipClick);
        //
        // chipArchive
        //
        this.chipArchive.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
        this.chipArchive.Name = "chipArchive";
        this.chipArchive.Size = new System.Drawing.Size(90, 30);
        this.chipArchive.Tag = "archive";
        this.chipArchive.Text = "Архив";
        this.chipArchive.Click += new System.EventHandler(this.ChipClick);
        //
        // bodyLayout: table on the left, card or chart on the right
        //
        this.bodyLayout.ColumnCount = 2;
        this.bodyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.bodyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 680F));
        this.bodyLayout.Controls.Add(this.gridFrame, 0, 0);
        this.bodyLayout.Controls.Add(this.dossierPanel, 1, 0);
        this.bodyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.bodyLayout.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
        this.bodyLayout.Name = "bodyLayout";
        this.bodyLayout.RowCount = 1;
        this.bodyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // gridFrame
        //
        this.gridFrame.Controls.Add(this.patientsGrid);
        this.gridFrame.Controls.Add(this.staffGrid);
        this.gridFrame.Dock = System.Windows.Forms.DockStyle.Fill;
        this.gridFrame.Margin = new System.Windows.Forms.Padding(0);
        this.gridFrame.Name = "gridFrame";
        //
        // patientsGrid (section «Пациенты»)
        //
        this.patientsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.cardColumn, this.personColumn, this.ageColumn, this.sexColumn, this.lastExamColumn, this.stateColumn });
        this.patientsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        this.patientsGrid.Margin = new System.Windows.Forms.Padding(0);
        this.patientsGrid.Name = "patientsGrid";
        this.patientsGrid.TabIndex = 0;
        this.patientsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDoubleClick);
        this.patientsGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PatientsCellPainting);
        this.patientsGrid.CurrentCellChanged += new System.EventHandler(this.RecordsSelectionChanged);
        this.patientsGrid.SelectionChanged += new System.EventHandler(this.RecordsSelectionChanged);
        //
        // cardColumn
        //
        this.cardColumn.FillWeight = 11F;
        this.cardColumn.HeaderText = "Карта";
        this.cardColumn.Name = "cardColumn";
        this.cardColumn.ReadOnly = true;
        //
        // personColumn
        //
        this.personColumn.FillWeight = 31F;
        this.personColumn.HeaderText = "Пациент";
        this.personColumn.Name = "personColumn";
        this.personColumn.ReadOnly = true;
        //
        // ageColumn
        //
        this.ageColumn.FillWeight = 9F;
        this.ageColumn.HeaderText = "Возраст";
        this.ageColumn.Name = "ageColumn";
        this.ageColumn.ReadOnly = true;
        //
        // sexColumn
        //
        this.sexColumn.FillWeight = 7F;
        this.sexColumn.HeaderText = "Пол";
        this.sexColumn.Name = "sexColumn";
        this.sexColumn.ReadOnly = true;
        //
        // lastExamColumn
        //
        this.lastExamColumn.FillWeight = 20F;
        this.lastExamColumn.HeaderText = "Последний осмотр";
        this.lastExamColumn.Name = "lastExamColumn";
        this.lastExamColumn.ReadOnly = true;
        //
        // stateColumn
        //
        this.stateColumn.FillWeight = 22F;
        this.stateColumn.HeaderText = "Состояние";
        this.stateColumn.Name = "stateColumn";
        this.stateColumn.ReadOnly = true;
        //
        // staffGrid (section «Сотрудники»)
        //
        this.staffGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.staffLoginColumn, this.staffNameColumn, this.staffRoleColumn, this.staffStateColumn });
        this.staffGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        this.staffGrid.Margin = new System.Windows.Forms.Padding(0);
        this.staffGrid.Name = "staffGrid";
        this.staffGrid.TabIndex = 3;
        this.staffGrid.Visible = false;
        this.staffGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDoubleClick);
        this.staffGrid.CurrentCellChanged += new System.EventHandler(this.RecordsSelectionChanged);
        this.staffGrid.SelectionChanged += new System.EventHandler(this.RecordsSelectionChanged);
        //
        // staffLoginColumn
        //
        this.staffLoginColumn.FillWeight = 18F;
        this.staffLoginColumn.HeaderText = "Логин";
        this.staffLoginColumn.Name = "staffLoginColumn";
        this.staffLoginColumn.ReadOnly = true;
        //
        // staffNameColumn
        //
        this.staffNameColumn.FillWeight = 40F;
        this.staffNameColumn.HeaderText = "ФИО";
        this.staffNameColumn.Name = "staffNameColumn";
        this.staffNameColumn.ReadOnly = true;
        //
        // staffRoleColumn
        //
        this.staffRoleColumn.FillWeight = 20F;
        this.staffRoleColumn.HeaderText = "Роль";
        this.staffRoleColumn.Name = "staffRoleColumn";
        this.staffRoleColumn.ReadOnly = true;
        //
        // staffStateColumn
        //
        this.staffStateColumn.FillWeight = 20F;
        this.staffStateColumn.HeaderText = "Состояние";
        this.staffStateColumn.Name = "staffStateColumn";
        this.staffStateColumn.ReadOnly = true;
        //
        // dossierPanel (patient card or statistics chart)
        //
        this.dossierPanel.Controls.Add(this.patientCard);
        this.dossierPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dossierPanel.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
        this.dossierPanel.Name = "dossierPanel";
        //
        // patientCard
        //
        this.patientCard.Dock = System.Windows.Forms.DockStyle.Fill;
        this.patientCard.Margin = new System.Windows.Forms.Padding(0);
        this.patientCard.Name = "patientCard";
        this.patientCard.Changed += new System.EventHandler(this.CardChanged);
        //
        // messageLabel (status line: errors and action results only)
        //
        this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.messageLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.messageLabel.Margin = new System.Windows.Forms.Padding(0);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
        this.messageLabel.Text = "";
        this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.FromArgb(243, 245, 244);
        this.ClientSize = new System.Drawing.Size(1584, 961);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.KeyPreview = true;
        this.MinimumSize = new System.Drawing.Size(1180, 700);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "МедТест";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainKeyDown);
        this.Shown += new System.EventHandler(this.MainShown);
        ((System.ComponentModel.ISupportInitialize)(this.patientsGrid)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.staffGrid)).EndInit();
        this.dossierPanel.ResumeLayout(false);
        this.gridFrame.ResumeLayout(false);
        this.bodyLayout.ResumeLayout(false);
        this.filterChips.ResumeLayout(false);
        this.filterChips.PerformLayout();
        this.chipsRow.ResumeLayout(false);
        this.actionBar.ResumeLayout(false);
        this.actionBar.PerformLayout();
        this.titleRow.ResumeLayout(false);
        this.titleRow.PerformLayout();
        this.contentLayout.ResumeLayout(false);
        this.userBlock.ResumeLayout(false);
        this.userBlock.PerformLayout();
        this.searchSurface.ResumeLayout(false);
        this.searchSurface.PerformLayout();
        this.navigationPanel.ResumeLayout(false);
        this.navigationPanel.PerformLayout();
        this.headerLayout.ResumeLayout(false);
        this.headerLayout.PerformLayout();
        this.headerPanel.ResumeLayout(false);
        this.layout.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
