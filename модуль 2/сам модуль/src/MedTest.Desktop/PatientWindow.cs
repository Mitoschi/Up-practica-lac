using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>The patient card in its own large window (opened from the list with «Открыть карту»).</summary>
public partial class PatientWindow : Form
{
    private readonly AppSession? session;
    private readonly int patientId;
    private IReadOnlyList<Indicator> indicators = [];
    private IReadOnlyDictionary<int, IndicatorStats> stats = new Dictionary<int, IndicatorStats>();

    /// <summary>The patient or an examination was changed while the window was open.</summary>
    public bool ChangedData { get; private set; }

    public PatientWindow() { InitializeComponent(); Theme.Apply(this); }

    public PatientWindow(AppSession session, int patientId, IReadOnlyList<Indicator> indicators, IReadOnlyDictionary<int, IndicatorStats> stats) : this()
    {
        this.session = session; this.patientId = patientId; this.indicators = indicators; this.stats = stats;
        card.Message += (text, error) => { messageLabel.ForeColor = error ? Theme.Rust : Theme.Muted; messageLabel.Text = text; };
    }

    private async void WindowShown(object? sender, EventArgs e)
    {
        if (session == null) return;
        await card.LoadAsync(session, patientId, indicators, stats);
        if (card.Patient != null) Text = "МедТест — карта " + card.Patient.CardNumber + " · " + card.Patient.FullName;
    }

    /// <summary>After a change the statistics are recomputed with the new values, then the card is reloaded.</summary>
    private async void CardChanged(object? sender, EventArgs e)
    {
        if (session == null) return;
        ChangedData = true;
        if (card.Patient == null) { Close(); return; }
        var (points, error) = await AppSession.Try(() => session.Db.SamplePointsAsync(session.Actor));
        if (points != null) stats = indicators.ToDictionary(i => i.Id, i => Statistics.Compute(Statistics.Sample(points, i.Id, SampleMode.LatestPerPatient), i));
        await card.LoadAsync(session, patientId, indicators, stats);
        if (error != null) { messageLabel.ForeColor = Theme.Rust; messageLabel.Text = error; }
    }
}
