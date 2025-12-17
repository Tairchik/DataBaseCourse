using AuthorizationLibrary;
using HelpModule;
using CourseDB;
using OtherModule;
using DocumentModule;
using TripModule;
using ControlBusModule;
using EmployeeModule;
using FinancialModule;
using GuideModule;
using LoginWindow;

namespace MainModule
{
    public class MainController
    {
        public event EventHandler<EventArgs> MenuItemClick;
        public event EventHandler<Font> FontIsChange;


        private MainForm _view;
        private string _userName;
        private readonly MenuLibrary.Menu _menu;
        private User user;
        private InitRepos _initRepos; 
        public MainController(User user, MainForm view)
        {
            _view = view;
            this.user = user;
            _menu = new MenuLibrary.Menu();
            _initRepos = new InitRepos();
        }

        public Font GetFont() 
        {
            SettingsRepository rep = new SettingsRepository();
           
            return rep.GetSettings(user.Id);
        }

        // Метод для получения статуса пункта меню для пользователя
        public MenuState GetMenuStatus(string username, int menuItem)
        {

            if (user.MenuStatus.TryGetValue(menuItem, out MenuState status))
            {
                return status;
            }
            
            return new MenuState() { D = 0, W = 0, E = 0, R = 0 }; // По умолчанию, если пункт не указан, он не доступен
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
            if (status.R == 1)
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
                Form? form = null;

                switch (menuItem.DllName)
                {
                    case "HelpModule":
                        form = CreateHelpModule(menuItem);
                        break;
                    case "OtherModule":
                        form = CreateOtherModule(menuItem);
                        break;
                    case "DocumentModule":
                        form = CreateDocumentModule(menuItem);
                        break;
                    case "ControlBusModule":
                        form = CreateControlBusModule(menuItem);
                        break;
                    case "EmployeeModule":
                        form = CreateEmployeeModule(menuItem);
                        break;
                    case "FinancialModule":
                        form = CreateFinancialModule(menuItem);
                        break;
                    case "GuideModule":
                        form = CreateGuideModule(menuItem);
                        break;
                    case "TripModule":
                        form = CreateTripModule(menuItem);
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

                    if (form.GetType() == typeof(ChangePassword))
                    {
                        _view.DialogResult = DialogResult.Continue;
                        _view.Close();

                    }
                    else if (form.GetType() == typeof(SettingsForm)) 
                    {
                        form.ShowDialog();
                        FontIsChange?.Invoke(this, GetFont());
                    }
                    else
                    {
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании формы: {ex.Message}\n\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form? CreateHelpModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "Content":
                    return new ContentForm(_initRepos);
                case "AboutProgram":
                    return new AboutProgramForm(_initRepos); 
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле HelpModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }

        private Form? CreateOtherModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "Settings":
                    return new SettingsForm(user);
                case "ChangePassword":
                    return new ChangePassword(user);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле OtherModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
        private Form? CreateDocumentModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "BusReport":
                    return new BusReportForm(_initRepos);
                case "DriverReport":
                    return new DriverReport(_initRepos);
                case "RoutReport":
                    return new RoutReportForm(_initRepos);
                case "TripReport":
                    return new TripReportForm(_initRepos);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле DocumentModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
        private Form? CreateTripModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "Trip":
                    return new TripForm(_initRepos);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле TripModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
        private Form? CreateControlBusModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "Control":
                    return new ControlForm(_initRepos);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле ControlBusModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
        private Form? CreateEmployeeModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "Employee":
                    return new EmployeeForm(_initRepos);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле EmployeeModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
        private Form? CreateFinancialModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "RevenueRout":
                    return new RevenueRoutForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "RevenueTrip":
                    return new RevenueTripForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Salary":
                    return new SalaryForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле FinancialModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
        private Form? CreateGuideModule(MenuLibrary.MenuItem menuItem)
        {
            switch (menuItem.FunctionName)
            {
                case "Brand":
                    return new BrandForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Bus":
                    return new BusForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Color":
                    return new ColorForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Model":
                    return new ModelForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Post":
                    return new PostForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Rout":
                    return new RoutForm(_initRepos, user.Id, user.MenuStatus[menuItem.Id]);
                case "Station":
                    return new StationForm(_initRepos);
                default:
                    MessageBox.Show($"Функция '{menuItem.FunctionName}' не найдена в модуле GuideModule", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
    }
}
