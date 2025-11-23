using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CourseDB.Data
{

    public abstract class BaseRepository
    {
        // Название таблицы
        protected abstract string TableName { get; }
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

        public int Delete(int id)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Используем интерполяцию строки для подстановки имени таблицы
                command.CommandText = $"DELETE FROM {TableName} WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);

                return command.ExecuteNonQuery();
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

                // 1. Создание таблицы Brands
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Brands (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        BrandName TEXT NOT NULL UNIQUE
                    );";
                command.ExecuteNonQuery();
            }
        }


    }
}
