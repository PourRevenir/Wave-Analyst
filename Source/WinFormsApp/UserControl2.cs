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
    public partial class UserControl2 : UserControl
    {



        //定义公共接口 绘图
        private List<double> _frequencyList = new List<double>();
        public List<double> frequencyList_f
        {
            get { return _frequencyList; }// 读
            set { _frequencyList = value; } //写
        }

        private List<double> _amplitudeList = new List<double>();
        public List<double> amplitudeList_f
        {
            get { return _amplitudeList; }
            set { _amplitudeList = value; }
        }


        public UserControl2()
        {
            InitializeComponent();


        }


        // 绘制频率域信号图像
        public void LoadData(List<double> frequencyList_f, List<double> amplitudeList_f)
        {
            _frequencyList = frequencyList_f;
            _amplitudeList = amplitudeList_f;
            DrawfrequencySignal(_frequencyList, _amplitudeList);  // 加载完立刻绘制
        }

        private void DrawfrequencySignal(List<double> _frequencyList, List<double> _amplitudeList)
        {
            if (_frequencyList.Count == 0 || _amplitudeList.Count == 0)
            {
                MessageBox.Show("userControl: 频率列表和幅值列表不能为空。");
                return;
            }
            if (_frequencyList.Count != _amplitudeList.Count)
            {
                MessageBox.Show("userControl: 频率列表和幅值列表长度必须相同。");
                return;
            }

            // 清除之前的图像
            formsPlot2.Plot.Clear();

            double[] frequencyArray = _frequencyList.ToArray();

            double[] ampArray = _amplitudeList.ToArray();                // 幅值数组
            // 绘制新的时间域信号图像
            formsPlot2.Plot.Add.Scatter(frequencyArray, ampArray);
            formsPlot2.Plot.XLabel("Frequency (Hz)");

            formsPlot2.Refresh();
        }

        private void formsPlot2_Load(object sender, EventArgs e)
        {

        }
    }






}
