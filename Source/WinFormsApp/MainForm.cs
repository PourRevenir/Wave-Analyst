using ScottPlot.Colormaps;
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
            this.IsMdiContainer = true;// MDI
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
           //初始化
        }

        // 用户组件userControl：时间域 UserControl1.cs 频谱
        // 子窗体childForm：
        // 另存 ， 选项设置，处理下的FFT频谱分析、PSD功率谱分析、Hann窗FFT、Hamming窗FFT、Blackman窗FFT  和 分析

        //********************** 菜单项事件处理函数**********************
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int channelNumber = 0;
            List<double> frequency = new List<double>();

            // OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "WA文件 (*.wa)|*.wa|所有文件 (*.*)|*.*",
                Title = "选择信号文件",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 读取
                    string fileContent = File.ReadAllText(openFileDialog.FileName).Trim();
                    MessageBox.Show($"原始文件内容:\n{fileContent}\n\n内容长度: {fileContent.Length}",
                   "调试信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrWhiteSpace(fileContent))
                    {
                        MessageBox.Show("文件内容为空！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string[] values = fileContent.Split(',');

                    if (values.Length < 2)
                    {
                        MessageBox.Show("文件格式错误：至少需要2个数据点！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 解析通道数
                    if (!int.TryParse(values[0], out channelNumber) || channelNumber < 1)
                    {
                        MessageBox.Show("文件格式错误：第一个值必须是有效的通道数（正整数）！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 解析频率数据
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (double.TryParse(values[i], out double value))
                        {
                            frequency.Add(value);
                        }
                    }

                    // 检查是否有有效数据
                    if (frequency.Count == 0)
                    {
                        MessageBox.Show("文件中没有有效的频率数据！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 处理用户控件
                    ProcessUserControls(frequency, channelNumber);

                    MessageBox.Show($"成功导入数据\n通道数: {channelNumber}\n数据点数: {frequency.Count}",
                        "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"读取文件时发生错误：\n{ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 处理用户控件的加载和显示
        /// </summary>
        private void ProcessUserControls(List<double> frequency, int channelNumber)
        {
            
            UpdateTimeDomainControl(frequency, channelNumber);
            UpdateFrequencyDomainControl(frequency, channelNumber);
        }

        /// <summary>
        /// 更新时域用户控件
        /// </summary>
        private void UpdateTimeDomainControl(List<double> frequency, int channelNumber)
        {
            // 移除已存在
            RemoveExistingControl<UserControl1>();

            // 创建
            UserControl1 userControl_t = new UserControl1
            {
                Dock = DockStyle.Fill
            };

            // 添加到布局
            tableLayoutPanel1.Controls.Add(userControl_t, 0, 0);

           
            // 加载数据
            userControl_t.LoadData(frequency, channelNumber);
        }



        /// <summary>
        /// 更新频域用户控件
        /// </summary>
        private void UpdateFrequencyDomainControl(List<double> frequency, int channelNumber)
        {
            
            RemoveExistingControl<UserControl2>();

            // 创建两个频域用户控件只会显示一个
            UserControl2 userControl_f_1 = new UserControl2
            {
                Dock = DockStyle.Fill
            };

            UserControl2 userControl_f_2 = new UserControl2
            {
                Dock = DockStyle.Fill
            };

            tableLayoutPanel1.Controls.Add(userControl_f_1, 0, 1);

            tableLayoutPanel1.Controls.Add(userControl_f_2, 0, 2);

            userControl_f_1.LoadData(frequency, channelNumber);
            userControl_f_2.LoadData(frequency, channelNumber);
        }


        /// <summary>
        /// 移除已存在的指定类型用户控件
        /// </summary>
        private void RemoveExistingControl<T>() where T : UserControl
        {
            var existingControls = this.tableLayoutPanel1.Controls.OfType<T>().ToList();

            foreach (var control in existingControls)
            {
                tableLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }
        }



        // 通道  子窗体


        private void 通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkChildFrmExist("Channel"))
            {
                Channel channel = new Channel();//加载Chanel 
                 //channel.MdiParent = null;//独立窗口
                channel.Show();
            }
        }

        private bool checkChildFrmExist(string childFrmName)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                //用子窗体的Name进行判断，如果已经存在则将他激活
                if (childFrm.Name == childFrmName)
                {
                    if (childFrm.WindowState != FormWindowState.Maximized)
                    {
                        childFrm.WindowState = FormWindowState.Maximized;
                    }
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        //********************** 菜单项事件处理函数**********************












    }
}
