using AuthorizationLibrary;
using LoginWindow;
using Microsoft.VisualBasic.ApplicationServices;
using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MainModule
{
    internal static class Program
    {
        static void run(bool fl = false, AuthorizationLibrary.User? user = null)
        {
            if (fl == false)
            {
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var users = loginForm.Users;
                    var username = loginForm.AuthenticatedUsername;

                    MainForm mainForm = new MainForm(users[username]);
                    var dialog = mainForm.ShowDialog();
                    if (dialog == DialogResult.Continue)
                    {
                        ChangePassword changePassword = new ChangePassword(users[username]);
                        if (changePassword.ShowDialog() == DialogResult.OK)
                        {
                            run(false);
                        }
                        else
                        {
                            run(true, users[username]);
                        }
                    }
                    else if (dialog == DialogResult.Retry) 
                    {
                        run(false);
                    }
                }
            }
            else
            {
                MainForm mainForm = new MainForm(user);
                if (mainForm.ShowDialog() == DialogResult.Continue)
                {
                    ChangePassword changePassword = new ChangePassword(user);
                    if (changePassword.ShowDialog() == DialogResult.OK)
                    {
                        run(false);
                    }
                    else
                    {
                        run(true, user);
                    }
                }

            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            run();
        }
    }
}