using ScottPlot.WinForms;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        // 存储原始信号数据
        private double[] _timeData;      // 时间序列
        private double[] _amplitudeData;  // 幅值序列

                                          // 其他辅助变量
        private double _samplingRate = 1000;  // 默认采样率（Hz）
        private string _currentFileName = "";  // 当前加载的文件名


        public Form1()
        {
            InitializeComponent();
            // 
            this.Size = new Size(1000, 800);
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            //

            // SetMyRightMenu(formsPlot1);

            formsPlot1.Refresh();


        }

        // 自定义菜单方法
        private void SetMyRightMenu(ScottPlot.WinForms.FormsPlot formsPlot)
        {
            // 清空原有菜单
            formsPlot.Menu?.Clear();

            // 添加保存功能
            formsPlot.Menu?.Add("保存", (plot) =>
            {
                SaveFileDialog saveImageDialog = new SaveFileDialog();
                saveImageDialog.Title = "图像另存为";
                saveImageDialog.Filter = "svg矢量图|*.svg|jpg图片|*.jpg,*.jpeg|bmp图片|*.bmp|png图片|*.png|webp图片|*.webp";
                saveImageDialog.FilterIndex = 1;
                saveImageDialog.RestoreDirectory = true;

                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    string pictureName = saveImageDialog.FileName;
                    plot.Save(pictureName, formsPlot.Width, formsPlot.Height);
                }
            });

            // 添加复制到剪贴板功能
            formsPlot.Menu?.Add("复制", (plot) =>
            {
                byte[] bytes = plot.GetImage(formsPlot.Width, formsPlot.Height).GetImageBytes();
                Bitmap bitmap = null;
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    bitmap = new Bitmap(stream);
                }
                Clipboard.SetImage(bitmap);
            });
        }


        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "信号文件 (*.txt;*.csv)|*.txt;*.csv|所有文件 (*.*)|*.*";
                ofd.FilterIndex = 0;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentFileName = ofd.FileName;

                    try
                    {
                        // 1. 读取文件
                        string[] lines = File.ReadAllLines(_currentFileName);
                        List<double> timeList = new List<double>();
                        List<double> amplitudeList = new List<double>();

                        // 解析数据（支持逗号、空格、制表符分隔）
                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line))
                                continue;

                            // 多种分隔符支持
                            char[] separators = { ',', '\t', ';', ' ' };
                            string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length >= 2)
                            {
                                if (double.TryParse(parts[0], out double time) &&
                                    double.TryParse(parts[1], out double amplitude))
                                {
                                    timeList.Add(time);
                                    amplitudeList.Add(amplitude);
                                }
                            }
                        }

                        if (timeList.Count == 0)
                        {
                            MessageBox.Show("文件中没有有效数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 2. 保存到全局变量
                        _timeData = timeList.ToArray();
                        _amplitudeData = amplitudeList.ToArray();

   

                        // 4. 绘制图表
                        DrawTimeDomainSignal();
                        DrawFrequencyDomainSignal();
                       

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"读取文件时出错:\n{ex.Message}", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



            }
        }



        private void DrawTimeDomainSignal()
        {
            if (_timeData == null || _amplitudeData == null || _timeData.Length == 0)
                return;

            // 清除之前的图形
            formsPlot1.Plot.Clear();

            // 绘制时间域信号
            formsPlot1.Plot.Add.Scatter(_timeData, _amplitudeData);



            // 自动调整坐标轴范围
            formsPlot1.Plot.Axes.AutoScale();

            // 刷新图表
            formsPlot1.Refresh();

        }

        private void DrawFrequencyDomainSignal()
        {
            if (_amplitudeData == null || _amplitudeData.Length == 0)
                return;

            // 清除之前的图形
            formsPlot2.Plot.Clear();

            // 计算FFT
            var fftResult = ComputeFFT(_amplitudeData, _samplingRate);

            if (fftResult.frequencies == null || fftResult.magnitudes == null)
                return;

            // 绘制频谱图
            formsPlot2.Plot.Add.Scatter(fftResult.frequencies, fftResult.magnitudes);

            // 刷新图表
            formsPlot2.Refresh();
        }


        private (double[] frequencies, double[] magnitudes) ComputeFFT(double[] signal, double samplingRate)
        {
            int n = signal.Length;

            // 使用MathNet.Numerics进行FFT计算
            // 需要先安装 MathNet.Numerics 包

            var complexSignal = signal.Select(x => new System.Numerics.Complex(x, 0)).ToArray();

            // 计算FFT
            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complexSignal);

            // 计算频率数组
            double[] frequencies = new double[n / 2];
            double[] magnitudes = new double[n / 2];

            for (int i = 0; i < n / 2; i++)
            {
                frequencies[i] = i * samplingRate / n;
                magnitudes[i] = 20 * Math.Log10(complexSignal[i].Magnitude + 1e-10);  // 转换为dB
            }

            return (frequencies, magnitudes);
        }






    }

}




