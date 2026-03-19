using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp

{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
           //初始化
        }


        //用ToolStripMenuItem.DropDownItems.AddRange
        // ToolStripBox 改用Item

        //*********************UserControl*****************************

        // 用户组件userControl：时间域 UserControl1.cs 频谱
        // 子窗体childForm：
        // 另存 ， 选项设置，处理下的FFT频谱分析、PSD功率谱分析、Hann窗FFT、Hamming窗FFT、Blackman窗FFT  和 分析












        //********************** 菜单项事件处理函数**********************
        /// <summary>
        /// 导入时间域信号文件，生成时间域信号图像，并保存到内存中
        /// </summary>
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // 存储时间和幅值数据 以及文件名 map绑定

            List<double> timeList = new List<double>();
            List<double> amplitudeList = new List<double>();
            List<double> frequencyList_f = new List<double>();
            List<double> amplitudeList_f = new List<double>();

            // OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 文件过滤器
            openFileDialog.Filter = "CSV文件 (*.csv)|*.csv|所有文件 (*.*)|*.*";
            openFileDialog.Title = "选择时间域信号文件";
            openFileDialog.Multiselect = false;  // 不允许多选

            // 显示对话框并检查用户是否点击了"打开"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    // 读取CSV文件
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    // 跳过第一行（表头）
                    for (int i = 1; i < lines.Length; i++)
                    {
                        // 跳过空行
                        if (string.IsNullOrWhiteSpace(lines[i]))
                            continue;

                        // 按逗号分隔
                        string[] values = lines[i].Split(',');

                        // 至少有两列数据
                        if (values.Length >= 2)
                        {
                            // 解析时间
                            if (double.TryParse(values[0], out double time))
                            {
                                timeList.Add(time);
                            }

                            // 解析幅值
                            if (double.TryParse(values[1], out double amplitude))
                            {
                                amplitudeList.Add(amplitude);
                            }
                        }
                    }

                    // 检查是否有有效数据
                    if (timeList.Count == 0 || amplitudeList.Count == 0)
                    {
                        MessageBox.Show("Mainform:文件中没有有效的数据！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }



                    // 检查userControl组件是否已存在
                    // 如果已经存在，先移除旧的组件
                    if (this.Controls.OfType<UserControl1>().Any())
                    {
                        var existingControl = this.Controls.OfType<UserControl1>().First();
                        this.Controls.Remove(existingControl);
                        existingControl.Dispose(); // 释放资源
                    }

                    // 数据交给UserControl1显示，通过公共接口传递数据

                    // 显示用户组件
                    UserControl1 userControl_t = new UserControl1();
                    //添加到窗口中显示Form.ControlCollection.Add(Control) 方法
                    tableLayoutPanel1.Controls.Add(userControl_t, 0, 0);

                    // 控件属性
                    userControl_t.Dock = DockStyle.Fill;  // 填满容器

                    // 绘制
                    userControl_t.LoadData(timeList, amplitudeList);

                    //userControl.timeList= timeList;
                    //userControl.amplitudeList = amplitudeList;





                    // 频率域信号
                    if (this.Controls.OfType<UserControl2>().Any())
                    {
                        var existingControl = this.Controls.OfType<UserControl2>().First();
                        this.Controls.Remove(existingControl);
                        existingControl.Dispose();
                    }
                    UserControl2 userControl_f = new UserControl2();
                    tableLayoutPanel1.Controls.Add(userControl_f,0,1);
                    userControl_f.Dock = DockStyle.Fill;

                    (double[] Frequencies, double[] Amplitudes) = FFT.SimpleFFT(timeList, amplitudeList);
                    frequencyList_f = Frequencies.ToList();
                    amplitudeList_f = Amplitudes.ToList();

                    userControl_f.LoadData(frequencyList_f, amplitudeList_f);















                    MessageBox.Show($"成功导入 {timeList.Count} 个数据点！", "成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"读取文件时发生错误：\n{ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

     
        }


        //********************** 菜单项事件处理函数**********************












    }
}
