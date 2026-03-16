using ScottPlot.WinForms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            menuStrip1 = new MenuStrip();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            打开ToolStripMenuItem = new ToolStripMenuItem();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            另存为ToolStripMenuItem = new ToolStripMenuItem();
            关闭ToolStripMenuItem = new ToolStripMenuItem();
            编辑ToolStripMenuItem = new ToolStripMenuItem();
            添加区间ToolStripMenuItem = new ToolStripMenuItem();
            删除区间ToolStripMenuItem = new ToolStripMenuItem();
            选项ToolStripMenuItem = new ToolStripMenuItem();
            分析ToolStripMenuItem = new ToolStripMenuItem();
            formsPlot1 = new FormsPlot();
            formsPlot2 = new FormsPlot();
            formsPlot3 = new FormsPlot();
            formsPlot4 = new FormsPlot();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 731);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(982, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 编辑ToolStripMenuItem, 选项ToolStripMenuItem, 分析ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(982, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.BackColor = SystemColors.Control;
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 保存ToolStripMenuItem, 另存为ToolStripMenuItem, 关闭ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(53, 24);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            打开ToolStripMenuItem.Size = new Size(224, 26);
            打开ToolStripMenuItem.Text = "打开";
            打开ToolStripMenuItem.Click += openFileToolStripMenuItem_Click;

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
            // 关闭ToolStripMenuItem
            // 
            关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            关闭ToolStripMenuItem.Size = new Size(224, 26);
            关闭ToolStripMenuItem.Text = "关闭";
            // 
            // 编辑ToolStripMenuItem
            // 
            编辑ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 添加区间ToolStripMenuItem, 删除区间ToolStripMenuItem });
            编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            编辑ToolStripMenuItem.Size = new Size(53, 24);
            编辑ToolStripMenuItem.Text = "通道";
            // 
            // 添加区间ToolStripMenuItem
            // 
            添加区间ToolStripMenuItem.Name = "添加区间ToolStripMenuItem";
            添加区间ToolStripMenuItem.Size = new Size(152, 26);
            添加区间ToolStripMenuItem.Text = "添加区间";
            // 
            // 删除区间ToolStripMenuItem
            // 
            删除区间ToolStripMenuItem.Name = "删除区间ToolStripMenuItem";
            删除区间ToolStripMenuItem.Size = new Size(152, 26);
            删除区间ToolStripMenuItem.Text = "删除区间";
            // 
            // 选项ToolStripMenuItem
            // 
            选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            选项ToolStripMenuItem.Size = new Size(53, 24);
            选项ToolStripMenuItem.Text = "选项";
            // 
            // 分析ToolStripMenuItem
            // 
            分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            分析ToolStripMenuItem.Size = new Size(53, 24);
            分析ToolStripMenuItem.Text = "分析";
            // 
            // formsPlot1
            // 
            formsPlot1.Cursor = Cursors.Hand;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Font = new Font("Noto Sans SC", 13.7999992F, FontStyle.Italic, GraphicsUnit.Point, 134);
            formsPlot1.ForeColor = SystemColors.Control;
            formsPlot1.Location = new Point(74, 59);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(780, 198);
            formsPlot1.TabIndex = 2;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(74, 298);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(388, 188);
            formsPlot2.TabIndex = 3;
            // 
            // formsPlot3
            // 
            formsPlot3.DisplayScale = 1.25F;
            formsPlot3.Location = new Point(483, 298);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(371, 188);
            formsPlot3.TabIndex = 4;
            // 
            // formsPlot4
            // 
            formsPlot4.Cursor = Cursors.Hand;
            formsPlot4.DisplayScale = 1.25F;
            formsPlot4.Font = new Font("Noto Sans SC", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 134);
            formsPlot4.ForeColor = SystemColors.Control;
            formsPlot4.Location = new Point(74, 510);
            formsPlot4.Name = "formsPlot4";
            formsPlot4.Size = new Size(780, 198);
            formsPlot4.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(407, 46);
            label1.Name = "label1";
            label1.Size = new Size(155, 21);
            label1.TabIndex = 6;
            label1.Text = "Time domain signal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(654, 288);
            label5.Name = "label5";
            label5.Size = new Size(66, 21);
            label5.TabIndex = 10;
            label5.Text = "Signal2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 288);
            label4.Name = "label4";
            label4.Size = new Size(66, 21);
            label4.TabIndex = 9;
            label4.Text = "Singal1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(982, 753);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(formsPlot4);
            Controls.Add(formsPlot3);
            Controls.Add(formsPlot2);
            Controls.Add(formsPlot1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Noto Sans SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = true;
            ShowIcon = false;
            Text = "PRS";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 选项ToolStripMenuItem;
        private ToolStripMenuItem 分析ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 另存为ToolStripMenuItem;
        private ToolStripMenuItem 关闭ToolStripMenuItem;
        private ToolStripMenuItem 添加区间ToolStripMenuItem;
        private ToolStripMenuItem 删除区间ToolStripMenuItem;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private ScottPlot.WinForms.FormsPlot formsPlot3;
        private ScottPlot.WinForms.FormsPlot formsPlot4;
        private Label label1;
        private Label label5;
        private Label label4;
    }
}
