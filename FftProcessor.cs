using Plot3D;

namespace FFT_audio_analiser
{

    public class fft_processor
    {
        readonly List<double> Values = new();
        readonly NAudio.Wave.WaveInEvent WaveIn;

        public fft_processor()
        {
            int device = 0;
            //rate 25532
            WaveIn = new()
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
            int sampleCount = 2048;
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

            n = Nvl * 2;
            Tmvl = new double[n];

            for (i = 0; i < n; i += 2)
            {
                Tmvl[i] = 0;
                Tmvl[i + 1] = AVal[i / 2];
            }

            i = 1;
            j = 1;
            while (i < n)
            {
                if (j > i)
                {
                    Tmpr = Tmvl[i];
                    Tmvl[i] = Tmvl[j];
                    Tmvl[j] = Tmpr;
                    Tmpr = Tmvl[i + 1];
                    Tmvl[i + 1] = Tmvl[j + 1];
                    Tmvl[j + 1] = Tmpr;
                }
                i = i + 2;
                m = Nvl;
                while ((m >= 2) && (j > m))
                {
                    j = j - m;
                    m = m >> 1;
                }
                j = j + m;
            }

            Mmax = 2;
            while (n > Mmax)
            {
                Theta = -6.283185307179586 / Mmax;
                Wpi = Math.Sin(Theta);
                Wtmp = Math.Sin(Theta / 2);
                Wpr = Wtmp * Wtmp * 2;
                Istp = Mmax * 2;
                Wr = 1;
                Wi = 0;
                m = 1;

                while (m < Mmax)
                {
                    i = m;
                    m = m + 2;
                    Tmpr = Wr;
                    Tmpi = Wi;
                    Wr = Wr - Tmpr * Wpr - Tmpi * Wpi;
                    Wi = Wi + Tmpr * Wpi - Tmpi * Wpr;

                    while (i < n)
                    {
                        j = i + Mmax;
                        Tmpr = Wr * Tmvl[j] - Wi * Tmvl[j - 1];
                        Tmpi = Wi * Tmvl[j] + Wr * Tmvl[j - 1];

                        Tmvl[j] -= Tmpr;
                        Tmvl[j - 1] -= Tmpi;
                        Tmvl[i] += Tmpr;
                        Tmvl[i - 1] += Tmpi;
                        i += Istp;
                    }
                }

                Mmax = Istp;
            }

            for (i = 0; i < Nft; i++)
            {
                j = i * 2;
                FTvl[i] = 2 * Math.Sqrt(Math.Pow(Tmvl[j], 2) + Math.Pow(Tmvl[j + 1], 2)) / Nvl;
            }

            return FTvl;
        }

    }
}