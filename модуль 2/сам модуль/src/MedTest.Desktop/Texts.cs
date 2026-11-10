using System.Globalization;
using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>How numbers, deviations and dates are written on screen and on paper.</summary>
public static class Texts
{
    static CultureInfo Ru => CultureInfo.CurrentCulture;

    /// <summary>Parses a typed number with either a comma or a point (see <see cref="Numbers.TryParse"/>).</summary>
    public static bool TryNumber(string? text, out decimal value) => Numbers.TryParse(text, out value);

    public static string Deviation(RefDeviation d, Indicator i) => d.Status switch
    {
        RefStatus.Above => "+" + i.Format(d.Delta) + (d.Percent is { } p ? " (" + p.ToString("0", Ru) + " %)" : ""),
        RefStatus.Below => "−" + i.Format(d.Delta) + (d.Percent is { } p ? " (" + p.ToString("0", Ru) + " %)" : ""),
        _ => "—"
    };

    /// <summary>Как значение выглядит на фоне остальных пациентов: словами, без формул.</summary>
    public static string ForGroup(Assessment a) => a.Z switch
    {
        null => "—",
        > 2 => "выше обычного",
        < -2 => "ниже обычного",
        _ => "обычно"
    };

    /// <summary>Норма группы — пределы, в которых обычно лежат значения пациентов; не выходит за возможные значения показателя.</summary>
    public static string StatNorm(IndicatorStats s, Indicator i) =>
        s.HasNorm ? i.Format(Math.Max((double)i.ValidMin, s.NormLow)) + "–" + i.Format(Math.Min((double)i.ValidMax, s.NormHigh)) : "мало данных";

    public static string Date(DateTime d) => d.ToString("dd.MM.yyyy", Ru);
    public static string DateTime(DateTime d) => d.ToString("dd.MM.yyyy HH:mm", Ru);
    public static string Date(DateOnly d) => d.ToString("dd.MM.yyyy", Ru);
    public static string Percent(double share) => (share * 100).ToString("0", Ru) + " %";
}
