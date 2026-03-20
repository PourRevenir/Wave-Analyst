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



namespace WinFormsApp
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

            List<double> allSignals = new List<double>();
            for (int i = 0; i < _frequency.Count; i++)
            {


                double[] ct_frequency = _frequency.ToArray();
                var ct = new ChannelTask();
                ct.AddInterval(samplingTime: 2.0, frequencyList: ct_frequency);
                var signal = ct.SignalIntervals[i];
                allSignals.Add((double)signal.Signal[i]);
            }


            double[] data = GenerateUniformArray(allSignals.ToArray().Length);

            formsPlot1.Plot.XLabel("Frequency/Hz");
                formsPlot1.Plot.YLabel("Amplitude/A");

                var scatter = formsPlot1.Plot.Add.Scatter(allSignals.ToArray(),data );
                // 创建散点图


                scatter.LegendText = "1";
                scatter.LineWidth = 1;
                scatter.MarkerSize = 1;

                formsPlot1.Refresh();

            
        }

        static double[] GenerateUniformArray(int n, double min = 0.5, double max = 2.0)
        {
            if (n < 1) return new double[0];

            double[] arr = new double[n];
            double step = (max - min) / (n - 1);

            for (int i = 0; i < n; i++)
            {
                arr[i] = min + i * step;
            }

            return arr;
        }


    }
}
