using MenuLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Login
{
    public class MainController
    {
        public event EventHandler<EventArgs> MenuItemClick;

        private MainForm _view;
        private string _userName;
        private readonly MenuLibrary.Menu _menu;
        private Dictionary<string, AuthorizationLibrary.User> users;
        public MainController(Dictionary<string, AuthorizationLibrary.User> users, string username)
        {
            this.users = users;
            _userName = username;
            _menu = new MenuLibrary.Menu();
        }

        // Метод для получения статуса пункта меню для пользователя
        public int GetMenuStatus(string username, string menuItem)
        {
            if (users.TryGetValue(username, out var userData))
            {
                if (userData.MenuStatus.TryGetValue(menuItem, out int status))
                {
                    return status;
                }
            }
            return 0; // По умолчанию, если пункт не указан, он виден и доступен
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
            int status = GetMenuStatus(_userName, menuItem.Name);

            var menu = new ToolStripMenuItem(menuItem.Name);

            foreach (var subItem in menuItem.SubItems)
            {
                menu.DropDownItems.Add(CreateMenuItem(subItem));
            }

            if (status == 0 && menuItem.SubItems.Count == 0)
            {
                menu.Click += (sender, args) => MenuItemClick?.Invoke(sender, args);
            }
            if (status == 1)
            {
                menu.BackColor = Color.LightGray;
                menu.Enabled = false;
            }
            else if (status == 2)
            {
                menu.Visible = false;
            }

            return menu;
        }
    }
}
