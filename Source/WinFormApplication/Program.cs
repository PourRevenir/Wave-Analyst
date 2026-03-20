namespace WinFormApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using (SplashForm sf = new SplashForm())
            {
                sf.Show();
                sf.Refresh();
                Thread.Sleep(5000);
                sf.Close();
            }

             Application.Run(new MainForm());
        }
    }
}