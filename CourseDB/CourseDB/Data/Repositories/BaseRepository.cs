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
        protected static string RelativeDbPath = "CourseDB\\Data\\DataFiles";

        protected static string ConnectionString;
        private static bool _schemaChecked = false;
        // Метод для создания и открытия соединения 
        static BaseRepository()
        {
            if (!_schemaChecked)
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

                // 8. Models
                command.CommandText = $@"
                        CREATE TABLE IF NOT EXISTS Models (
                            -- Primary key
                            ModelId INTEGER PRIMARY KEY AUTOINCREMENT,

                            -- Foreign key
                            BrandId INTEGER NOT NULL,
                            
                            -- Auto details
                            ModelName TEXT NOT NULL UNIQUE,         -- Название модели
                            TotalCapacity INTEGER NOT NULL,         -- Полная посадка
                            SeatCapacity INTEGER NOT NULL,          -- Сидячие места
                            
                            -- Constraints
                            FOREIGN KEY (BrandId) REFERENCES Brands (Id) ON DELETE RESTRICT
                        );";
                command.ExecuteNonQuery();

                // 9. Buses
                command.CommandText = $@"
                        CREATE TABLE IF NOT EXISTS Buses (
                            -- Primary key
                            BusId INTEGER PRIMARY KEY AUTOINCREMENT,
                             
                            -- Foreign key
                            ModelId INTEGER NOT NULL,
                            ColorId INTEGER NOT NULL,                            

                            -- Bus details
                            InventoryNumber TEXT NOT NULL UNIQUE,   -- Инвентарный номер
                            StateBus TEXT NOT NULL,                 -- Состояние автобуса
                            RegistrationNumber TEXT NOT NULL,       -- Регистрационный номер
                            EngineNumber TEXT NOT NULL,             -- Номер двигателя                            EngineNumber TEXT NOT NULL,             -- Номер двигателя
                            BodyNumber TEXT NOT NULL,               -- Номер кузова
                            ChassisNumber TEXT NOT NULL,            -- Номер шасси
                            ManufactureDate TEXT NOT NULL,          -- Дата производства
                            Mileage INT NOT NULL,                   -- Пробег
                            LastOverhaulDate TEXT,                  -- Дата последнего капремонта (необязательно)
                            
                            -- Constraints
                            FOREIGN KEY (ModelId) REFERENCES Models (ModelId) ON DELETE RESTRICT,
                            FOREIGN KEY (ColorId) REFERENCES Colors (Id) ON DELETE RESTRICT
                        );";
                command.ExecuteNonQuery();

               // 10. Routs (Маршруты)
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Routs (
                        RoutId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoutNumber TEXT NOT NULL UNIQUE,                 -- Номер маршрута
                        FullTurnoverTime TEXT NOT NULL,                  -- Время полного оборота
                        FirstBusStartTime TEXT NOT NULL,                 -- Время выхода на маршрут первого автобуса
                        LastBusStartTime TEXT NOT NULL,                  -- Время выхода на маршрут последнего автобуса
                        FirstBusDepartureFromTerminal TEXT NOT NULL,     -- Время отправления с конечной остановки первого автобуса
                        LastBusDepartureFromTerminal TEXT NOT NULL,      -- Время отправления с конечной остановки последнего автобуса
                        Distance INTEGER NOT NULL,                       -- Протяженность
                        PlannedRevenue REAL NOT NULL                     -- Плановая выручка
                    );";
                command.ExecuteNonQuery();

                // 11. ListStations (Список остановок маршрута)
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS ListStations (
                        ListStationId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoutId INTEGER NOT NULL,                         -- ID Маршрута
                        StationId INTEGER NOT NULL,                      -- ID Остановки
                        OrderNumber INTEGER NOT NULL,                    -- Порядковый номер
                        FOREIGN KEY (RoutId) REFERENCES Routs (RoutId) ON DELETE CASCADE,
                        FOREIGN KEY (StationId) REFERENCES Stations (Id) ON DELETE RESTRICT,
                        UNIQUE (RoutId, StationId, OrderNumber)
                    );";
                command.ExecuteNonQuery();

                // 12. Schedules (График движения)
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Schedules (
                        ScheduleId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoutId INTEGER NOT NULL,                         -- ID Маршрута
                        Interval INTEGER NOT NULL,                       -- Интервал движения (в минутах)
                        StartHour INTEGER NOT NULL,                      -- Начальный час (0-23)
                        EndHour INTEGER NOT NULL,                        -- Конечный час (0-23)
                        FOREIGN KEY (RoutId) REFERENCES Routs (RoutId) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();

                // 13. Trips (Рейсы)
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Trips (
                        TripId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoutId INTEGER NOT NULL,                     -- ID Маршрута
                        DriverId INTEGER NOT NULL,                   -- ID Водитель
                        BusId INTEGER NOT NULL,                      -- ID Автобус
                        ConductorId INTEGER,                         -- ID Кондуктор (может быть NULL)
                        TripDate TEXT NOT NULL,                      -- Дата выезда
                        StartTime TEXT NOT NULL,                     -- Время выезда
                        Direction INTEGER NOT NULL,                  -- Направление маршрута (0 - обратное, 1 - прямое)
                        ActualRevenue REAL DEFAULT 0.0,              -- Итоговая выручка
        
                        -- Constraints
                        FOREIGN KEY (RoutId) REFERENCES Routs (RoutId) ON DELETE RESTRICT,
                        FOREIGN KEY (DriverId) REFERENCES Employees (EmployeeId) ON DELETE RESTRICT,
                        FOREIGN KEY (BusId) REFERENCES Buses (BusId) ON DELETE RESTRICT,
                        FOREIGN KEY (ConductorId) REFERENCES Employees (EmployeeId) ON DELETE SET NULL,
                        CHECK (Direction IN (0, 1))
                    );";
                command.ExecuteNonQuery();

                // 14. ControlTrips (Оперативный контроль графика)
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS ControlTrips (
                        ControlTripId INTEGER PRIMARY KEY AUTOINCREMENT,
                        TripId INTEGER NOT NULL,                     -- ID Рейс
                        LeaveTime TEXT,                              -- Время снятия с маршрута
                        ArrivalTime TEXT,                            -- Время прибытия на конечную
                        LeaveReason TEXT,                            -- Причина снятия с маршрута (может быть NULL)
                        RidesCount INTEGER NOT NULL DEFAULT 0,       -- Число ездок
        
                        -- Constraints
                        FOREIGN KEY (TripId) REFERENCES Trips (TripId) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();
            }
        }
    }
}
