using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace MauiFft;

public partial class window_setup : Form
{
    double[]? LastFft;
    double MaxFft = 1;
    readonly fft_processor FftProc = new();

    public window_setup()
    {
        InitializeComponent();
    }

    private void skglControl1_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintGLSurfaceEventArgs e)
    {
        if (LastFft is null)
            return;
        
        float width = skglControl1.Width;
        float height = skglControl1.Height;
        int width_int = Width;

        ICanvas canvas = new SkiaCanvas() { Canvas = e.Surface.Canvas };
        canvas.FillColor = Microsoft.Maui.Graphics.Color.FromArgb("#121212");
        canvas.FillRectangle(0, 0, width, height);

        double lastFftMax = LastFft.Max();
        MaxFft = Math.Max(MaxFft, lastFftMax);
        float[] ys = LastFft.Select(x => (float)(x / MaxFft) * skglControl1.Height * 6).ToArray();
        float[] xs = Enumerable.Range(0, ys.Length).Select(x => (float)x / ys.Length * skglControl1.Width).ToArray();
        var points = LastFft.Select((mag, i) => new Microsoft.Maui.Graphics.PointF(xs[i], skglControl1.Height - ys[i])).ToArray();

        canvas.StrokeDashPattern = new float[] { 10, 10 };
        canvas.StrokeColor = Colors.DarkSlateBlue;
        for (int i = 0; i < 12; i++)
            canvas.DrawLine(width * i / 12, 0, width * i / 12, height);

        canvas.StrokeDashPattern = new float[] { 1, 0 };
        canvas.StrokeColor = Colors.Orange;
        for (int i = 0; i < points.Length - 1; i++)
            canvas.DrawLine(points[i], points[i + 1]);

        this.label1.Location = new System.Drawing.Point((1 * width_int - 10) / 12, 9);
        this.label2.Location = new System.Drawing.Point((2 * width_int - 25) / 12, 9);
        this.label3.Location = new System.Drawing.Point((3 * width_int - 40) / 12, 9);
        this.label4.Location = new System.Drawing.Point((4 * width_int - 55) / 12, 9);
        this.label5.Location = new System.Drawing.Point((5 * width_int - 70) / 12, 9);
        this.label6.Location = new System.Drawing.Point((6 * width_int - 85) / 12, 9);
        this.label7.Location = new System.Drawing.Point((7 * width_int - 100) / 12, 9);
        this.label8.Location = new System.Drawing.Point((8 * width_int - 115) / 12, 9);
        this.label9.Location = new System.Drawing.Point((9 * width_int - 130) / 12, 9);
        this.label10.Location = new System.Drawing.Point((10 * width_int - 145) / 12, 9);
        this.label11.Location = new System.Drawing.Point((11 * width_int  - 160) / 12 , 9);


    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        double[]? fft = FftProc.GetFft();
        if (fft is not null)
        {
            LastFft = fft;
            skglControl1.Invalidate();
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }
}
