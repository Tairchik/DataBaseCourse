using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace MenuLibrary
{
    // Класс для представления пункта меню
    public class MenuItem
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string DllName { get; set; }
        public string FunctionName { get; set; }
        public int SortOrder { get; set; }
        public List<MenuItem> SubItems { get; set; } = new List<MenuItem>();

        public MenuItem(string name)
        {
            Name = name;
        }

        public void PrintMenu(int level = 0)
        {
            string prefix = new string(' ', level * 2);
            // Выводим ID для удобства тестирования в консоли
            Console.WriteLine($"{prefix}[{Id}] {Name} (Order: {SortOrder})");
            foreach (var subItem in SubItems.OrderBy(i => i.SortOrder))
            {
                subItem.PrintMenu(level + 1);
            }
        }
    }

    // Класс для работы с меню
    public class Menu
    {
        // Используем то же имя файла БД для Login, что и в AuthorizationLibrary
        private readonly string DatabaseFileName = "Login.db";
        private readonly string RelativeDbPath = "CourseDB\\Data\\DataFiles";

        private string ConnectionString;
        private List<MenuItem> rootItems = new List<MenuItem>();

        // Конструктор класса
        public Menu()
        {
            MakeDataBaseFile();
            LoadMenu();
            // rootItems теперь уже содержат только те пункты, на которые есть права
        }

        // Создает директорию и файл, если таковых нет
        private void MakeDataBaseFile()
        {
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootPath = Path.GetFullPath(Path.Combine(appBaseDirectory, "..\\..\\..\\..\\"));
            string dbFilePath = Path.Combine(projectRootPath, RelativeDbPath, DatabaseFileName);

            string folder = Path.GetDirectoryName(dbFilePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            ConnectionString = $"Data Source={dbFilePath}";

            EnsureDatabaseSchema();
        }

        // Создаем таблицу в файле 
        private void EnsureDatabaseSchema()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );";
                command.ExecuteNonQuery();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS MenuItems (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ParentId INTEGER,
                        MenuName TEXT NOT NULL,
                        DllName TEXT,
                        FunctionName TEXT,
                        SortOrder INTEGER NOT NULL,
                        FOREIGN KEY (ParentId) REFERENCES MenuItems(Id) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS UserRoots (
                        User_Id INTEGER NOT NULL,
                        Menu_id INTEGER NOT NULL,
                        R INTEGER DEFAULT 0,
                        W INTEGER DEFAULT 0,
                        E INTEGER DEFAULT 0,
                        D INTEGER DEFAULT 0,
                        PRIMARY KEY (User_Id, Menu_id),
                        FOREIGN KEY (User_Id) REFERENCES Users(Id) ON DELETE CASCADE,
                        FOREIGN KEY (Menu_id) REFERENCES MenuItems(Id) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();
            }
        }

        // Метод для загрузки данных меню из БД
        private void LoadMenu()
        {
            // 1. Загружаем все пункты меню в плоский список
            var flatMenu = new Dictionary<int, MenuItem>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                // Сортируем по ParentId и SortOrder, чтобы упростить построение дерева
                command.CommandText = @"
                    SELECT Id, ParentId, MenuName, DllName, FunctionName, SortOrder
                    FROM MenuItems
                    ORDER BY ParentId, SortOrder";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        var item = new MenuItem(reader.GetString(2))
                        {
                            Id = id,
                            ParentId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            DllName = reader.IsDBNull(3) ? "-" : reader.GetString(3),
                            FunctionName = reader.IsDBNull(4) ? "-" : reader.GetString(4),
                            SortOrder = reader.GetInt32(5),
                        };

                        flatMenu.Add(id, item);
                    }
                }
            }

            // 2. Строим иерархическое дерево из плоского списка
            rootItems.Clear();

            foreach (var item in flatMenu.Values.OrderBy(i => i.SortOrder))
            {
                if (item.ParentId == 0)
                {
                    // Это корневой элемент
                    rootItems.Add(item);
                }
                else if (flatMenu.TryGetValue(item.ParentId, out var parentItem))
                {
                    // Добавляем как подпункт
                    parentItem.SubItems.Add(item);
                }
                // Если ParentId > 0, но родителя нет в flatMenu, значит, 
                // у родителя нет прав, и этот подпункт тоже не показываем.
            }
        }

        /// <summary>
        /// Выводит меню в консоль.
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine("--- ГЛАВНОЕ МЕНЮ ---");
            foreach (var rootItem in rootItems.OrderBy(i => i.SortOrder))
            {
                rootItem.PrintMenu();
            }
            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Возвращает корневые пункты меню с учетом прав доступа.
        /// </summary>
        public List<MenuItem> GetRootItems()
        {
            return rootItems;
        }


        /// <summary>
        /// ПОЛУЧЕНИЕ (Поиск объекта по ID)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuItem GetItemById(int id)
        {
            return FindRecursive(rootItems, id);
        }

        private MenuItem FindRecursive(List<MenuItem> items, int id)
        {
            foreach (var item in items)
            {
                if (item.Id == id) return item;

                var found = FindRecursive(item.SubItems, id);
                if (found != null) return found;
            }
            return null;
        }

    
        /// <summary>
        /// ДОБАВЛЕНИЕ (Через объект родителя)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="order"></param>
        /// <param name="parent"></param>
        /// <param name="dll"></param>
        /// <param name="func"></param>
        public void AddItem(string name, int order, MenuItem parent, string dll = "-", string func = "-")
        {
            var newItem = new MenuItem(name)
            {
                ParentId = parent?.Id ?? 0, // Если родитель null, то это корень (0)
                SortOrder = order,
                DllName = dll,
                FunctionName = func
            };

            // 1. Сохраняем в БД (получаем ID)
            SaveToDb(newItem);

            // 2. Добавляем в список в памяти
            if (parent == null)
            {
                rootItems.Add(newItem);
            }
            else
            {
                parent.SubItems.Add(newItem);
            }
            Console.WriteLine($"Пункт '{name}' успешно добавлен.");
        }

        
        /// <summary>
        /// ИЗМЕНЕНИЕ (Через ссылку на объект)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="newName"></param>
        /// <param name="newOrder"></param>
        /// <param name="newDll"></param>
        /// <param name="newFunc"></param>
        
        public void EditItem(MenuItem item, string newName, int newOrder, string newDll, string newFunc)
        {
            if (item == null) return;

            // 1. Меняем данные в объекте
            item.Name = newName;
            item.SortOrder = newOrder;
            item.DllName = newDll;
            item.FunctionName = newFunc;

            // 2. Обновляем БД
            UpdateInDb(item);
            Console.WriteLine($"Пункт ID {item.Id} успешно изменен.");
        }

       
        /// <summary>
        /// УДАЛЕНИЕ (Через ссылку на объект)
        /// </summary>
        /// <param name="item"></param>

        public void DeleteItem(MenuItem item)
        {
            if (item == null) return;

            // 1. Удаляем из БД
            DeleteFromDb(item.Id);

            // 2. Удаляем из памяти (нужно найти список, в котором лежит этот элемент)
            if (item.ParentId == 0)
            {
                rootItems.Remove(item);
            }
            else
            {
                // Ищем родителя, чтобы удалить из его SubItems
                var parent = GetItemById(item.ParentId);
                if (parent != null)
                {
                    parent.SubItems.Remove(item);
                }
            }
            Console.WriteLine($"Пункт '{item.Name}' удален.");
        }

        /// <summary>
        /// удаления по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            var item = GetItemById(id);
            if (item != null)
            {
                DeleteItem(item);
            }
            else
            {
                Console.WriteLine("Пункт не найден.");
            }
        }

        // --- Служебные методы работы с БД ---

        private void SaveToDb(MenuItem item)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // ВАЖНО: Включаем поддержку внешних ключей (в SQLite она может быть отключена по умолчанию)
                using (var pragmacmd = connection.CreateCommand())
                {
                    pragmacmd.CommandText = "PRAGMA foreign_keys = ON;";
                    pragmacmd.ExecuteNonQuery();
                }

                var command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO MenuItems (ParentId, MenuName, DllName, FunctionName, SortOrder) 
                    VALUES (@p, @n, @d, @f, @s);
                    SELECT last_insert_rowid();";

                // Если ParentId == 0, отправляем DBNull.Value (пустоту), иначе отправляем число
                if (item.ParentId == 0)
                {
                    command.Parameters.AddWithValue("@p", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@p", item.ParentId);
                }

                command.Parameters.AddWithValue("@n", item.Name);
                // Проверка на null для строк тоже полезна
                command.Parameters.AddWithValue("@d", (object)item.DllName ?? DBNull.Value);
                command.Parameters.AddWithValue("@f", (object)item.FunctionName ?? DBNull.Value);
                command.Parameters.AddWithValue("@s", item.SortOrder);

                long newId = (long)command.ExecuteScalar();
                item.Id = (int)newId;
            }
        }

        private void UpdateInDb(MenuItem item)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    UPDATE MenuItems 
                    SET MenuName = @n, SortOrder = @s, DllName = @d, FunctionName = @f
                    WHERE Id = @id";

                command.Parameters.AddWithValue("@id", item.Id);
                command.Parameters.AddWithValue("@n", item.Name);
                command.Parameters.AddWithValue("@s", item.SortOrder);
                command.Parameters.AddWithValue("@d", item.DllName);
                command.Parameters.AddWithValue("@f", item.FunctionName);

                command.ExecuteNonQuery();
            }
        }

        private void DeleteFromDb(int id)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                // Примечание: Если в БД нет каскадного удаления, подпункты могут остаться "сиротами"
                command.CommandText = "DELETE FROM MenuItems WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
    public static class ConsoleInterface
    {
        public static void Run()
        {
            var menuManager = new Menu();

            while (true)
            {
                Console.WriteLine("\n=== УПРАВЛЕНИЕ МЕНЮ ===");
                Console.WriteLine("1. Показать меню");
                Console.WriteLine("2. Добавить пункт");
                Console.WriteLine("3. Изменить пункт");
                Console.WriteLine("4. Удалить пункт");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                var key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1":
                            menuManager.PrintMenu();
                            break;
                        case "2":
                            DoAdd(menuManager);
                            break;
                        case "3":
                            DoEdit(menuManager);
                            break;
                        case "4":
                            DoDelete(menuManager);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        private static void DoAdd(Menu menu)
        {
            Console.WriteLine("\n--- Добавление пункта ---");

            Console.Write("Введите название нового пункта: ");
            string name = Console.ReadLine();

            Console.Write("Порядок (число): ");
            if (!int.TryParse(Console.ReadLine(), out int order)) order = 0;

            Console.Write("ID родителя (0 для корня): ");
            if (!int.TryParse(Console.ReadLine(), out int parentId)) parentId = 0;

            // Ввод DLL и Функции
            Console.Write("Имя DLL (enter для '-'): ");
            string dll = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dll)) dll = "-";

            Console.Write("Имя функции (enter для '-'): ");
            string func = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(func)) func = "-";

            // Логика поиска родителя
            MenuItem parentItem = null;
            if (parentId != 0)
            {
                parentItem = menu.GetItemById(parentId);
                if (parentItem == null)
                {
                    Console.WriteLine("Ошибка: Родитель с таким ID не найден!");
                    return; // Прерываем добавление, если родитель указан неверно
                }
            }

            // Вызов метода добавления
            menu.AddItem(name, order, parentItem, dll, func);
        }

        private static void DoEdit(Menu menu)
        {
            Console.WriteLine("\n--- Редактирование пункта ---");

            Console.Write("Введите ID пункта для изменения: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            // 1. Получаем ссылку на объект
            var item = menu.GetItemById(id);
            if (item == null)
            {
                Console.WriteLine("Пункт не найден.");
                return;
            }

            // 2. Показываем старые данные и просим новые
            Console.WriteLine($"[Текущее имя]: {item.Name}");
            Console.Write("Новое имя (enter чтобы оставить): ");
            string newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName)) newName = item.Name;

            Console.WriteLine($"[Текущий порядок]: {item.SortOrder}");
            Console.Write("Новый порядок (enter чтобы оставить): ");
            string orderStr = Console.ReadLine();
            int newOrder = string.IsNullOrWhiteSpace(orderStr) ? item.SortOrder : int.Parse(orderStr);

            Console.WriteLine($"[Текущая DLL]: {item.DllName}");
            Console.Write("Новая DLL (enter чтобы оставить): ");
            string newDll = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newDll)) newDll = item.DllName;

            Console.WriteLine($"[Текущая Функция]: {item.FunctionName}");
            Console.Write("Новая Функция (enter чтобы оставить): ");
            string newFunc = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newFunc)) newFunc = item.FunctionName;

            // 3. Вызываем метод изменения
            menu.EditItem(item, newName, newOrder, newDll, newFunc);
        }

        private static void DoDelete(Menu menu)
        {
            Console.Write("Введите ID пункта для удаления: ");
            int id = int.Parse(Console.ReadLine());

            // Получаем ссылку, чтобы передать в метод удаления
            var item = menu.GetItemById(id);
            if (item != null)
            {
                menu.DeleteItem(item);
            }
            else
            {
                Console.WriteLine("Пункт не найден.");
            }
        }
    }
}