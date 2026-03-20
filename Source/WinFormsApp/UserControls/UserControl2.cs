using ScottPlot;
using System.Data;
using WinFormsApp.Log;
using WinFormsApp.Method;

namespace WinFormsApp.UserControls
{
    public partial class UserControl2 : UserControl
    {
        //定义公共接口
        private List<double> _frequency = new List<double>();
        public List<double> frequency
        {
            get { return _frequency; }// 读
            set { _frequency = value; } //写
        }

        private int _channelNumber;
        public int channelNumber
        {
            get { return _channelNumber; }
            set { _channelNumber = value; }
        }

        public UserControl2()
        {
            InitializeComponent();
        }

        // 绘制频率域图像
        public void LoadData(List<double> frequency, int channelNumber)
        {
            _frequency = frequency;
            _channelNumber = channelNumber;
            DrawfrequencySignal(_frequency, _channelNumber);  // 加载完立刻绘制
        }

        private void DrawfrequencySignal(List<double> _frequency, int channelNumber)
        {
            double[] ct_frequency = _frequency.ToArray();
            var ct = new ChannelTask();
            ct.AddInterval(samplingTime: 2.0, frequencyList: ct_frequency);

            // 怎么访问 si.DominantFrequency 和si.DominantAmplitude
            formsPlot2.Plot.Clear();

            // semilogx(si.dominantFrequency, si.dominantAmplitude)
            for (int i = 0; i < ct.SignalIntervals.Count; i++)
            {
                var signal = ct.SignalIntervals[i];

                // 获取频率和振幅数组
                double[] freq = signal.DominantFrequency;
                double[] amp = signal.DominantAmplitude;


                // 存储新数据
                List<double> newFreq = new List<double>();
                List<double> newAmp = new List<double>();

                // 处理每个点
                for (int m = 0; m < freq.Length; m++)
                {
                    double f = freq[m];
                    double a = amp[m];

                    if (f == 0)
                    {
                        // 特殊情况：f=0 时，振幅设为0
                        newFreq.Add(0);
                        newAmp.Add(0);
                    }
                    else
                    {
                        // 计算半宽
                        double h = 0.5 / f;

                        // 左零点
                        newFreq.Add(f - h);
                        newAmp.Add(0);

                        // 主峰点
                        newFreq.Add(f);
                        newAmp.Add(a);

                        // 右零点
                        newFreq.Add(f + h);
                        newAmp.Add(0);
                    }
                }

                // 现在 newFreq/newAmp 已经包含了：0, (0.5,0), (1,2), (1.5,0), (1.75,0), (2,1), (2.25,0), (3.75,0), (4,0.5), (4.25,0)

                // 排序（按频率升序）
                var combined = newFreq.Zip(newAmp, (f, a) => (f, a))
                                      .OrderBy(pair => pair.f)
                                      .ToList();

                // 拆回两个数组
                double[] finalFreq = combined.Select(p => p.f).ToArray();
                double[] finalAmp = combined.Select(p => p.a).ToArray();





                // 创建散点图，见https://scottplot.net/cookbook/5/CustomizingTicks/
                double[] logXs = finalFreq.Select(Math.Log10).ToArray();
                double[] Ys = finalAmp;
                var scatter = formsPlot2.Plot.Add.ScatterPoints(logXs, Ys);

    
            IMinorTickGenerator minorTickGen = new ScottPlot.TickGenerators.LogDecadeMinorTickGenerator();
            ScottPlot.TickGenerators.NumericAutomatic xTickGen = new()
            {
                MinorTickGenerator = minorTickGen,
                IntegerTicksOnly = true,
                LabelFormatter = (double x) => $"10^{x}",
            };
            formsPlot2.Plot.Axes.Bottom.TickGenerator = xTickGen;
            

            formsPlot2.Plot.Axes.AutoScaleX(); 
            formsPlot2.Plot.Axes.SetLimitsX(0, 2); //对应x值，是1-10^2

                formsPlot2.Plot.XLabel("Frequency/Hz");
                formsPlot2.Plot.YLabel("Amplitude/A");
                scatter.LegendText = "1";
                scatter.LineWidth = 1;
                scatter.MarkerSize = 1;

                formsPlot2.Refresh();


            }

        }

        public void export_PNG(object sender, EventArgs e)
        {
            Logger.Info("正在导出频率域图像为PNG - func export_PNG in UserContol2 ");
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "保存频率域图像为PNG";
                saveFileDialog.FileName = "frequency_plot.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //formsPlot2.Plot.SavePng(saveFileDialog.FileName);

                        Logger.Info($"频率域图像成功导出为PNG: {saveFileDialog.FileName}");
                        MessageBox.Show("频率域图像已成功导出为PNG", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"导出频率域图像为PNG时发生错误: {ex.Message}", ex);
                        MessageBox.Show("导出频率域图像失败，请重试", "导出失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }







            }
        }
    }
}




