using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Channel : Form
    {
        private int rowCount = 0; // 当前行数（从0开始，但显示从1开始）

        public Channel()
        {
            InitializeComponent();

            // 初始化 TableLayoutPanel 列样式
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // 序号列
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85)); // 输入框列

            
            tableLayoutPanel1.AutoScroll = true;      // 滚动条（如果行太多）

            // 初始添加第 1 行（序号1）
            AddInputRow("1", "1,4,8,16");
            AddInputRow("2", "");
            AddInputRow("3", "");
            AddInputRow("4", "");
            AddInputRow("5", "");
            AddInputRow("6", "");
            AddInputRow("7", "");
            AddInputRow("8", "");
            AddInputRow("9", "");
        }

        // 动态添加“输入行”
        private void AddInputRow(string labelText, string defaultValue = "")
        {
            rowCount++; // 行数+1
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
         
            Label lbl = new Label
            {
                Text = labelText,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(5, 8, 0, 0), // 上下居中
                Font = new Font("Microsoft YaHei", 9)
            };
            TextBox txt = new TextBox
            {
                Text = defaultValue,
                Width = 200, // 固定宽度，避免过窄
                Anchor = AnchorStyles.Left | AnchorStyles.Right, // 拉伸适应列宽
                Margin = new Padding(0, 5, 5, 0)
            };

            // 添加到 TableLayoutPanel
            tableLayoutPanel1.Controls.Add(lbl, 0, rowCount - 1);
            tableLayoutPanel1.Controls.Add(txt, 1, rowCount - 1);
        }

        // 加法
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string newLabel = (rowCount + 1).ToString(); // 下一个序号 
            AddInputRow(newLabel);
        }


        // 减法
        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            if (rowCount > 1) // 至少保留“1”
            {
                int lastRowIndex = rowCount - 1; // 最后一行索引
                var controlsToRemove = tableLayoutPanel1.Controls
                    .Cast<Control>()
                    .Where(c => tableLayoutPanel1.GetRow(c) == lastRowIndex)
                    .ToList();

                // 移除控件
                foreach (var ctrl in controlsToRemove)
                {
                    tableLayoutPanel1.Controls.Remove(ctrl);
                }  
                tableLayoutPanel1.RowStyles.RemoveAt(lastRowIndex);
                tableLayoutPanel1.RowCount--;
                rowCount--;
            }
        }

        // 导入信号按钮（示例）
        private void BtnImportSignal_Click(object sender, EventArgs e)
        {



        }
    }
}