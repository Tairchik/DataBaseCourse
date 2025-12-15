using LoginWindow;

namespace MainModule
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
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var users = loginForm.Users;
                var username = loginForm.AuthenticatedUsername;
                var mainController = new MainController(users, username);
                MainForm mainForm = new MainForm(mainController);
                mainForm.ShowDialog();
            }
        }
    }
}