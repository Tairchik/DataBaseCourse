using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AuthorizationLibrary
{
    public class User
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        public Dictionary<string, int> MenuStatus { get; set; } = new Dictionary<string, int>();
    }
    public class Authorization
    {
        // Имя файла БД
        private readonly string DatabaseFileName = "Login.db";
        // Относительный путь от корневой папки проекта до Data/DataFiles
        private readonly string RelativeDbPath = "CourseDB\\Data\\DataFiles";

        private string ConnectionString;
        public Dictionary<string, User> users { get; private set; } = new Dictionary<string, User>();

        // Конструктор класса
        public Authorization()
        {
            SQLitePCL.Batteries.Init();
            MakeDataBaseFile();
            LoadUsers();
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
                        ParentId INTEGER NOT NULL DEFAULT 0,
                        MenuName TEXT NOT NULL,
                        DllName TEXT,
                        FunctionName TEXT,
                        SortOrder INTEGER NOT NULL,
                        FOREIGN KEY (ParentId) REFERENCES MenuItems(MenuItemId) ON DELETE CASCADE
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

        // Метод для загрузки данных пользователей из файла
        private void LoadUsers()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {

            }

                if (!File.Exists(DatabaseFileName))
            {
                throw new FileNotFoundException("Файл пользователей не найден.", DatabaseFileName);
            }

            string[] lines = File.ReadAllLines(DatabaseFileName);
            User currentUser = null;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Если строка начинается с '#', это новый пользователь
                if (line.StartsWith("#"))
                {
                    var parts = line.Substring(1).Split(' ');
                    if (parts.Length < 2) continue;

                    string username = parts[0];
                    string password = parts[1];

                    currentUser = new User { Password = password };
                    users[username] = currentUser;
                }
                else
                {
                    // Это данные о пункте меню
                    var parts = line.Split(' ');
                    if (parts.Length < 2 || currentUser == null) continue;

                    string menuItem = parts[0];
                    int status = int.Parse(parts[1]);

                    currentUser.MenuStatus[menuItem] = status;
                }
            }
        }

        // Метод для проверки логина и пароля
        public bool Authenticate(string username, string password)
        {
            if (users.TryGetValue(username, out var userData))
            {
                if (password == userData.Password)
                {
                    userData.MenuStatus = userData.MenuStatus;
                    return true;
                }
            }
            return false;
        }
    }
}
