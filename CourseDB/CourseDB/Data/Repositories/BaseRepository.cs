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

                // 6. Employee
                command.CommandText = $@"
                        CREATE TABLE IF NOT EXISTS Employees (
                            -- Primary Key
                            EmployeeId INTEGER PRIMARY KEY AUTOINCREMENT,

                            -- Foreign Keys (Внешние ключи)
                            PostId INTEGER NOT NULL,            -- ID Должности в компании
                            StreetId INTEGER NOT NULL,          -- ID Улица (для адреса)

                            -- Personal Info (Личная информация)
                            Surname TEXT NOT NULL,              -- Фамилия
                            FirstName TEXT NOT NULL,            -- Имя
                            Patronymic TEXT,                    -- Отчество (может быть NULL)
                            Gender TEXT NOT NULL,               -- Пол (e.g., 'Male', 'Female')
                            BirthDate TEXT NOT NULL,            -- Дата рождения (TEXT для SQLite даты)
    
                            -- Address Details (Детали адреса)
                            House TEXT NOT NULL,                -- Дом
                            Apartment TEXT,                     -- Квартира (может быть NULL)

                            -- Professional Details (Профессиональные детали)
                            TimeWork INTEGER NOT NULL DEFAULT 0,-- Трудовой стаж (в годах, INTEGER)
                            DriverClass INTEGER NOT NULL DEFAULT 0, -- Класс водителя (0-3)
                            Bonus REAL NOT NULL DEFAULT 0.0,    -- Премия (REAL или NUMERIC для денег)

                            -- Internal Flags
                            IsArchive INTEGER NOT NULL DEFAULT 0,   -- Флаг Архив (IsArchive / Flag Archive)
                            DeletionDate TEXT,                      -- Дата Удаления (DeletionDate)

                            -- Constraints (Ограничения)
                            FOREIGN KEY (PostId) REFERENCES Posts (Id) ON DELETE RESTRICT,
                            FOREIGN KEY (StreetId) REFERENCES Streets (Id) ON DELETE RESTRICT
                        );";
                command.ExecuteNonQuery();

                // 7. EmploymentHistory
                command.CommandText = $@"
                        CREATE TABLE IF NOT EXISTS EmploymentHistory (
                            -- Primary Key
                            HistoryId INTEGER PRIMARY KEY AUTOINCREMENT,

                            -- Foreign Key 
                            EmployeeId INTEGER NOT NULL,
                            PostId INTEGER NOT NULL, 

                            -- Event Details 
                            TypeEvent TEXT NOT NULL,                -- Тип мероприятия (Прием, Увольнение, Перевод)
                            Organization TEXT NOT NULL,             -- Место работы (NameOrganization)
                            DateEvent TEXT NOT NULL,                -- Дата вступления в силу мероприятия (DateEvent)
    
                            -- Document Details
                            DateDocument TEXT NOT NULL,             -- Дата подписания документа
                            NumberDocument TEXT NOT NULL,           -- Номер кадрового мероприятия
                            TypeDocument TEXT NOT NULL,             -- Вид документа (Приказ, Записка и т.д.)
    
                            -- Dismissal Details
                            Reasons TEXT,                           -- Причины прекращения трудового договора (может быть NULL)

                            -- Constraints (Ограничения)
                            FOREIGN KEY (EmployeeId) REFERENCES Employees (EmployeeId) ON DELETE CASCADE,
                            FOREIGN KEY (PostId) REFERENCES Posts (Id) ON DELETE RESTRICT
                        );";
                command.ExecuteNonQuery();
            }
        }
    }
}
