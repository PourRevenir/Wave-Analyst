namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            打开ToolStripMenuItem = new ToolStripMenuItem();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            另存为ToolStripMenuItem = new ToolStripMenuItem();
            打印ToolStripMenuItem = new ToolStripMenuItem();
            导出ToolStripMenuItem = new ToolStripMenuItem();
            pNG图片ToolStripMenuItem = new ToolStripMenuItem();
            jPG图片ToolStripMenuItem = new ToolStripMenuItem();
            编辑ToolStripMenuItem = new ToolStripMenuItem();
            选项ToolStripMenuItem = new ToolStripMenuItem();
            处理ToolStripMenuItem = new ToolStripMenuItem();
            FFT频谱分析ToolStripMenuItem = new ToolStripMenuItem();
            PSD功率谱分析ToolStripMenuItem = new ToolStripMenuItem();
            Hann窗FFTToolStripMenuItem = new ToolStripMenuItem();
            Hamming窗FFTToolStripMenuItem = new ToolStripMenuItem();
            Blackman窗FFTToolStripMenuItem = new ToolStripMenuItem();
            分析ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 编辑ToolStripMenuItem, 选项ToolStripMenuItem, 处理ToolStripMenuItem, 分析ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1184, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 保存ToolStripMenuItem, 另存为ToolStripMenuItem, 打印ToolStripMenuItem, 导出ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(44, 21);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            打开ToolStripMenuItem.Size = new Size(180, 22);
            打开ToolStripMenuItem.Text = "打开";
            打开ToolStripMenuItem.Click += 打开ToolStripMenuItem_Click;
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(180, 22);
            保存ToolStripMenuItem.Text = "保存";
            // 
            // 另存为ToolStripMenuItem
            // 
            另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            另存为ToolStripMenuItem.Size = new Size(180, 22);
            另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 打印ToolStripMenuItem
            // 
            打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            打印ToolStripMenuItem.Size = new Size(180, 22);
            打印ToolStripMenuItem.Text = "打印";
            // 
            // 导出ToolStripMenuItem
            // 
            导出ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pNG图片ToolStripMenuItem, jPG图片ToolStripMenuItem });
            导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            导出ToolStripMenuItem.Size = new Size(180, 22);
            导出ToolStripMenuItem.Text = "导出";
            // 
            // pNG图片ToolStripMenuItem
            // 
            pNG图片ToolStripMenuItem.Name = "pNG图片ToolStripMenuItem";
            pNG图片ToolStripMenuItem.Size = new Size(126, 22);
            pNG图片ToolStripMenuItem.Text = "PNG图片";
            // 
            // jPG图片ToolStripMenuItem
            // 
            jPG图片ToolStripMenuItem.Name = "jPG图片ToolStripMenuItem";
            jPG图片ToolStripMenuItem.Size = new Size(126, 22);
            jPG图片ToolStripMenuItem.Text = "JPG图片";
            // 
            // 编辑ToolStripMenuItem
            // 
            编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            编辑ToolStripMenuItem.Size = new Size(44, 21);
            编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 选项ToolStripMenuItem
            // 
            选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            选项ToolStripMenuItem.Size = new Size(44, 21);
            选项ToolStripMenuItem.Text = "选项";
            // 
            // 处理ToolStripMenuItem
            // 
            处理ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { FFT频谱分析ToolStripMenuItem, PSD功率谱分析ToolStripMenuItem, Hann窗FFTToolStripMenuItem, Hamming窗FFTToolStripMenuItem, Blackman窗FFTToolStripMenuItem });
            处理ToolStripMenuItem.Name = "处理ToolStripMenuItem";
            处理ToolStripMenuItem.Size = new Size(44, 21);
            处理ToolStripMenuItem.Text = "处理";
            // 
            // FFT频谱分析ToolStripMenuItem
            // 
            FFT频谱分析ToolStripMenuItem.Name = "FFT频谱分析ToolStripMenuItem";
            FFT频谱分析ToolStripMenuItem.Size = new Size(163, 22);
            FFT频谱分析ToolStripMenuItem.Text = "FFT频谱分析";
            // 
            // PSD功率谱分析ToolStripMenuItem
            // 
            PSD功率谱分析ToolStripMenuItem.Name = "PSD功率谱分析ToolStripMenuItem";
            PSD功率谱分析ToolStripMenuItem.Size = new Size(163, 22);
            PSD功率谱分析ToolStripMenuItem.Text = "PSD功率谱分析";
            // 
            // Hann窗FFTToolStripMenuItem
            // 
            Hann窗FFTToolStripMenuItem.Name = "Hann窗FFTToolStripMenuItem";
            Hann窗FFTToolStripMenuItem.Size = new Size(163, 22);
            Hann窗FFTToolStripMenuItem.Text = "Hann窗FFT";
            // 
            // Hamming窗FFTToolStripMenuItem
            // 
            Hamming窗FFTToolStripMenuItem.Name = "Hamming窗FFTToolStripMenuItem";
            Hamming窗FFTToolStripMenuItem.Size = new Size(163, 22);
            Hamming窗FFTToolStripMenuItem.Text = "Hamming窗FFT";
            // 
            // Blackman窗FFTToolStripMenuItem
            // 
            Blackman窗FFTToolStripMenuItem.Name = "Blackman窗FFTToolStripMenuItem";
            Blackman窗FFTToolStripMenuItem.Size = new Size(163, 22);
            Blackman窗FFTToolStripMenuItem.Text = "Blackman窗FFT";
            // 
            // 分析ToolStripMenuItem
            // 
            分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            分析ToolStripMenuItem.Size = new Size(44, 21);
            分析ToolStripMenuItem.Text = "分析";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 3, 2, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wave";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 另存为ToolStripMenuItem;
        private ToolStripMenuItem 打印ToolStripMenuItem;
        private ToolStripMenuItem 导出ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 选项ToolStripMenuItem;
        private ToolStripMenuItem 处理ToolStripMenuItem;
        private ToolStripMenuItem FFT频谱分析ToolStripMenuItem;
        private ToolStripMenuItem PSD功率谱分析ToolStripMenuItem;
        private ToolStripMenuItem Hann窗FFTToolStripMenuItem;
        private ToolStripMenuItem Hamming窗FFTToolStripMenuItem;
        private ToolStripMenuItem Blackman窗FFTToolStripMenuItem;
        private ToolStripMenuItem 分析ToolStripMenuItem;
        private ToolStripMenuItem pNG图片ToolStripMenuItem;
        private ToolStripMenuItem jPG图片ToolStripMenuItem;
    }
}