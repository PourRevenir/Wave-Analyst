namespace 时间域绘图测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<double> _frequency=new List<double>();
            _frequency = [1, 2, 4, 8, 16, 32];

            DrawTimeSignal(_frequency, 1);
        }

        private void DrawTimeSignal(List<double> _frequency, int channelNumbert)
        {

            // 将频率列表转换为数组
            double[] ct_frequency = _frequency.ToArray();

            var ct = new ChannelTask();
            ct.AddInterval(samplingTime: 2, frequencyList: ct_frequency);

            // 用于存储所有信号数据
            List<int> allSignals = new List<int>();

            // 遍历每个信号区间
            for (int i = 0; i < ct.SignalIntervals.Count; i++)
            {
                var signal = ct.SignalIntervals[i];
                foreach (var sample in signal.Signal)
                {
                    allSignals.Add(sample);
                }
            }

            int n = allSignals.Count;
            double[] t_data = new double[n];
            double timeStep = 2.0 / (n - 1);

            for (int i = 0; i < n; i++)
            {
                t_data[i] = i * timeStep;  // 从 0 到 2
            }

            // 将信号数据转换为 double 数组
            double[] signal_Data = allSignals.Select(s => (double)s).ToArray();


            formsPlot1.Plot.XLabel("Time/s");      // 改为时间
            formsPlot1.Plot.YLabel("Amplitude/A");

            // 清除之前的绘图
            formsPlot1.Plot.Clear();

            // 创建散点图（时域信号）
            var scatter = formsPlot1.Plot.Add.Scatter(t_data, signal_Data);
            scatter.LegendText = "Channel " + channelNumbert;
            scatter.LineWidth = 1;
            scatter.MarkerSize = 1;

            // 自动调整坐标轴范围
            formsPlot1.Plot.Axes.AutoScale();

            formsPlot1.Refresh();
        }

    }
}



    