using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public abstract class BaseRepository
    {
        // Имя файла БД
        protected static string DatabaseFileName = "company_data.db";

        // Относительный путь от корневой папки проекта до Data/DataFiles
        protected static string RelativeDbPath = "Data\\DataFiles";

        protected static string ConnectionString;
        private static bool _schemaChecked = false;
        // Метод для создания и открытия соединения 
        static BaseRepository()
        {
            if (!_schemaChecked)
            {
                string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.GetFullPath(Path.Combine(appBaseDirectory, "..\\..\\..\\"));
                string dbFilePath = Path.Combine(projectRootPath, RelativeDbPath, DatabaseFileName);

                string folder = Path.GetDirectoryName(dbFilePath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                ConnectionString = $"Data Source={dbFilePath}";

                EnsureDatabaseSchema();

                _schemaChecked = true; // Устанавливаем флаг после успешного выполнения
            }
        }


        protected SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            // Включаем проверку внешних ключей
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA foreign_keys = ON;";
                command.ExecuteNonQuery();
            }
            return connection;
        }

        private static void EnsureDatabaseSchema()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                string[][] names_simple_tables = new string[][] 
                {
                    new string[] {"Brands", "BrandName"},
                    new string[] {"Streets", "StreetName"},
                    new string[] {"Stations", "StationName"},
                    new string[] {"Colors", "ColorName"},
                };

                // 1-4. Создание типовых таблиц
                foreach (var name in names_simple_tables)
                {
                    command.CommandText = $@"
                        CREATE TABLE IF NOT EXISTS {name[0]} (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            {name[1]} TEXT NOT NULL UNIQUE
                        );";
                    command.ExecuteNonQuery();
                }

                // 5. Должность
                command.CommandText = $@"
                        CREATE TABLE IF NOT EXISTS Posts (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            PostName TEXT NOT NULL UNIQUE,
                            Salary REAL
                        );";
                command.ExecuteNonQuery();
            }
        }
    }
}
