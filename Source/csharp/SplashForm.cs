using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;//作用：移除窗体的边框（包括标题栏、关闭按钮、最小化按钮、边框等）。窗体变成一个无边框的矩形区域,可在Designer中修改
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Properties.Resources.splash; 
            this.BackgroundImageLayout = ImageLayout.Stretch;//拉伸
            this.ClientSize = new Size(916, 610); // 设置合适的大小
        }

    }

}