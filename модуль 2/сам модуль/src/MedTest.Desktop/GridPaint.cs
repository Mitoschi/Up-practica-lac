namespace MedTest.Desktop;

/// <summary>
/// Cell renderers for the request tables. Content is drawn into the top band of a row,
/// so a row expanded for inline sample acceptance keeps its data line in place.
/// </summary>
internal static class GridPaint
{
    private const DataGridViewPaintParts Back = DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.SelectionBackground;
    private const TextFormatFlags Line = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

    private static Rectangle Band(DataGridViewCellPaintingEventArgs e, int band) =>
        new(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width, Math.Min(band, e.CellBounds.Height));

    internal static void Text(DataGridViewCellPaintingEventArgs e, string text, Font font, Color color, int band)
    {
        e.Paint(e.ClipBounds, Back);
        var b = Band(e, band);
        TextRenderer.DrawText(e.Graphics!, text, font, new Rectangle(b.Left + 8, b.Top, Math.Max(0, b.Width - 16), b.Height), color, Line);
        e.Handled = true;
    }

    /// <summary>Square initials in the patient colour, then the patient name.</summary>
    internal static void Person(DataGridViewCellPaintingEventArgs e, string name, Color orderColor, Font font, int band)
    {
        e.Paint(e.ClipBounds, Back);
        var g = e.Graphics!; var b = Band(e, band);
        int size = Math.Min(22, Math.Max(12, b.Height - 12));
        var square = new Rectangle(b.Left + 8, b.Top + (b.Height - size) / 2, size, size);
        using (var fill = new SolidBrush(orderColor)) g.FillRectangle(fill, square);
        TextRenderer.DrawText(g, Theme.Initials(name), Theme.TagFont, square, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding);
        int left = square.Right + 8;
        TextRenderer.DrawText(g, name, font, new Rectangle(left, b.Top, Math.Max(0, b.Right - left - 8), b.Height), Theme.Ink, Line);
        e.Handled = true;
    }

    /// <summary>Small rectangular status tag.</summary>
    internal static void Tag(DataGridViewCellPaintingEventArgs e, Theme.StatusTag tag, int band)
    {
        e.Paint(e.ClipBounds, Back);
        var g = e.Graphics!; var b = Band(e, band);
        var size = TextRenderer.MeasureText(g, tag.Text, Theme.TagFont, Size.Empty, TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix);
        int height = size.Height + 4, width = Math.Max(0, Math.Min(size.Width + 14, b.Width - 16));
        var rect = new Rectangle(b.Left + 8, b.Top + (b.Height - height) / 2, width, height);
        using (var fill = new SolidBrush(tag.Back)) g.FillRectangle(fill, rect);
        TextRenderer.DrawText(g, tag.Text, Theme.TagFont, rect, tag.Fore,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        e.Handled = true;
    }

    /// <summary>Deadline: the number of days in bold, the date after it; rust when two days or fewer remain.</summary>
    internal static void Deadline(DataGridViewCellPaintingEventArgs e, string bold, string rest, bool urgent, Font font, int band)
    {
        e.Paint(e.ClipBounds, Back);
        var g = e.Graphics!; var b = Band(e, band);
        var color = urgent ? Theme.Rust : Theme.Ink;
        int x = b.Left + 8, right = b.Right - 8;
        if (bold.Length > 0)
        {
            var boldFont = urgent || rest.Length > 0 ? Theme.CellBoldFont : font;
            int width = TextRenderer.MeasureText(g, bold, boldFont, Size.Empty, TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix).Width;
            TextRenderer.DrawText(g, bold, boldFont, new Rectangle(x, b.Top, Math.Max(0, Math.Min(width + 2, right - x)), b.Height), color, Line | TextFormatFlags.NoPadding);
            x += width;
        }
        if (rest.Length > 0 && x < right)
            TextRenderer.DrawText(g, rest, font, new Rectangle(x, b.Top, right - x, b.Height), urgent ? Theme.Rust : Theme.Ink, Line | TextFormatFlags.NoPadding);
        e.Handled = true;
    }

    /// <summary>Selection box used for bulk actions.</summary>
    internal static void Check(DataGridViewCellPaintingEventArgs e, bool on, int band)
    {
        e.Paint(e.ClipBounds, Back);
        Box(e.Graphics!, Band(e, band), on);
        e.Handled = true;
    }

    internal static void HeaderCheck(DataGridViewCellPaintingEventArgs e, bool on)
    {
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
        Box(e.Graphics!, e.CellBounds, on);
        e.Handled = true;
    }

    private static void Box(Graphics g, Rectangle area, bool on)
    {
        var box = new Rectangle(area.Left + (area.Width - 14) / 2, area.Top + (area.Height - 14) / 2, 14, 14);
        if (on)
        {
            using (var fill = new SolidBrush(Theme.Spruce)) g.FillRectangle(fill, box);
            var state = g.Save();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.White, 2f);
            g.DrawLines(pen, new[] { new PointF(box.Left + 3, box.Top + 7), new PointF(box.Left + 6, box.Top + 10), new PointF(box.Left + 11, box.Top + 4) });
            g.Restore(state);
        }
        else
        {
            using (var fill = new SolidBrush(Theme.Surface)) g.FillRectangle(fill, box);
            using var pen = new Pen(Theme.StrongLine);
            g.DrawRectangle(pen, box.Left, box.Top, box.Width - 1, box.Height - 1);
        }
    }
}
