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

        }
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
    }
}
