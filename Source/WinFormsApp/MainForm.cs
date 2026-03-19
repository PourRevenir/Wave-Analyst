<<<<<<< HEAD
﻿using System;
=======
﻿using ScottPlot.Colormaps;
using SkiaSharp.Views.Desktop;
using System;
>>>>>>> 047d8bf27cccca3a1b8540f9c3bb828630f9b5c2
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

        }
<<<<<<< HEAD
=======


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
>>>>>>> 047d8bf27cccca3a1b8540f9c3bb828630f9b5c2
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
<<<<<<< HEAD
                ofd.Filter = "文本文件(*.txt)|*.txt|DAT文件(*.dat)|*.dat";
                if(ofd.ShowDialog() == DialogResult.OK) { }
=======
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
>>>>>>> 047d8bf27cccca3a1b8540f9c3bb828630f9b5c2
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

<<<<<<< HEAD
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "文本文件(*.txt)|*.txt|DAT文件(*.dat)|*.dat";
                if (sfd.ShowDialog() == DialogResult.OK) { }
            }
        }
=======


        // 通道  子窗体


        private void 通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (!checkChildFrmExist("Channel"))
            {

                Channel channel = new Channel();//加载Chanel 

                channel.MdiParent = null;//独立窗口

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





>>>>>>> 047d8bf27cccca3a1b8540f9c3bb828630f9b5c2

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
    }
}
