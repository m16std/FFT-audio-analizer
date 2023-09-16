
/*****************************************************************************

This class has been written by Elmь (elmue@gmx.de)

Check if you have the latest version on:
https://www.codeproject.com/Articles/5293980/Graph3D-A-Windows-Forms-Render-Control-in-Csharp

*****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


using delRendererFunction = Plot3D.Graph3D.delRendererFunction;
using cPoint3D            = Plot3D.Graph3D.cPoint3D;
using eRaster             = Plot3D.Graph3D.eRaster;
using cScatter            = Plot3D.Graph3D.cScatter;
using eNormalize          = Plot3D.Graph3D.eNormalize;
using eSchema             = Plot3D.ColorSchema.eSchema;

//using FFT_audio_anslizer;


namespace Plot3D
{

    public partial class MainForm : Form
    {
        double[] LastFft;
        double MaxFft = 1;
        readonly fft_processor FftProc = new();

        public class fft_processor
        {
            readonly List<double> Values = new();
            readonly NAudio.Wave.WaveInEvent WaveIn;

            public fft_processor(int device = 0)
            {
                WaveIn = new() //создание отрезка звука для анализированния
                {
                    DeviceNumber = device,
                    WaveFormat = new NAudio.Wave.WaveFormat(rate: 25_532, bits: 16, channels: 1),
                    BufferMilliseconds = 20,
                };
                WaveIn.DataAvailable += WaveIn_DataAvailable; ;
                WaveIn.StartRecording();
            }
            public void WaveIn_DataAvailable(object? sender, NAudio.Wave.WaveInEventArgs e)
            {
                for (int index = 0; index < e.BytesRecorded; index += 2)
                {
                    double value = BitConverter.ToInt16(e.Buffer, index);
                    Values.Add(value);
                }
            }
            public double[]? GetFft(int pow = 10, double stepFrac = 0.05)
            {
                int sampleCount = 1024;
                if (Values.Count < sampleCount)
                    return null;

                double[] values = new double[sampleCount];
                Values.CopyTo(Values.Count - sampleCount, values, 0, sampleCount);

                int pointsToKeep = (int)((1 - stepFrac) * sampleCount);
                Values.RemoveRange(0, Values.Count - pointsToKeep);

                double[] fft = FFTmagnitude(values);

                return fft;
            }
            public static double[] FFTmagnitude(double[] AVal)
            {
                double[] FTvl = new double[AVal.Length / 2];
                int Nft = FTvl.Length;
                int Nvl = AVal.Length;

                int i, j, n, m, Mmax, Istp;
                double Tmpr, Tmpi, Wtmp, Theta;
                double Wpr, Wpi, Wr, Wi;
                double[] Tmvl;

                n = Nvl * 2; Tmvl = new double[n];

                for (i = 0; i < n; i += 2)
                {
                    Tmvl[i] = 0;
                    Tmvl[i + 1] = AVal[i / 2];
                }

                i = 1; j = 1;
                while (i < n)
                {
                    if (j > i)
                    {
                        Tmpr = Tmvl[i]; Tmvl[i] = Tmvl[j]; Tmvl[j] = Tmpr;
                        Tmpr = Tmvl[i + 1]; Tmvl[i + 1] = Tmvl[j + 1]; Tmvl[j + 1] = Tmpr;
                    }
                    i = i + 2; m = Nvl;
                    while ((m >= 2) && (j > m))
                    {
                        j = j - m; m = m >> 1;
                    }
                    j = j + m;
                }

                Mmax = 2;
                while (n > Mmax)
                {
                    Theta = -6.283185307179586 / Mmax; Wpi = Math.Sin(Theta);
                    Wtmp = Math.Sin(Theta / 2); Wpr = Wtmp * Wtmp * 2;
                    Istp = Mmax * 2; Wr = 1; Wi = 0; m = 1;

                    while (m < Mmax)
                    {
                        i = m; m = m + 2; Tmpr = Wr; Tmpi = Wi;
                        Wr = Wr - Tmpr * Wpr - Tmpi * Wpi;
                        Wi = Wi + Tmpr * Wpi - Tmpi * Wpr;

                        while (i < n)
                        {
                            j = i + Mmax;
                            Tmpr = Wr * Tmvl[j] - Wi * Tmvl[j - 1];
                            Tmpi = Wi * Tmvl[j] + Wr * Tmvl[j - 1];

                            Tmvl[j] = Tmvl[i] - Tmpr; Tmvl[j - 1] = Tmvl[i - 1] - Tmpi;
                            Tmvl[i] = Tmvl[i] + Tmpr; Tmvl[i - 1] = Tmvl[i - 1] + Tmpi;
                            i = i + Istp;
                        }
                    }

                    Mmax = Istp;
                }

                for (i = 0; i < Nft; i++)
                {
                    j = i * 2; FTvl[i] = 2 * Math.Sqrt(Math.Pow(Tmvl[j], 2) + Math.Pow(Tmvl[j + 1], 2)) / Nvl;
                }

                return FTvl;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // This is optional. If you don't want to use Trackbars leave this away.
            graph3D.AssignTrackBars(trackRho, trackTheta, trackPhi);

            comboRaster.Sorted = false;
            foreach (eRaster e_Raster in Enum.GetValues(typeof(eRaster)))
            {
                comboRaster.Items.Add(e_Raster);
            }
            comboRaster.SelectedIndex = (int)eRaster.Labels;

            comboColors.Sorted = false;
            foreach (eSchema e_Schema in Enum.GetValues(typeof(eSchema)))
            {
                comboColors.Items.Add(e_Schema);
            }
            comboColors.SelectedIndex = (int)eSchema.Rainbow1;

            comboDataSrc.SelectedIndex = 0; // set "Callback"
        }
        private void comboDataSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.AxisX_Legend = null;
            graph3D.AxisY_Legend = null;
            graph3D.AxisZ_Legend = null;

            switch (comboDataSrc.SelectedIndex)
            {
                case 0: SetCallback(); break;
                case 1: SetScatterPlot(false); break;
                case 2: SetScatterPlot(true); break;            
            }

            lblInfo.Text = "Points: " + graph3D.TotalPoints;
        }
        private void comboColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color[] c_Colors = ColorSchema.GetSchema((eSchema)comboColors.SelectedIndex);
            graph3D.SetColorScheme(c_Colors, 3);
        }
        private void comboRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph3D.Raster = (eRaster)comboRaster.SelectedIndex;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            graph3D.SetCoefficients(1350, 70, 230);
        }
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            SaveFileDialog i_Dlg = new SaveFileDialog();
            i_Dlg.Title = "Save as PNG image";
            i_Dlg.Filter = "PNG Image|*.png";
            i_Dlg.DefaultExt = ".png";

            if (DialogResult.Cancel == i_Dlg.ShowDialog(this))
                return;

            Bitmap i_Bitmap = graph3D.GetScreenshot();
            try
            {
                i_Bitmap.Save(i_Dlg.FileName, ImageFormat.Png);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================================================

        /// <summary>
        /// This demonstrates how to use a callback function which calculates Z values from X and Y
        /// </summary>
        private void SetCallback()
        {
            delRendererFunction f_Callback = delegate (double X, double Y)
            {
                double r = 0.15 * Math.Sqrt(X * X + Y * Y);
                if (r < 1e-10) return 120;
                else return 120 * Math.Sin(r) / r;
            };

            // IMPORTANT: Normalize maintainig the relation between X,Y,Z values otherwise the function will be distorted.
            graph3D.SetFunction(f_Callback, new PointF(-120, -80), new PointF(120, 80), 5, eNormalize.MaintainXYZ);
        }

        private void SetScatterPlot(bool b_Lines)
        {
            List<cScatter> i_List = new List<cScatter>();

            for (int X = 0; X < 100; X++)
            {
                for (int Y = 0; Y < 100; Y++)
                {
                    i_List.Add(new cScatter(X, Y, LastFft[Y], null));
                }
            }

            // Depending on your use case you can also specify MaintainXY or MaintainXYZ here
            if (b_Lines)
                graph3D.SetScatterLines(i_List.ToArray(), eNormalize.Separate, 3);
            else
                graph3D.SetScatterPoints(i_List.ToArray(), eNormalize.Separate);
        }

        /// <summary>
        /// This demonstrates how to set X, Y, Z scatterplot points in form of a heart
        /// </summary>

        int neznay = 200;
        int neznay2 = 30;
        double[,] last_fft_3d = new double[30, 200];

        private void graph3D_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void graph3D_Load_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cPoint3D[,] i_Points3D = new cPoint3D[30, 200];
            double[]? fft = FftProc.GetFft();
            if (fft is not null)
            {
                LastFft = fft;
            }

            for (int i = neznay2 - 1; i > 0; i--)
            {
                for (int Y = 0; Y < neznay; Y++)
                {
                    last_fft_3d[i, Y] = last_fft_3d[i - 1, Y];
                }
            }

            for (int Y = 0; Y < neznay; Y++)
            {
                last_fft_3d[0, Y] = LastFft[Y];
            }

            for (int i = 0; i < neznay2; i++)
            {
                for (int Y = 0; Y < neznay; Y++)
                {
                    i_Points3D[i, Y] = new cPoint3D(i, Y * 25, last_fft_3d[i, Y]);
                }
            }

            for (int i = 0; i < neznay2; i++)
            {
                graph3D.SetSurfacePoints(i_Points3D, eNormalize.Separate);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
