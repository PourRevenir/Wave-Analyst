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

using WinFormsApp.Forms.Channel;

using WinFormsApp.UserControls;
using WinFormsApp.Log;
using 时间域绘图测试;



namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Logger.Info("*********************");
            InitializeComponent();
            this.IsMdiContainer = true;// MDI
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

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
            Logger.Info("打开文件对话框已显示，等待用户选择文件...");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 读取
                    string fileContent = File.ReadAllText(openFileDialog.FileName).Trim();
                    Logger.Info($"文件已选择: {openFileDialog.FileName} ，文件内容是：{fileContent}");

                    if (string.IsNullOrWhiteSpace(fileContent))
                    {
                        MessageBox.Show("文件内容为空！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string[] values = fileContent.Split(',');
                    Logger.Info($"文件内容已解析为{values}且有 {values.Length} 个数据点。");
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
                    Logger.Info($"文件处理完成，通道数: {channelNumber}，频率数据点: {frequency}。");
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
            Logger.Info("开始处理用户控件的加载和显示，函数ProcessUserControls运行");
            UpdateTimeDomainControl(frequency, channelNumber);
            UpdateFrequencyDomainControl(frequency, channelNumber);
        }


        /// <summary>
        /// 更新时域
        /// </summary>
        private void UpdateTimeDomainControl(List<double> frequency, int channelNumber)
        {

            //RemoveExistingControl<UserControl1>();
            //UserControl1 userControl_t = new UserControl1
            //{
            //    Dock = DockStyle.Fill
            //};
            //tableLayoutPanel1.Controls.Add(userControl_t, 0, 0);
            //userControl_t.LoadData(frequency, channelNumber);
            if (!checkChildFrmExist("Form1"))
            {
                Form1 time_ = new Form1();
                //channel.MdiParent = null;//独立窗口
                // 紧贴父窗口下部
                time_.FormBorderStyle = FormBorderStyle.FixedDialog; // 或 FixedToolWindow
                time_.StartPosition = FormStartPosition.Manual;
                int x = this.Left;
                int y = this.Top + this.Height; // 父窗口顶部 + 父窗口高度
                time_.Location = new Point(x, y);
                time_.Show();
                //time_.ShowDialog();
            }


        }



        /// <summary>
        /// 更新频域用户控件
        /// </summary>
        private void UpdateFrequencyDomainControl(List<double> frequency, int channelNumber)
        {

            RemoveExistingControl<UserControl2>();
            // 创建两个频域用户控件会显示两个
            UserControl2 userControl_f_1 = new UserControl2
            {
                Dock = DockStyle.Fill
            };
            UserControl2 userControl_f_2 = new UserControl2
            {
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(userControl_f_1, 0, 0);
            tableLayoutPanel1.Controls.Add(userControl_f_2, 0, 1);
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
                channel.FormBorderStyle = FormBorderStyle.FixedDialog; // 或 FixedToolWindow
                channel.StartPosition = FormStartPosition.Manual;
                int x = this.Right;
                int y = this.Top; // 父窗口顶部 + 父窗口高度
                channel.Location = new Point(x, y);

                //channel.MdiParent = null;//独立窗口
                channel.ShowDialog();
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

        private void pNG图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }
    }
}
