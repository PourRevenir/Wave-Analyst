namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using (SplashForm splashForm = new SplashForm())
            {
                splashForm.Show();
                splashForm.Refresh();
                Thread.Sleep(3000);
                splashForm.Visible = false;
                splashForm.Close();
            }

            Application.Run(new MainForm()); //启动MainForm窗体
        }
    }
}