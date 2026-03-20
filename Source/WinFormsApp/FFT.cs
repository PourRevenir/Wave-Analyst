using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace WinFormsApp
{

    public class FFT
    {
        /// <summary>
        /// FFT分析结果类
        /// </summary>
        public class FFTResult
        {
            public double Frequency { get; set; }      // 频率 (Hz)
            public double Amplitude { get; set; }     // 幅值
            public double Phase { get; set; }         // 相位 (弧度)
            public double Magnitude { get; set; }     // 幅度谱 (复数模)
        }

        /// <summary>
        /// 执行FFT分析
        /// </summary>
        /// <param name="timeList">时间序列 (单位: 秒)</param>
        /// <param name="amplitudeList">幅值序列</param>
        /// <returns>FFT结果列表</returns>
        public static List<FFTResult> PerformFFT(List<double> timeList, List<double> amplitudeList)
        {
            if (timeList == null || amplitudeList == null)
                throw new ArgumentNullException("输入数据不能为空");

            if (timeList.Count != amplitudeList.Count)
                throw new ArgumentException("时间和幅值列表长度必须相同");

            if (timeList.Count < 2)
                throw new ArgumentException("数据点数量必须大于等于2");

            int n = timeList.Count;

            // 计算采样间隔和时间序列
            double[] times = timeList.ToArray();
            double[] amplitudes = amplitudeList.ToArray();

            // 计算采样频率
            double dt = times[1] - times[0];  // 假设均匀采样
            for (int i = 1; i < times.Length - 1; i++)
            {
                dt += times[i + 1] - times[i];
            }
            dt /= (times.Length - 1);

            double samplingFrequency = 1.0 / dt;
            double frequencyResolution = samplingFrequency / n;

            // 检查是否为2的幂次，如果不是，进行补零
            int fftSize = n;
            if (!IsPowerOfTwo(n))
            {
                fftSize = NextPowerOfTwo(n);
            }

            // 创建复数数组并进行FFT
            Complex32[] complexData = new Complex32[fftSize];

            for (int i = 0; i < n; i++)
            {
                complexData[i] = new Complex32((float)amplitudes[i], 0f);
            }

            // 执行FFT (正向变换)
            Fourier.Forward(complexData, FourierOptions.Default);

            // 计算频率轴
            double[] frequencies = GenerateFrequencies(fftSize, frequencyResolution);

            // 提取结果
            var results = new List<FFTResult>();

            // 只取前一半频谱 (奈奎斯特频率)
            int halfLength = fftSize / 2;

            for (int i = 0; i < halfLength; i++)
            {
                double magnitude = complexData[i].Magnitude;
                double phase = complexData[i].Phase;

                // 计算实际幅值 (对于实信号，需要乘以2/N，除了直流分量)
                double amplitude;
                if (i == 0)
                {
                    amplitude = magnitude * 2.0 / fftSize;
                }
                else
                {
                    amplitude = magnitude * 2.0 / fftSize;
                }

                results.Add(new FFTResult
                {
                    Frequency = frequencies[i],
                    Amplitude = amplitude,
                    Phase = phase,
                    Magnitude = magnitude
                });
            }

            return results;
        }

        /// <summary>
        /// 检查是否为2的幂次
        /// </summary>
        private static bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// 找到下一个2的幂次
        /// </summary>
        private static int NextPowerOfTwo(int n)
        {
            int power = 1;
            while (power < n)
            {
                power *= 2;
            }
            return power;
        }

        /// <summary>
        /// 生成频率轴
        /// </summary>
        private static double[] GenerateFrequencies(int fftSize, double frequencyResolution)
        {
            double[] frequencies = new double[fftSize / 2];
            for (int i = 0; i < fftSize / 2; i++)
            {
                frequencies[i] = i * frequencyResolution;
            }
            return frequencies;
        }

        /// <summary>
        /// 简化版FFT - 只返回频率和幅值
        /// </summary>
        public static (double[] Frequencies, double[] Amplitudes) SimpleFFT(
            List<double> timeList,
            List<double> amplitudeList)
        {
            var results = PerformFFT(timeList, amplitudeList);

            double[] frequencies = results.Select(r => r.Frequency).ToArray();
            double[] amplitudes = results.Select(r => r.Amplitude).ToArray();

            return (frequencies, amplitudes);
        }



        // FSD功率谱分析



        // Hann窗FFT分析




        // Hamming窗FFT分析




        // Blackman窗FFT分析



    }
}