namespace WinFormsApp.Forms.Channel
{
    partial class Channel
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(22, 304);
            button1.Name = "button1";
            button1.Size = new Size(79, 35);
            button1.TabIndex = 1;
            button1.Text = "增加信号数";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnAdd_Click;
            // 
            // button2
            // 
            button2.Location = new Point(107, 304);
            button2.Name = "button2";
            button2.Size = new Size(79, 35);
            button2.TabIndex = 2;
            button2.Text = "减少信号数";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnSubtract_Click;
            // 
            // button3
            // 
            button3.Location = new Point(305, 304);
            button3.Name = "button3";
            button3.Size = new Size(79, 35);
            button3.TabIndex = 3;
            button3.Text = "导入信号";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnImportSignal_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Location = new Point(22, 47);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(247, 228);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Channel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 361);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Channel";
            Text = "Channel";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel1;
    }
}