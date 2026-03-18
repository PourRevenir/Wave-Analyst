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
            退出ToolStripMenuItem = new ToolStripMenuItem();
            编辑ToolStripMenuItem = new ToolStripMenuItem();
            选项ToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            分析ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 编辑ToolStripMenuItem, 选项ToolStripMenuItem, toolStripComboBox1, 分析ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 保存ToolStripMenuItem, 另存为ToolStripMenuItem, 打印ToolStripMenuItem, 导出ToolStripMenuItem, 退出ToolStripMenuItem });
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
            // 另存为ToolStripMenuItem
            // 
            另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            另存为ToolStripMenuItem.Size = new Size(224, 26);
            另存为ToolStripMenuItem.Text = "另存为";
            另存为ToolStripMenuItem.Click += 另存为ToolStripMenuItem_Click;
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
            导出ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pNG图片ToolStripMenuItem, jPG图片ToolStripMenuItem });
            导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            导出ToolStripMenuItem.Size = new Size(224, 26);
            导出ToolStripMenuItem.Text = "导出";
            // 
            // pNG图片ToolStripMenuItem
            // 
            pNG图片ToolStripMenuItem.Name = "pNG图片ToolStripMenuItem";
            pNG图片ToolStripMenuItem.Size = new Size(224, 26);
            pNG图片ToolStripMenuItem.Text = "PNG图片";
            pNG图片ToolStripMenuItem.Click += PNG图片ToolStripMenuItem_Click;
            // 
            // jPG图片ToolStripMenuItem
            // 
            jPG图片ToolStripMenuItem.Name = "jPG图片ToolStripMenuItem";
            jPG图片ToolStripMenuItem.Size = new Size(224, 26);
            jPG图片ToolStripMenuItem.Text = "JPG图片";
            jPG图片ToolStripMenuItem.Click += JPG图片ToolStripMenuItem_Click;
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(224, 26);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            // 
            // 编辑ToolStripMenuItem
            // 
            编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            编辑ToolStripMenuItem.Size = new Size(53, 28);
            编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 选项ToolStripMenuItem
            // 
            选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            选项ToolStripMenuItem.Size = new Size(53, 28);
            选项ToolStripMenuItem.Text = "选项";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 28);
            // 
            // 分析ToolStripMenuItem
            // 
            分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            分析ToolStripMenuItem.Size = new Size(53, 28);
            分析ToolStripMenuItem.Text = "分析";
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
            Text = "MainForm";
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
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 选项ToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem 分析ToolStripMenuItem;
        private ToolStripMenuItem pNG图片ToolStripMenuItem;
        private ToolStripMenuItem jPG图片ToolStripMenuItem;
    }
}