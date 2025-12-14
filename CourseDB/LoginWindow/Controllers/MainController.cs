using MenuLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using AuthorizationLibrary;

namespace LoginWindow
{
    public class MainController
    {
        public event EventHandler<EventArgs> MenuItemClick;

        private MainForm _view;
        private string _userName;
        private readonly MenuLibrary.Menu _menu;
        private Dictionary<string, User> users;
        public MainController(Dictionary<string, User> users, string username)
        {
            this.users = users;
            _userName = username;
            _menu = new MenuLibrary.Menu();
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

            if ((status.W == 1 || status.R == 1 || status.D == 1 || status.E == 1) && menuItem.SubItems.Count == 0)
            {
                menu.Click += (sender, args) => MenuItemClick?.Invoke(sender, args);
            }
            else
            {
                menu.Visible = false;
            }

            return menu;
        }
    }
}
