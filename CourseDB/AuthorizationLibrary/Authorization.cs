using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AuthorizationLibrary
{
    public struct MenuState 
    {
        public int R; // Чтение
        public int W; // Запись
        public int E; // Изменение
        public int D; // Удаление 

    }
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public Dictionary<int, MenuState> MenuStatus { get; set; } = new Dictionary<int, MenuState>();
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

            if (!users.Any())
            {
                // Если нет пользователей, создаем Admin (пароль 'admin')
                AddUser("admin", "admin", new Dictionary<int, MenuState>());
            }
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
            users.Clear();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Username, Password FROM Users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string passwordHash = reader.GetString(2);

                        User currUser = new User { Id = id, UserName = username, Password = passwordHash };
                        users[username] = currUser;

                        var command_get_roots = connection.CreateCommand();
                        command_get_roots.CommandText = @"SELECT 
                                                              Menu_id, 
                                                              R, W, E, D 
                                                          FROM UserRoots 
                                                          WHERE User_Id = @id";
                        command_get_roots.Parameters.AddWithValue("@id", id);
                        using (var reader_roots = command_get_roots.ExecuteReader())
                        {
                            while (reader_roots.Read())
                            {
                                int menu = reader_roots.GetInt32(0);
                                int r = reader_roots.GetInt32(1);
                                int w = reader_roots.GetInt32(2);
                                int e = reader_roots.GetInt32(3);
                                int d = reader_roots.GetInt32(4);

                                currUser.MenuStatus[menu] = new MenuState() { R = r, W = w, E = e, D = d };
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создает SHA256 хеш для переданной строки.
        /// </summary>
        /// <param name="password">Пароль в виде открытого текста.</param>
        /// <returns>Хеш-строка в формате Base64.</returns>
        private string HashPassword(string password)
        {
            // Используем SHA256 для хеширования
            using (var sha256 = SHA256.Create())
            {
                // Преобразуем строку в массив байтов
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                // Вычисляем хеш
                byte[] hash = sha256.ComputeHash(bytes);
                // Возвращаем хеш в виде Base64 строки для хранения в БД
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Метод для проверки логина и пароля
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            if (users.TryGetValue(username, out var userData))
            {
                // 1. Хешируем введенный пользователем пароль
                string enteredPasswordHash = HashPassword(password);

                // 2. Сравниваем полученный хеш с хешем, хранящимся в памяти (который был загружен из БД)
                if (enteredPasswordHash == userData.Password)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Добавляет нового пользователя в БД.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="password">Пароль в виде открытого текста.</param>
        /// <param name="menuStates">Словарь прав доступа.</param>
        /// <returns>True, если пользователь успешно добавлен, иначе False.</returns>
        public bool AddUser(string username, string password, Dictionary<int, MenuState> menuStates)
        {
            if (users.ContainsKey(username))
            {
                // Пользователь с таким именем уже существует
                return false;
            }

            // Хешируем пароль перед записью в БД
            string hashedPassword = HashPassword(password);
            long newUserId;

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // 1. Добавляем пользователя
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Users (Username, Password) VALUES (@user, @hash); SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@hash", hashedPassword);

                    // Получаем ID только что вставленной строки
                    newUserId = (long)command.ExecuteScalar();
                }

                // 2. Добавляем права доступа (UserRoots)
                if (newUserId > 0)
                {
                    SetUserRights((int)newUserId, menuStates, connection);
                }
            }

            // 3. Обновляем словарь в памяти
            User newUser = new User
            {
                Id = (int)newUserId,
                UserName = username,
                Password = hashedPassword,
                MenuStatus = menuStates
            };
            users[username] = newUser;
            return true;
        }

        /// <summary>
        /// Изменяет пароль пользователя.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="newPassword">Новый пароль в виде открытого текста.</param>
        /// <returns>True, если пароль успешно изменен, иначе False.</returns>
        public bool ChangePassword(string username, string newPassword)
        {
            if (!users.TryGetValue(username, out var userData))
            {
                return false; // Пользователь не найден
            }

            // Хешируем новый пароль
            string newHashedPassword = HashPassword(newPassword);

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Users SET Password = @newHash WHERE Id = @id";
                    command.Parameters.AddWithValue("@newHash", newHashedPassword);
                    command.Parameters.AddWithValue("@id", userData.Id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        // Обновляем данные в словаре в памяти
                        userData.Password = newHashedPassword;
                        users[username] = userData;
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Задает или обновляет права доступа для пользователя.
        /// </summary>
        /// <param name="userId">ID пользователя.</param>
        /// <param name="menuStates">Словарь прав доступа.</param>
        /// <param name="connection">Существующее соединение (опционально).</param>
        public void SetUserRights(int userId, Dictionary<int, MenuState> menuStates, SqliteConnection connection = null)
        {
            bool closeConnection = connection == null;
            if (connection == null)
            {
                connection = new SqliteConnection(ConnectionString);
                connection.Open();
            }

            using (var transaction = connection.BeginTransaction())
            {
                // 1. Удаляем все старые права пользователя
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "DELETE FROM UserRoots WHERE User_Id = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }

                // 2. Добавляем новые права
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = @"
                        INSERT INTO UserRoots (User_Id, Menu_id, R, W, E, D) 
                        VALUES (@userId, @menuId, @r, @w, @e, @d)";

                    command.Parameters.Add("@userId", SqliteType.Integer).Value = userId;
                    command.Parameters.Add("@menuId", SqliteType.Integer);
                    command.Parameters.Add("@r", SqliteType.Integer);
                    command.Parameters.Add("@w", SqliteType.Integer);
                    command.Parameters.Add("@e", SqliteType.Integer);
                    command.Parameters.Add("@d", SqliteType.Integer);

                    foreach (var kvp in menuStates)
                    {
                        command.Parameters["@menuId"].Value = kvp.Key;
                        command.Parameters["@r"].Value = kvp.Value.R;
                        command.Parameters["@w"].Value = kvp.Value.W;
                        command.Parameters["@e"].Value = kvp.Value.E;
                        command.Parameters["@d"].Value = kvp.Value.D;
                        command.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }

            if (closeConnection)
            {
                connection.Close();
            }

            // Обновляем права в словаре в памяти, если пользователь уже загружен
            if (users.Any(u => u.Value.Id == userId))
            {
                var userEntry = users.First(u => u.Value.Id == userId);
                userEntry.Value.MenuStatus = menuStates;
            }
        }
    }
}
