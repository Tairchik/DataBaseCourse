using AuthorizationLibrary;
using HelpModule;
using CourseDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtherModule;

namespace MainModule
{
    public class MainController
    {
        public event EventHandler<EventArgs> MenuItemClick;

        private MainForm _view;
        private string _userName;
        private readonly MenuLibrary.Menu _menu;
        private Dictionary<string, User> users;
        private InitRepos _initRepos; 
        public MainController(Dictionary<string, User> users, string username)
        {
            this.users = users;
            _userName = username;
            _menu = new MenuLibrary.Menu();
            _initRepos = new InitRepos();
        }

        // Метод для получения статуса пункта меню для пользователя
        public MenuState GetMenuStatus(string username, int menuItem)
        {
            if (users.TryGetValue(username, out var userData))
            {
                if (userData.MenuStatus.TryGetValue(menuItem, out MenuState status))
                {
                    return status;
                }
            }
            return new MenuState() { D = 1, W = 1, E = 1, R = 1 }; // По умолчанию, если пункт не указан, он виден и доступен
        }

        // Метод для добавления пунктов в форму
        public void AddMenuItems(MenuStrip menuStrip)
        {
            foreach (MenuLibrary.MenuItem item in _menu.GetRootItems())
            {
                menuStrip.Items.Add(CreateMenuItem(item));
            }
        }

        // Рекурсивно создаем пункты меню
        private ToolStripMenuItem CreateMenuItem(MenuLibrary.MenuItem menuItem)
        {
            MenuState status = GetMenuStatus(_userName, menuItem.Id);

            var menu = new ToolStripMenuItem(menuItem.Name);

            foreach (var subItem in menuItem.SubItems)
            {
                menu.DropDownItems.Add(CreateMenuItem(subItem));
            }

            if ((status.W == 1 || status.R == 1 || status.D == 1 || status.E == 1))
            {
                if (menuItem.SubItems.Count == 0)
                {
                    menu.Tag = menuItem;
                    menu.Click += (sender, args) => OnMenuItemClick(menuItem);
                }
            }
            else
            {
                menu.Visible = false;
            }
            return menu;
        }

        private void OnMenuItemClick(MenuLibrary.MenuItem menuItem)
        {
            try
            {
                // Проверяем права на этот пункт меню
                MenuState status = GetMenuStatus(_userName, menuItem.Id);

                // Открываем форму из статически подключенных сборок
                OpenFormFromMenuItem(menuItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFormFromMenuItem(MenuLibrary.MenuItem menuItem)
        {
            try
            {
                Form form = null;

                switch (menuItem.DllName)
                {
                    case "HelpModule":
                        form = CreateHelpModuleForm(menuItem.FunctionName);
                        break;
                    case "OtherModule":
                        form = CreateOtherModuleForm(menuItem.FunctionName);
                        break;

                    default:
                        MessageBox.Show($"Модуль '{menuItem.DllName}' не поддерживается", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                if (form != null)
                {
                    // Можно передать информацию о пользователе и правах в форму
                    // Например, через свойство или конструктор
                    // form.UserRights = status;

                    // Показываем форму модально или немодально в зависимости от логики
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании формы: {ex.Message}\n\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form CreateHelpModuleForm(string functionName)
        {
            switch (functionName)
            {
                case "Content":
                    return new ContentForm(_initRepos);
                case "AboutProgram":
                    return new AboutProgramForm(_initRepos); 
                default:
                    MessageBox.Show($"Функция '{functionName}' не найдена в модуле HelpModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }

        private Form CreateOtherModuleForm(string functionName)
        {
            switch (functionName)
            {
                case "Settings":
                    return new SettingsForm(_initRepos);
                case "ChangePassport":
                    return new ChangePasswordForm(_initRepos);
                default:
                    MessageBox.Show($"Функция '{functionName}' не найдена в модуле OtherModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
    }
}
