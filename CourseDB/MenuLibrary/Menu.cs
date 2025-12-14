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
        public string Name { get; set; }         // MenuName
        public string DllName { get; set; }      // Имя DLL
        public string FunctionName { get; set; } // Имя функции/класса
        public int SortOrder { get; set; }
        public List<MenuItem> SubItems { get; set; } = new List<MenuItem>(); // Подменю

        public bool HasSubItems => DllName == "-" && FunctionName == "-";
        public bool IsExecutable => !HasSubItems; // Можно ли выполнить (есть DLL/Function)

        public MenuItem(string name)
        {
            Name = name;
        }

        // Метод для вывода меню (рекурсивно)
        public void PrintMenu(int level = 0)
        {
            string prefix = new string(' ', level * 2);

            Console.WriteLine($"{prefix}{Name}");

            // Сортировка подменю перед выводом по SortOrder
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
            SetConnectionString();
            LoadMenu();
            // rootItems теперь уже содержат только те пункты, на которые есть права
        }

        private void SetConnectionString()
        {
            // Логика получения пути к БД Login.db 
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootPath = Path.GetFullPath(Path.Combine(appBaseDirectory, "..\\..\\..\\..\\"));
            string dbFilePath = Path.Combine(projectRootPath, RelativeDbPath, DatabaseFileName);
            ConnectionString = $"Data Source={dbFilePath}";
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
                            ParentId = reader.GetInt32(1),
                            DllName = reader.GetString(3),
                            FunctionName = reader.GetString(4),
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
    }
}