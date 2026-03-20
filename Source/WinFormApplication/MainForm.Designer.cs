namespace WinFormApplication
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
            打印ToolStripMenuItem = new ToolStripMenuItem();
            导出ToolStripMenuItem = new ToolStripMenuItem();
            退出ToolStripMenuItem = new ToolStripMenuItem();
            通道ToolStripMenuItem = new ToolStripMenuItem();
            信号入栈ToolStripMenuItem = new ToolStripMenuItem();
            信号出栈ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripComboBox1 = new ToolStripComboBox();
            分析ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 通道ToolStripMenuItem, ToolStripComboBox1, 分析ToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 保存ToolStripMenuItem, 打印ToolStripMenuItem, 导出ToolStripMenuItem, 退出ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(53, 28);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            打开ToolStripMenuItem.Size = new Size(224, 26);
            打开ToolStripMenuItem.Text = "打开";
            打开ToolStripMenuItem.Click += 打开ToolStripMenuItem_Click;
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(224, 26);
            保存ToolStripMenuItem.Text = "保存";
            保存ToolStripMenuItem.Click += 保存ToolStripMenuItem_Click;
            // 
            // 打印ToolStripMenuItem
            // 
            打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            打印ToolStripMenuItem.Size = new Size(224, 26);
            打印ToolStripMenuItem.Text = "打印";
            打印ToolStripMenuItem.Click += 打印ToolStripMenuItem_Click;
            // 
            // 导出ToolStripMenuItem
            // 
            导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            导出ToolStripMenuItem.Size = new Size(224, 26);
            导出ToolStripMenuItem.Text = "导出";
            导出ToolStripMenuItem.Click += 导出ToolStripMenuItem_Click;
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(224, 26);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            // 
            // 通道ToolStripMenuItem
            // 
            通道ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 信号入栈ToolStripMenuItem, 信号出栈ToolStripMenuItem });
            通道ToolStripMenuItem.Name = "通道ToolStripMenuItem";
            通道ToolStripMenuItem.Size = new Size(53, 28);
            通道ToolStripMenuItem.Text = "通道";
            // 
            // 信号入栈ToolStripMenuItem
            // 
            信号入栈ToolStripMenuItem.Name = "信号入栈ToolStripMenuItem";
            信号入栈ToolStripMenuItem.Size = new Size(152, 26);
            信号入栈ToolStripMenuItem.Text = "信号入栈";
            信号入栈ToolStripMenuItem.Click += 信号入栈ToolStripMenuItem_Click;
            // 
            // 信号出栈ToolStripMenuItem
            // 
            信号出栈ToolStripMenuItem.Name = "信号出栈ToolStripMenuItem";
            信号出栈ToolStripMenuItem.Size = new Size(152, 26);
            信号出栈ToolStripMenuItem.Text = "信号出栈";
            信号出栈ToolStripMenuItem.Click += 信号出栈ToolStripMenuItem_Click;
            // 
            // ToolStripComboBox1
            // 
            ToolStripComboBox1.Name = "ToolStripComboBox1";
            ToolStripComboBox1.Size = new Size(121, 28);
            ToolStripComboBox1.Click += ToolStripComboBox1_Click_1;
            // 
            // 分析ToolStripMenuItem
            // 
            分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            分析ToolStripMenuItem.Size = new Size(53, 28);
            分析ToolStripMenuItem.Text = "分析";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 28);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wave Analyst";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 通道ToolStripMenuItem;
        private ToolStripMenuItem 分析ToolStripMenuItem;
        private ToolStripMenuItem 信号入栈ToolStripMenuItem;
        private ToolStripMenuItem 信号出栈ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 打印ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 导出ToolStripMenuItem;
        private ToolStripComboBox ToolStripComboBox1;
    }
}