using System.ComponentModel;
using System.Globalization;
namespace MedTest.Desktop;

public enum ButtonTone { Secondary, Primary, Accent, Danger, OnDark, Tab }

/// <summary>Flat rectangular button. Colours follow <see cref="Tone"/>; hover, press, disabled and focus are drawn explicitly.</summary>
public class UiButton : Button
{
    private ButtonTone tone;
    private bool active, hovered, pressed;
    private Font? boldFont;
    [DefaultValue(ButtonTone.Secondary)] public ButtonTone Tone { get => tone; set { tone = value; Invalidate(); } }
    /// <summary>Selected state for top navigation tabs and filter chips.</summary>
    [DefaultValue(false)] public bool Active { get => active; set { active = value; Invalidate(); } }
    protected bool IsHovered => hovered;
    protected bool IsPressed => pressed;
    protected Font BoldFont => boldFont ??= new Font(Font, FontStyle.Bold);
    public UiButton()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        FlatStyle = FlatStyle.Flat; FlatAppearance.BorderSize = 0; UseVisualStyleBackColor = false; Cursor = Cursors.Hand;
    }
    protected override void OnMouseEnter(EventArgs e) { hovered = true; Invalidate(); base.OnMouseEnter(e); }
    protected override void OnMouseLeave(EventArgs e) { hovered = false; pressed = false; Invalidate(); base.OnMouseLeave(e); }
    protected override void OnMouseDown(MouseEventArgs e) { if (e.Button == MouseButtons.Left) pressed = true; Invalidate(); base.OnMouseDown(e); }
    protected override void OnMouseUp(MouseEventArgs e) { pressed = false; Invalidate(); base.OnMouseUp(e); }
    protected override void OnMouseCaptureChanged(EventArgs e) { if (!Capture) pressed = false; Invalidate(); base.OnMouseCaptureChanged(e); }
    protected override void OnKeyDown(KeyEventArgs e) { if (e.KeyCode == Keys.Space) { pressed = true; Invalidate(); } base.OnKeyDown(e); }
    protected override void OnKeyUp(KeyEventArgs e) { pressed = false; Invalidate(); base.OnKeyUp(e); }
    protected override void OnEnabledChanged(EventArgs e) { if (!Enabled) { hovered = false; pressed = false; } Invalidate(); base.OnEnabledChanged(e); }
    protected override void OnFontChanged(EventArgs e) { boldFont?.Dispose(); boldFont = null; base.OnFontChanged(e); }
    protected override void Dispose(bool disposing) { if (disposing) { boldFont?.Dispose(); boldFont = null; } base.Dispose(disposing); }

    /// <summary>Background of the nearest opaque ancestor, so dark-bar buttons blend with their bar.</summary>
    protected Color ParentFill()
    {
        Control? parent = Parent;
        while (parent != null && parent.BackColor.A < 255) parent = parent.Parent;
        return parent?.BackColor ?? Theme.Canvas;
    }

    /// <summary>Current fill, border and text colours.</summary>
    public (Color Fill, Color Border, Color Text) CurrentColors()
    {
        bool enabled = Enabled;
        switch (tone)
        {
            case ButtonTone.Primary:
            {
                if (!enabled) return (Color.FromArgb(196, 210, 205), Color.FromArgb(196, 210, 205), Color.White);
                var fill = pressed ? Theme.SprucePressed : hovered ? Theme.SpruceHover : Theme.Spruce;
                return (fill, fill, Color.White);
            }
            case ButtonTone.Accent:
            {
                if (!enabled) return (Color.FromArgb(222, 211, 188), Color.FromArgb(222, 211, 188), Theme.Muted);
                var fill = pressed ? Color.FromArgb(168, 137, 80) : hovered ? Theme.BrassHover : Theme.Brass;
                return (fill, fill, Theme.Ink);
            }
            case ButtonTone.Danger:
            {
                if (!enabled) return (Theme.Canvas, Theme.Line, Theme.Muted);
                var fill = pressed ? Color.FromArgb(246, 222, 216) : hovered ? Color.FromArgb(251, 238, 234) : Theme.Surface;
                return (fill, Theme.Rust, Theme.Rust);
            }
            case ButtonTone.OnDark:
            {
                var bar = ParentFill();
                if (!enabled) return (bar, Theme.DarkLine, Theme.DarkMuted);
                var fill = pressed ? Theme.DarkLine : hovered ? Theme.SearchFill : bar;
                return (fill, Theme.DarkButtonLine, Theme.DarkText);
            }
            case ButtonTone.Tab:
            {
                var bar = ParentFill();
                if (active) return (Theme.Spruce, Theme.Spruce, Color.White);
                if (!enabled) return (bar, bar, Theme.DarkMuted);
                var fill = pressed ? Theme.DarkLine : hovered ? Theme.SearchFill : bar;
                return (fill, fill, hovered ? Color.White : Theme.TopText);
            }
            default:
            {
                if (!enabled) return (Theme.Canvas, Theme.Line, Theme.Muted);
                var fill = pressed ? Theme.Selected : hovered ? Theme.Hover : Theme.Surface;
                return (fill, pressed ? Theme.Spruce : Theme.StrongLine, Theme.Ink);
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width < 2 || Height < 2) return;
        var (fill, border, text) = CurrentColors();
        var g = e.Graphics;
        using (var brush = new SolidBrush(fill)) g.FillRectangle(brush, ClientRectangle);
        if (border != fill) { using var pen = new Pen(border); g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1); }
        var flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
        if (!ShowKeyboardCues) flags |= TextFormatFlags.HidePrefix;
        var font = tone == ButtonTone.Tab && active ? BoldFont : Font;
        TextRenderer.DrawText(g, Text, font, Rectangle.Inflate(ClientRectangle, -4, 0), text, flags);
        DrawFocus(g);
    }

    protected void DrawFocus(Graphics g)
    {
        if (!Focused || !ShowFocusCues || Width < 10 || Height < 10) return;
        bool dark = tone is ButtonTone.Primary or ButtonTone.OnDark or ButtonTone.Tab;
        using var pen = new Pen(dark ? Color.White : Theme.Spruce) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
        g.DrawRectangle(pen, 3, 3, Width - 7, Height - 7);
    }
}

/// <summary>Quick filter above a table: label and the number of matching rows.</summary>
public class FilterChip : UiButton
{
    private int count;
    private bool warn;
    [DefaultValue(0)] public int Count { get => count; set { count = value; FitWidth(); Invalidate(); } }
    /// <summary>Rust outline for filters about overdue work.</summary>
    [DefaultValue(false)] public bool Warn { get => warn; set { warn = value; Invalidate(); } }
    public FilterChip() { Padding = new Padding(12, 0, 12, 0); Size = new Size(80, 30); }
    protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); FitWidth(); }
    protected override void OnFontChanged(EventArgs e) { base.OnFontChanged(e); FitWidth(); }
    private string CountText => count.ToString(CultureInfo.CurrentCulture);
    public void FitWidth()
    {
        const TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;
        var label = TextRenderer.MeasureText(Text, Font, Size.Empty, flags);
        var number = TextRenderer.MeasureText(CountText, BoldFont, Size.Empty, flags);
        Width = Padding.Horizontal + label.Width + 6 + number.Width + 8;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width < 2 || Height < 2) return;
        var g = e.Graphics;
        Color fill, border, label, number;
        if (Active) { fill = Theme.Ink; border = Theme.Ink; label = Color.White; number = Color.FromArgb(178, 190, 186); }
        else if (warn) { fill = IsHovered ? Theme.Surface : ParentFill(); border = Theme.Rust; label = Theme.Rust; number = Theme.Rust; }
        else { fill = IsHovered ? Theme.Surface : ParentFill(); border = Theme.Line; label = Theme.Ink; number = Theme.Muted; }
        if (!Enabled) { label = Theme.Muted; number = Theme.Muted; }
        using (var brush = new SolidBrush(fill)) g.FillRectangle(brush, ClientRectangle);
        using (var pen = new Pen(border)) g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        const TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
        int labelWidth = TextRenderer.MeasureText(g, Text, Font, Size.Empty, flags).Width;
        TextRenderer.DrawText(g, Text, Font, new Rectangle(Padding.Left, 0, labelWidth + 2, Height), label, flags);
        TextRenderer.DrawText(g, CountText, BoldFont, new Rectangle(Padding.Left + labelWidth + 6, 0, Math.Max(0, Width - Padding.Left - labelWidth - 6), Height), number, flags);
        DrawFocus(g);
    }
}

/// <summary>One half of a two-state segmented switch (radio semantics, button look).</summary>
public class SegmentButton : RadioButton
{
    public SegmentButton()
    {
        Appearance = Appearance.Button; FlatStyle = FlatStyle.Flat; TextAlign = ContentAlignment.MiddleCenter; UseVisualStyleBackColor = false;
        BackColor = Theme.Surface; Cursor = Cursors.Hand;
        FlatAppearance.BorderColor = Theme.StrongLine; FlatAppearance.BorderSize = 1;
        FlatAppearance.CheckedBackColor = Theme.Spruce; FlatAppearance.MouseDownBackColor = Theme.Selected;
        Sync();
    }
    protected override void OnCheckedChanged(EventArgs e) { Sync(); base.OnCheckedChanged(e); }
    private void Sync()
    {
        ForeColor = Checked ? Color.White : Theme.Ink;
        FlatAppearance.MouseOverBackColor = Checked ? Theme.SpruceHover : Theme.Hover;
    }
}
