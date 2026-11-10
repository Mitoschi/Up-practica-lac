using MedTest.Core;
namespace MedTest.Desktop;

/// <summary>Palette, fonts and shared styling of the spruce desktop design.</summary>
public static class Theme
{
    // Dark top bar and dark panels.
    public static readonly Color TopBar = Color.FromArgb(16, 34, 28);
    public static readonly Color DarkPanel = Color.FromArgb(22, 46, 38);
    public static readonly Color DarkLine = Color.FromArgb(44, 70, 61);
    public static readonly Color DarkButtonLine = Color.FromArgb(74, 94, 87);
    public static readonly Color DarkText = Color.FromArgb(233, 241, 238);
    public static readonly Color DarkMuted = Color.FromArgb(147, 173, 164);
    public static readonly Color TopText = Color.FromArgb(185, 204, 197);
    public static readonly Color SearchFill = Color.FromArgb(26, 50, 41);
    // Light working area.
    public static readonly Color Canvas = Color.FromArgb(243, 245, 244);
    public static readonly Color Surface = Color.White;
    public static readonly Color HeaderFill = Color.FromArgb(244, 246, 245);
    public static readonly Color Line = Color.FromArgb(217, 225, 222);
    public static readonly Color RowLine = Color.FromArgb(237, 240, 238);
    public static readonly Color StrongLine = Color.FromArgb(181, 195, 190);
    public static readonly Color Ink = Color.FromArgb(17, 33, 28);
    public static readonly Color Muted = Color.FromArgb(91, 105, 100);
    public static readonly Color Spruce = Color.FromArgb(30, 90, 74);
    public static readonly Color SpruceHover = Color.FromArgb(23, 72, 59);
    public static readonly Color SprucePressed = Color.FromArgb(18, 58, 48);
    public static readonly Color Brass = Color.FromArgb(201, 168, 106);
    public static readonly Color BrassHover = Color.FromArgb(186, 152, 90);
    public static readonly Color Rust = Color.FromArgb(181, 82, 62);
    public static readonly Color Selected = Color.FromArgb(226, 236, 232);
    public static readonly Color Hover = Color.FromArgb(236, 241, 239);
    public static readonly Color Expanded = Color.FromArgb(251, 248, 241);
    public static readonly Color[] PersonColors =
    [
        Color.FromArgb(156, 90, 71), Color.FromArgb(46, 107, 90), Color.FromArgb(74, 106, 134),
        Color.FromArgb(118, 88, 110), Color.FromArgb(168, 138, 79)
    ];

    public const string SerifFamily = "Georgia", UiFamily = "Segoe UI", MonoFamily = "Consolas";
    public static readonly Font CodeFont = new(MonoFamily, 9.5F);
    public static readonly Font TagFont = new(UiFamily, 8.25F, FontStyle.Bold);
    public static readonly Font CellFont = new(UiFamily, 10F);
    public static readonly Font CellBoldFont = new(UiFamily, 10F, FontStyle.Bold);
    public static readonly Font HeaderFont = new(UiFamily, 8.75F, FontStyle.Bold);

    /// <summary>Short status label with its tag colours, as used in tables.</summary>
    public readonly record struct StatusTag(string Text, Color Back, Color Fore);
    private static readonly Color NeutralBack = Color.FromArgb(236, 238, 235), NeutralFore = Color.FromArgb(92, 105, 101);
    private static readonly Color AboveBack = Color.FromArgb(246, 222, 216), AboveTagFore = Color.FromArgb(158, 58, 38);
    private static readonly Color NormalBack = Color.FromArgb(226, 236, 232), NormalFore = Color.FromArgb(30, 90, 74);
    private static readonly Color BelowBack = Color.FromArgb(225, 233, 241), BelowTagFore = Color.FromArgb(45, 90, 133);

    public static readonly Color AboveFore = Color.FromArgb(158, 58, 38), BelowFore = Color.FromArgb(45, 90, 133);

    /// <summary>Tag of a value against its reference range: spruce for the norm, rust above, blue below.</summary>
    public static StatusTag Status(RefStatus status) => status switch
    {
        RefStatus.Above => new("Выше нормы", AboveBack, AboveTagFore),
        RefStatus.Below => new("Ниже нормы", BelowBack, BelowTagFore),
        _ => new("Норма", NormalBack, NormalFore)
    };

    /// <summary>Tag of a patient row: how many latest values are outside the norm.</summary>
    public static StatusTag Deviations(int count, int exams) =>
        exams == 0 ? new("Нет обследований", NeutralBack, NeutralFore)
        : count == 0 ? new("В норме", NormalBack, NormalFore)
        : new("Вне нормы: " + count, AboveBack, AboveTagFore);

    public static StatusTag Neutral(string text) => new(text, NeutralBack, NeutralFore);

    /// <summary>Stable colour of a patient square, by patient id.</summary>
    public static Color PersonColor(int id) => PersonColors[Math.Abs(id) % PersonColors.Length];

    public static string Initials(string? name)
    {
        var parts = (name ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var letters = parts.Take(2).Select(p => char.ToUpperInvariant(p[0])).ToArray();
        return letters.Length == 0 ? "?" : new string(letters);
    }

    /// <summary>Applies the design to ordinary controls without overriding colours set explicitly in the Designer.</summary>
    public static void Apply(Control root)
    {
        if (root is Form form && form.ForeColor == SystemColors.ControlText) form.ForeColor = Ink;
        foreach (Control control in root.Controls)
        {
            switch (control)
            {
                case UiButton:
                    break;
                case Button button:
                    button.FlatStyle = FlatStyle.Flat; button.FlatAppearance.BorderSize = 1; button.FlatAppearance.BorderColor = StrongLine;
                    button.FlatAppearance.MouseOverBackColor = Hover; button.FlatAppearance.MouseDownBackColor = Selected;
                    button.BackColor = Surface; button.ForeColor = Ink; button.UseVisualStyleBackColor = false;
                    break;
                case TextBox text:
                    if (text.BackColor == SystemColors.Window || text.BackColor == SystemColors.Control) text.BackColor = text.ReadOnly ? Canvas : Surface;
                    if (text.ForeColor == SystemColors.WindowText) text.ForeColor = Ink;
                    break;
                case ComboBox combo:
                    combo.FlatStyle = FlatStyle.Flat;
                    if (combo.BackColor == SystemColors.Window) combo.BackColor = Surface;
                    if (combo.ForeColor == SystemColors.WindowText) combo.ForeColor = Ink;
                    break;
                case DataGridView grid:
                    Table(grid, grid.Name is "patientsGrid" or "statsGrid" or "indicatorsGrid" or "staffGrid" or "valuesGrid" or "latestGrid" or "historyGrid");
                    break;
                case TabPage page:
                    if (page.BackColor == SystemColors.Control || page.BackColor == Color.Transparent) page.BackColor = Surface;
                    page.UseVisualStyleBackColor = false;
                    break;
            }
            Apply(control);
        }
    }

    /// <summary>Readable table: white rows, thin horizontal rules, muted header. Dense tables keep one line per row.</summary>
    public static void Table(DataGridView grid, bool dense)
    {
        grid.BackgroundColor = Surface; grid.BorderStyle = BorderStyle.None; grid.EnableHeadersVisualStyles = false;
        var header = grid.ColumnHeadersDefaultCellStyle;
        header.BackColor = HeaderFill; header.ForeColor = Muted; header.SelectionBackColor = HeaderFill; header.SelectionForeColor = Muted;
        header.Font = HeaderFont; header.Padding = new Padding(8, 0, 8, 0); header.Alignment = DataGridViewContentAlignment.MiddleLeft; header.WrapMode = DataGridViewTriState.False;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        grid.ColumnHeadersHeight = 34; grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        var cell = grid.DefaultCellStyle;
        cell.Font = CellFont; cell.BackColor = Surface; cell.ForeColor = Ink; cell.SelectionBackColor = Selected; cell.SelectionForeColor = Ink;
        cell.Padding = new Padding(8, 0, 8, 0); cell.Alignment = DataGridViewContentAlignment.MiddleLeft;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Surface;
        grid.GridColor = RowLine; grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.RowHeadersVisible = false; grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false; grid.AllowUserToResizeRows = false;
        grid.ReadOnly = true; grid.MultiSelect = false; grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        if (dense)
        {
            cell.WrapMode = DataGridViewTriState.False; grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.RowTemplate.Height = 36; grid.RowTemplate.MinimumHeight = 20;
        }
        else
        {
            cell.WrapMode = DataGridViewTriState.True; grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            grid.RowTemplate.Height = 34; grid.RowTemplate.MinimumHeight = 34;
            cell.Padding = new Padding(8, 6, 8, 6);
        }
    }

    public static void Navigation(Button button, bool active)
    {
        if (button is not UiButton ui) return;
        ui.Tone = ButtonTone.Tab; ui.Active = active;
    }
}
