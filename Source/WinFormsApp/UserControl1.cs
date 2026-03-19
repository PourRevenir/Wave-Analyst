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
        public List<double> TimeList
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
        }


        // 绘制时间域信号图像
        private void DrawTimeSignal()
        {
            if (_timeList.Count == 0 || amplitudeList.Count == 0 || TimeList.Count != amplitudeList.Count)
            {
                MessageBox.Show("时间列表和幅值列表不能为空且长度必须相同。");
                return;
            }
            // 清除之前的图像
            formsPlot1.Plot.Clear();

            double[] timeArray = _timeList.Select(t => t + 1).ToArray(); // 用 LINQ 给每个元素 +1
            double[] ampArray = _amplitudeList.ToArray();                // 幅值数组
            // 绘制新的时间域信号图像
            formsPlot1.Plot.Add.Scatter(timeArray, ampArray);
            formsPlot1.Refresh();
        }


    }
}
