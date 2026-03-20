// ChannelTask.cs
using System;
using System.Collections.Generic;
namespace WinFormsApp.Method
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



                //// 匹配 winform应用
                //int numPoints = 512;
                //double samplingTime = 2.0;

                //// 收集所有信号数据
                //List<int> allSignals = new List<int>();
                //for (int i = 0; i < SignalIntervals.Count; i++)
                //{
                //    var signal = SignalIntervals[i];
                //    foreach (var sample in signal.Signal)
                //    {
                //        allSignals.Add(sample);
                //    }
                //}

                //// 生成时间轴数据 t_data
                //int n = allSignals.Count;
                //double[] t_data = new double[n];
                //double timeStep = samplingTime / (n - 1);

                //for (int i = 0; i < n; i++)
                //{
                //    t_data[i] = i * timeStep;
                //}

                //// 转换信号数据为 double 数组
                //double[] signalData = allSignals.Select(s => (double)s).ToArray();

                //// ========== 检验结果 ==========
                //Console.WriteLine("\n\n========== 检验结果 ==========");

                //// 检验长度
                //Console.WriteLine($"t_data 长度: {t_data.Length}");
                //Console.WriteLine($"signalData 长度: {signalData.Length}");
                //Console.WriteLine($"预期长度: {numPoints}");
                //Console.WriteLine($"长度是否匹配: {(t_data.Length == numPoints && signalData.Length == numPoints ? "✓ 是" : "✗ 否")}");

                //// 检验 t_data 内容
                //Console.WriteLine($"\nt_data 范围: [{t_data.Min():F6}, {t_data.Max():F6}]");
                //Console.WriteLine($"预期范围: [0, {samplingTime}]");
                //Console.WriteLine($"时间步长: {timeStep:F6}");
                //Console.WriteLine($"首5个点: [{string.Join(", ", t_data.Take(5).Select(x => x.ToString("F4")))}]");
                //Console.WriteLine($"末5个点: [{string.Join(", ", t_data.TakeLast(5).Select(x => x.ToString("F4")))}]");

                //// 检验 signalData 内容
                //Console.WriteLine($"\nsignalData 范围: [{signalData.Min():F2}, {signalData.Max():F2}]");
                //Console.WriteLine($"首5个点: [{string.Join(", ", signalData.Take(5).Select(x => x.ToString("F2")))}]");
                //Console.WriteLine($"末5个点: [{string.Join(", ", signalData.TakeLast(5).Select(x => x.ToString("F2")))}]");




            }
        }

    }
}