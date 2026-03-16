namespace WinFormsApp1
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
            // 先显示启动界面
            using (SplashForm splashForm = new SplashForm())
            {

                
                splashForm.Show();
                Thread.Sleep(3000); // 等待3秒
                splashForm.Visible = false;
                splashForm.Close();

                // 启动界面关闭后，显示主窗体
                Application.Run(new Form1());
            }
        }
    }
}