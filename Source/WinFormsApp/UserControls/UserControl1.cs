using ScottPlot.ArrowShapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Method;



namespace WinFormsApp.UserControls

{
    public partial class UserControl1 : UserControl
    {

        //定义公共接口 绘图
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

        public UserControl1()
        {
            InitializeComponent();
            formsPlot1.Plot.Clear();
            formsPlot1.Refresh();
        }

        public void LoadData(List<double> times, int channelNumber)
        {
            _frequency = frequency;
            _channelNumber = channelNumber;
            DrawTimeSignal(_frequency, _channelNumber);  // 加载完立刻绘制
        }

        // 绘制时间域信号图像

       
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
