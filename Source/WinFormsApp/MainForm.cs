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

<<<<<<< HEAD

        //用ToolStripMenuItem.DropDownItems.AddRange
        // ToolStripBox 改用Item

        //*********************UserControl*****************************

        // 用户组件userControl：时间域 频谱
        // 子窗体childForm：选项设置，处理下的FFT频谱分析、PSD功率谱分析、Hann窗FFT、Hamming窗FFT、Blackman窗FFT  和 分析












        //********************** 菜单项事件处理函数**********************
        /// <summary>
        /// 导入时间域信号文件，生成时间域信号图像，并保存到内存中
        /// </summary>
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
=======
        private void MainForm_Load(object sender, EventArgs e)
>>>>>>> d8b314ed1c8fee77cfe29d5e38c369cb5055b80c
        {

            // 存储时间和幅值数据 以及文件名 map绑定


            List<double> timeList = new List<double>();
            List<double> amplitudeList = new List<double>();


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

                        // 确保至少有两列数据
                        if (values.Length >= 2)
                        {
                            // 解析时间（第一列）
                            if (double.TryParse(values[0], out double time))
                            {
                                timeList.Add(time);
                            }

                            // 解析幅值（第二列）
                            if (double.TryParse(values[1], out double amplitude))
                            {
                                amplitudeList.Add(amplitude);
                            }
                        }
                    }

                    // 检查是否有有效数据
                    if (timeList.Count == 0 || amplitudeList.Count == 0)
                    {
                        MessageBox.Show("文件中没有有效的数据！", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 数据交给UserControl1显示，通过公共接口传递数据

                    // 显示用户组件
                    UserControl1 userControl = new UserControl1();

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
<<<<<<< HEAD








        private void 分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //********************** 菜单项事件处理函数**********************

=======
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "文本文件(*.txt)|*.txt|DAT文件(*.dat)|*.dat";
                if(ofd.ShowDialog() == DialogResult.OK) { }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "文本文件(*.txt)|*.txt|DAT文件(*.dat)|*.dat";
                if (sfd.ShowDialog() == DialogResult.OK) { }
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "文本文件(*.txt)|*.txt|DAT文件(*.dat)|*.dat";
                if (sfd.ShowDialog() == DialogResult.OK) { }
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                if(pd.ShowDialog() == DialogResult.OK) { }
            }
        }

        private void PNG图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG图片(*.png)|*.png";
                if (sfd.ShowDialog() == DialogResult.OK) { }
            }

        }

        private void JPG图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG图片(*.jpg)|*.jpg";
                if (sfd.ShowDialog() == DialogResult.OK) { }
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "确定要退出程序吗？",
                "确认退出",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
>>>>>>> d8b314ed1c8fee77cfe29d5e38c369cb5055b80c
    }
}
