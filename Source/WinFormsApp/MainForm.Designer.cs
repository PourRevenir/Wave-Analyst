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
            menuStrip1.Size = new Size(1139, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 保存ToolStripMenuItem, 另存为ToolStripMenuItem, 打印ToolStripMenuItem, 导出ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(53, 28);
            文件ToolStripMenuItem.Text = "文件";
            文件ToolStripMenuItem.Click += 文件ToolStripMenuItem_Click;
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
            // 
            // 另存为ToolStripMenuItem
            // 
            另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            另存为ToolStripMenuItem.Size = new Size(224, 26);
            另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 打印ToolStripMenuItem
            // 
            打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            打印ToolStripMenuItem.Size = new Size(224, 26);
            打印ToolStripMenuItem.Text = "打印";
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
            pNG图片ToolStripMenuItem.Size = new Size(154, 26);
            pNG图片ToolStripMenuItem.Text = "PNG图片";
            // 
            // jPG图片ToolStripMenuItem
            // 
            jPG图片ToolStripMenuItem.Name = "jPG图片ToolStripMenuItem";
            jPG图片ToolStripMenuItem.Size = new Size(154, 26);
            jPG图片ToolStripMenuItem.Text = "JPG图片";
            // 
            // 编辑ToolStripMenuItem
            // 
            编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            编辑ToolStripMenuItem.Size = new Size(53, 28);
            编辑ToolStripMenuItem.Text = "编辑";
            编辑ToolStripMenuItem.Click += 编辑ToolStripMenuItem_Click;
            // 
            // 选项ToolStripMenuItem
            // 
            选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            选项ToolStripMenuItem.Size = new Size(53, 28);
            选项ToolStripMenuItem.Text = "选项";
            选项ToolStripMenuItem.Click += 选项ToolStripMenuItem_Click;
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 28);
            toolStripComboBox1.Click += toolStripComboBox1_Click;
            // 
            // 分析ToolStripMenuItem
            // 
            分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            分析ToolStripMenuItem.Size = new Size(53, 28);
            分析ToolStripMenuItem.Text = "分析";
            分析ToolStripMenuItem.Click += 分析ToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 625);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
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
        private ToolStripMenuItem pNG图片ToolStripMenuItem;
        private ToolStripMenuItem jPG图片ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 选项ToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem 分析ToolStripMenuItem;
    }
}