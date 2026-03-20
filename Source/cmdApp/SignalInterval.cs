// SignalInterval.cs
using System;
using System.Linq;
using MathNet.Numerics.IntegralTransforms;
namespace cmdApp
{
    public class SignalInterval
    {
        public int[] Signal { get; private set; }
        public double SamplingTime { get; private set; }
        public double SamplingFrequency { get; private set; }
        public double[] Frequency { get; private set; }         // FFT 频率轴（只取前一半）
        public double[] Amplitude { get; private set; }        // FFT 幅值
        public double[] DominantFrequency { get; private set; } // 主频率（数组）
        public double[] DominantAmplitude { get; private set; } // 主频率对应幅值

        public double[] FrequencyList { get; set; }

        public SignalInterval(double[] frequencyList, int nInterpolation, double samplingTime)
        {
            FrequencyList = frequencyList;

            var prs = new PseudoRandomSignal(frequencyList);
            Signal = prs.Sampling(nInterpolation, (int)samplingTime);

            this.SamplingTime = samplingTime;
            SamplingFrequency = nInterpolation * prs.NSequence;

            ComputeSpectrum();
        }

        private void ComputeSpectrum()
        {
            int n = Signal.Length;
            double[] signalArray = Signal.Select(x => (double)x).ToArray();

            var complexSignal = signalArray.Select(x => new System.Numerics.Complex(x, 0)).ToArray();
            Fourier.Forward(complexSignal, FourierOptions.Matlab);

            int halfN = n / 2;
            Frequency = new double[halfN];
            Amplitude = new double[halfN];

            for (int i = 0; i < halfN; i++)
            {
                Frequency[i] = i / SamplingTime;                  // 频率 = idx / 时间
                Amplitude[i] = complexSignal[i].Magnitude / halfN; // 幅值归一化
            }

            // 找出幅值最大的前 N 个频率，N = 输入频率个数
            int topN = FrequencyList.Length;
            var sorted = Amplitude
                .Select((val, idx) => new { Value = val, Index = idx })
                .OrderByDescending(x => x.Value)
                .Take(topN)
                .ToArray();

            DominantFrequency = sorted.Select(x => Frequency[x.Index]).ToArray();
            DominantAmplitude = sorted.Select(x => Amplitude[x.Index]).ToArray();
        }
    }
}