using System.ComponentModel;
namespace MedTest.Desktop;

/// <summary>White container with a 1px border. No shadow, no gradient.</summary>
public class UiPanel : Panel
{
    private Color borderColor = Theme.Line;
    [DefaultValue(typeof(Color), "217, 225, 222")] public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }
    public UiPanel()
    {
        SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        BackColor = Theme.Surface; Padding = new Padding(1);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (borderColor.A == 0 || Width < 2 || Height < 2) return;
        using var pen = new Pen(borderColor);
        e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
    }
}

/// <summary>Flat tab strip: muted captions, the selected one in ink with a spruce underline.</summary>
public class UiTabs : TabControl
{
    public UiTabs()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        DrawMode = TabDrawMode.OwnerDrawFixed; ItemSize = new Size(100, 34); Padding = new Point(12, 6);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Theme.Surface);
        if (TabPages.Count > 0)
        {
            var strip = GetTabRect(0);
            using var line = new Pen(Theme.Line);
            g.DrawLine(line, 0, strip.Bottom, Width, strip.Bottom);
        }
        for (int i = 0; i < TabPages.Count; i++) DrawTab(g, i, GetTabRect(i));
    }
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0 || e.Index >= TabPages.Count) return;
        DrawTab(e.Graphics, e.Index, e.Bounds);
    }
    private void DrawTab(Graphics g, int index, Rectangle bounds)
    {
        bool selected = index == SelectedIndex;
        using (var fill = new SolidBrush(Theme.Surface)) g.FillRectangle(fill, bounds);
        TextRenderer.DrawText(g, TabPages[index].Text, Font, bounds, selected ? Theme.Ink : Theme.Muted,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
        if (selected)
        {
            using var pen = new Pen(Theme.Spruce, 2);
            g.DrawLine(pen, bounds.Left + 8, bounds.Bottom - 1, bounds.Right - 8, bounds.Bottom - 1);
        }
    }
}

/// <summary>Product mark: a pulse line with a brass peak, followed by the name in a serif face.</summary>
public class BrandMark : Control
{
    private Color rungColor = Theme.Brass;
    /// <summary>Colour of the pulse peak.</summary>
    [DefaultValue(typeof(Color), "201, 168, 106")] public Color RungColor { get => rungColor; set { rungColor = value; Invalidate(); } }
    public BrandMark()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        TabStop = false; Text = "МедТест"; BackColor = Theme.TopBar; ForeColor = Theme.DarkText;
    }
    protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); Invalidate(); }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        float scale = Math.Max(0.5f, Math.Min(Height / 36f, 2f));
        float top = (Height - 32 * scale) / 2f, left = 2 * scale;
        PointF P(float x, float y) => new(left + x * scale, top + y * scale);
        var state = g.Save();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using (var line = new Pen(ForeColor, 1.8f * scale) { LineJoin = System.Drawing.Drawing2D.LineJoin.Round })
        {
            g.DrawLines(line, new[] { P(1, 17), P(8, 17), P(11, 12), P(14, 22) });
            g.DrawLines(line, new[] { P(19, 7), P(22, 26), P(25, 17), P(29, 17) });
        }
        using (var peak = new Pen(rungColor, 2.2f * scale) { LineJoin = System.Drawing.Drawing2D.LineJoin.Round })
            g.DrawLines(peak, new[] { P(14, 22), P(16.5f, 4), P(19, 7) });
        g.Restore(state);
        int textLeft = (int)(left + 34 * scale);
        TextRenderer.DrawText(g, Text, Font, new Rectangle(textLeft, 0, Math.Max(0, Width - textLeft), Height), ForeColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding);
    }
}
