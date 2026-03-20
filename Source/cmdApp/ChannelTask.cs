// ChannelTask.cs
using System;
using System.Collections.Generic;
namespace cmdApp
{
    public class ChannelTask
    {
        public List<SignalInterval> SignalIntervals { get; private set; } = new List<SignalInterval>();
        public double SamplingFrequency { get; private set; } = 8.0;

        public void AddInterval(double samplingTime, double[] frequencyList)
        {
            var interval = new SignalInterval(frequencyList, nInterpolation: 4, samplingTime: samplingTime);
            SignalIntervals.Add(interval);
        }

        public void RemoveInterval()
        {
            if (SignalIntervals.Count > 1)
            {
                SignalIntervals.RemoveAt(SignalIntervals.Count - 1);
            }
        }












        public void PrintAllParameters()
        {
            Console.WriteLine($">>> ChannelTask 包含 {SignalIntervals.Count} 个信号区间");

            for (int i = 0; i < SignalIntervals.Count; i++)
            {
                var si = SignalIntervals[i];
                Console.WriteLine($"\n--- 信号区间 #{i + 1} ---");
                Console.WriteLine($"  采样时间: {si.SamplingTime} s");
                Console.WriteLine($"  采样频率: {si.SamplingFrequency}");
                Console.WriteLine($"  频率成分: [{string.Join(", ", si.FrequencyList.Select(f => f.ToString("0.##")))}]");

                Console.Write("  信号: [");
                Console.Write(string.Join(", ", si.Signal));
                Console.WriteLine($"]");
                Console.WriteLine($"信号长度为 {si.Signal.Length}");
                //var sigPreview = si.Signal.Take(20);
                //Console.Write(string.Join(", ", sigPreview));
                //if (si.Signal.Length > 20) Console.Write(", ...]");
                //Console.WriteLine();

                Console.WriteLine("  主频率及其幅值:");

                for (int j = 0; j < si.DominantFrequency.Length; j++)
                {
                    Console.WriteLine($"    主频率 {j + 1}: {si.DominantFrequency[j]:F2} Hz, 幅值 = {si.DominantAmplitude[j]:F4}");
                }

            }
        }
    }

}