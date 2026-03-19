using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinFormsApp
{
    public partial class UserControl1 : UserControl
    {

        //定义公共接口 绘图
        private List<double> _timeList = new List<double>();
        public List<double> timeList
        {
            get { return _timeList; }// 读
            set { _timeList = value; } //写
        }

        private List<double> _amplitudeList = new List<double>();
        public List<double> amplitudeList
        {
            get { return _amplitudeList; }
            set { _amplitudeList = value; }
        }


        public UserControl1()
        {
            InitializeComponent();
            formsPlot1.Plot.Clear();
            formsPlot1.Refresh();
        }


       
        public void LoadData(List<double> times, List<double> amplitudes)
        {
            _timeList = times;
            _amplitudeList = amplitudes;
            DrawTimeSignal(_timeList, _amplitudeList);  // 加载完立刻绘制
        }

        // 绘制时间域信号图像
        private void DrawTimeSignal(List<double> _timeList, List<double> _amplitudeList)
        {
            if (_timeList.Count == 0 || _amplitudeList.Count == 0)
            {
                MessageBox.Show("userControl: 时间列表和幅值列表不能为空。");
                return;
            }
            if (_timeList.Count != _amplitudeList.Count)
            {
                MessageBox.Show("userControl: 时间列表和幅值列表长度必须相同。");
                return;
            }

            // 清除之前的图像
            formsPlot1.Plot.Clear();

            double[] timeArray = _timeList.ToArray();

            double[] ampArray = _amplitudeList.ToArray();                // 幅值数组
            // 绘制新的时间域信号图像
            formsPlot1.Plot.Add.Scatter(timeArray, ampArray);
            formsPlot1.Refresh();
        }


    }
}
