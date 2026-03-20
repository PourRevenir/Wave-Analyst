using ScottPlot;

namespace ScottPlotTest
{
    public partial class Form1 : Form
    {





        public Form1()
        {
            InitializeComponent();


            double[] xs = Generate.Consecutive(100);
            double[] Ys = Generate.NoisyExponential(100);

            var sig = formsPlot1.Plot.Add.Scatter(xs, Ys); 
            formsPlot1.Plot.FigureBackground.Color = Colors.LightBlue;
            //ԭͼ
            double[] logxs = xs.Select(Math.Log10).ToArray();
            var sig1 = formsPlot2.Plot.Add.Scatter(logxs, Ys);
            // �̶�
            IMinorTickGenerator minorTickGen = new ScottPlot.TickGenerators.LogDecadeMinorTickGenerator();
            ScottPlot.TickGenerators.NumericAutomatic xTickGen = new()
            {
                MinorTickGenerator = minorTickGen,
                IntegerTicksOnly = true,
                LabelFormatter = (double x) => $"10^{x}",
            };
            formsPlot2.Plot.Axes.Bottom.TickGenerator = xTickGen;
            // ��Χ

            formsPlot2.Plot.Axes.AutoScaleX(); 
            formsPlot2.Plot.Axes.SetLimitsX(0, 2.2); //对应x值，是1-10^2.2


            formsPlot2.Plot.FigureBackground.Color = Colors.LightBlue;
            formsPlot2.Refresh();
        }

      
           
        

    }
}
