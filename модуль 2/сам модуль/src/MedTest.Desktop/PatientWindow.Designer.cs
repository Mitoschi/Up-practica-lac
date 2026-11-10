#nullable enable
namespace MedTest.Desktop;

partial class PatientWindow
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!;
    private PatientCard card = null!;
    private System.Windows.Forms.Label messageLabel = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.card = new MedTest.Desktop.PatientCard();
        this.messageLabel = new System.Windows.Forms.Label();
        this.layout.SuspendLayout();
        this.SuspendLayout();
        //
        // layout
        //
        this.layout.BackColor = System.Drawing.Color.FromArgb(243, 245, 244);
        this.layout.ColumnCount = 1;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.Controls.Add(this.card, 0, 0);
        this.layout.Controls.Add(this.messageLabel, 0, 1);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Margin = new System.Windows.Forms.Padding(0);
        this.layout.Name = "layout";
        this.layout.Padding = new System.Windows.Forms.Padding(12, 12, 12, 0);
        this.layout.RowCount = 2;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        //
        // card
        //
        this.card.Dock = System.Windows.Forms.DockStyle.Fill;
        this.card.Margin = new System.Windows.Forms.Padding(0);
        this.card.Name = "card";
        this.card.Changed += new System.EventHandler(this.CardChanged);
        //
        // messageLabel
        //
        this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.messageLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Text = "";
        this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // PatientWindow
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.FromArgb(243, 245, 244);
        this.ClientSize = new System.Drawing.Size(1180, 860);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.MinimumSize = new System.Drawing.Size(860, 640);
        this.Name = "PatientWindow";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "МедТест — карта пациента";
        this.Shown += new System.EventHandler(this.WindowShown);
        this.layout.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
