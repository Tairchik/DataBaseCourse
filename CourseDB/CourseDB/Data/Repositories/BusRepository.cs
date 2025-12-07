using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseDB.Data.Repositories
{
    public class BusRepository: BaseRepository
    {
        private string TableName { get => "Buses"; }
        private readonly ColorRepository _colorRepository;
        private readonly ModelRepository _modelRepository;

        public BusRepository(ColorRepository colorRepository, ModelRepository modelRepository) 
        {
            _colorRepository = colorRepository;
            _modelRepository = modelRepository;
        }

        /// <summary>
        /// Возвращает список автобусов из БД
        /// </summary>
        /// <returns></returns>
        public List<Bus> GetAll() 
        {
            List<Bus> buses = new List<Bus>();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        BusId, ModelId, ColorId, InventoryNumber,
                        StateBus, RegistrationNumber, EngineNumber,
                        BodyNumber, ChassisNumber, ManufactureDate,
                        Mileage, LastOverhaulDate
                    FROM {TableName};";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 1. Читаем данные из БД
                        int busId = reader.GetInt32(reader.GetOrdinal("BusId"));
                        int modelId = reader.GetInt32(reader.GetOrdinal("ModelId"));
                        int colorId = reader.GetInt32(reader.GetOrdinal("ColorId"));

                        string inventoryNumber = reader.GetString(reader.GetOrdinal("InventoryNumber"));
                        BusState stateBus = BusStateExtensions.GetEnumByString(reader.GetString(reader.GetOrdinal("StateBus")));
                        string registrationNumber = reader.GetString(reader.GetOrdinal("RegistrationNumber"));
                        string engineNumber = reader.GetString(reader.GetOrdinal("EngineNumber"));
                        string bodyNumber = reader.GetString(reader.GetOrdinal("BodyNumber"));
                        string chassisNumber = reader.GetString(reader.GetOrdinal("ChassisNumber"));
                        int mileage = reader.GetInt32(reader.GetOrdinal("Mileage"));

                        DateTime manufactureDate = reader.GetDateTime(reader.GetOrdinal("ManufactureDate"));
                        var lastOverhaulDateVar = reader.GetOrdinal("LastOverhaulDate");
                        
                        Model model = _modelRepository.GetById(modelId);
                        ColorDataModel color = _colorRepository.GetById(colorId);

                        // LastOverhaulDate может быть NULL
                        DateTime? lastOverhaulDate = null;
                        int lastOverhaulDateOrdinal = reader.GetOrdinal("LastOverhaulDate");
                        if (!reader.IsDBNull(lastOverhaulDateOrdinal))
                        {
                            string lastOverhaulDateStr = reader.GetString(lastOverhaulDateOrdinal);
                            if (DateTime.TryParse(lastOverhaulDateStr, out DateTime parsedDate))
                            {
                                lastOverhaulDate = parsedDate;
                            }
                        }

                        // 2. Создаем объект
                        var bus = new Bus(inventoryNumber, registrationNumber, model, engineNumber, 
                            bodyNumber, chassisNumber, mileage, color.ColorName, manufactureDate, stateBus,
                            lastOverhaulDate);

                        buses.Add(bus);
                    }
                }
            }

            return buses;
        }
        /// <summary>
        /// Сохраняет уже существующий автобус или создает новый
        /// </summary>
        /// <param name="bus"></param>
        public void Save(Bus bus)
        {
            using (var connection = GetConnection())
            {
                // Сначала проверяем, существует ли автобус с таким инвентарным номером
                var existingId = GetIdByObject(bus);

                // 2. Подготавливаем команду в зависимости от результата проверки
                var command = connection.CreateCommand();

                if (existingId != null) 
                {
                    // АВТОБУС СУЩЕСТВУЕТ - ОБНОВЛЯЕМ
                    command.CommandText = @"
                        UPDATE Buses 
                        SET ModelId = @ModelId,
                            ColorId = @ColorId,
                            StateBus = @StateBus,
                            RegistrationNumber = @RegistrationNumber,
                            EngineNumber = @EngineNumber,
                            BodyNumber = @BodyNumber,
                            ChassisNumber = @ChassisNumber,
                            ManufactureDate = @ManufactureDate,
                            Mileage = @Mileage,
                            LastOverhaulDate = @LastOverhaulDate
                        WHERE InventoryNumber = @InventoryNumber";
                }
                else
                {
                    // АВТОБУС НЕ СУЩЕСТВУЕТ - СОЗДАЕМ НОВЫЙ
                    command.CommandText = @"
                        INSERT INTO Buses (
                            ModelId,
                            ColorId,
                            InventoryNumber,
                            StateBus,
                            RegistrationNumber,
                            EngineNumber,
                            BodyNumber,
                            ChassisNumber,
                            ManufactureDate,
                            Mileage,
                            LastOverhaulDate
                        ) VALUES (
                            @ModelId,
                            @ColorId,
                            @InventoryNumber,
                            @StateBus,
                            @RegistrationNumber,
                            @EngineNumber,
                            @BodyNumber,
                            @ChassisNumber,
                            @ManufactureDate,
                            @Mileage,
                            @LastOverhaulDate
                        );
                        SELECT last_insert_rowid();";
                }

                // 3. Добавляем параметры
                AddBusParameters(command, bus);

                // 4. Выполняем команду
                command.ExecuteNonQuery();
            }
        }

        // Вспомогательный метод для добавления параметров
        private void AddBusParameters(SqliteCommand command, Bus bus)
        {
            // Внешние ключи
            command.Parameters.AddWithValue("@ModelId", _modelRepository.GetIdByObject(bus.Model));
            command.Parameters.AddWithValue("@ColorId", _colorRepository.GetOrCreate(bus.Color));

            // Уникальный идентификатор
            command.Parameters.AddWithValue("@InventoryNumber", bus.InventoryNumber);

            // Основные данные
            command.Parameters.AddWithValue("@StateBus", bus.State_str);
            command.Parameters.AddWithValue("@RegistrationNumber", bus.RegistrationNumber);
            command.Parameters.AddWithValue("@EngineNumber", bus.EngineNumber);
            command.Parameters.AddWithValue("@BodyNumber", bus.BodyNumber);
            command.Parameters.AddWithValue("@ChassisNumber", bus.ChassisNumber);
            command.Parameters.AddWithValue("@Mileage", bus.Mileage);

            // Даты 
            command.Parameters.AddWithValue("@ManufactureDate",
                bus.ManufactureDate.ToString("yyyy-MM-dd"));

            if (bus.LastOverhaulDate.HasValue)
                command.Parameters.AddWithValue("@LastOverhaulDate",
                    bus.LastOverhaulDate.Value.ToString("yyyy-MM-dd"));
            else
                command.Parameters.AddWithValue("@LastOverhaulDate", DBNull.Value);
        }

        public int GetIdByObject(Bus bus)
        {
            using (var connection = GetConnection())
            {
                // Сначала проверяем, существует ли автобус с таким инвентарным номером
                var checkCommand = connection.CreateCommand();
                checkCommand.CommandText = $@"
                    SELECT BusId FROM {TableName} 
                    WHERE InventoryNumber = @InventoryNumber";
                checkCommand.Parameters.AddWithValue("@InventoryNumber", bus.InventoryNumber);
                object result = checkCommand.ExecuteScalar();
                if (result == null && result != DBNull.Value) throw new Exception($"Автобус с данным инвентарным номером {bus.InventoryNumber} не найден в БД");
                return Convert.ToInt32(result);
            }
        }
        

        public Bus GetObjectById(int id)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        BusId, ModelId, ColorId, InventoryNumber,
                        StateBus, RegistrationNumber, EngineNumber,
                        BodyNumber, ChassisNumber, ManufactureDate,
                        Mileage, LastOverhaulDate
                    FROM {TableName}
                    WHERE BusId = @BusId;";
                command.Parameters.AddWithValue("@BusId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception($"Нет записи в таблице Buses по такому id: {id}");
                    }
                    // 1. Читаем данные из БД
                    reader.Read();
                    int busId = reader.GetInt32(reader.GetOrdinal("BusId"));
                    int modelId = reader.GetInt32(reader.GetOrdinal("ModelId"));
                    int colorId = reader.GetInt32(reader.GetOrdinal("ColorId"));

                    string inventoryNumber = reader.GetString(reader.GetOrdinal("InventoryNumber"));
                    BusState stateBus = BusStateExtensions.GetEnumByString(reader.GetString(reader.GetOrdinal("StateBus")));
                    string registrationNumber = reader.GetString(reader.GetOrdinal("RegistrationNumber"));
                    string engineNumber = reader.GetString(reader.GetOrdinal("EngineNumber"));
                    string bodyNumber = reader.GetString(reader.GetOrdinal("BodyNumber"));
                    string chassisNumber = reader.GetString(reader.GetOrdinal("ChassisNumber"));
                    int mileage = reader.GetInt32(reader.GetOrdinal("Mileage"));

                    DateTime manufactureDate = reader.GetDateTime(reader.GetOrdinal("ManufactureDate"));
                    // LastOverhaulDate может быть NULL
                    DateTime? lastOverhaulDate = null;
                    int lastOverhaulDateOrdinal = reader.GetOrdinal("LastOverhaulDate");
                    if (!reader.IsDBNull(lastOverhaulDateOrdinal))
                    {
                        string lastOverhaulDateStr = reader.GetString(lastOverhaulDateOrdinal);
                        if (DateTime.TryParse(lastOverhaulDateStr, out DateTime parsedDate))
                        {
                            lastOverhaulDate = parsedDate;
                        }
                    }

                    Model model = _modelRepository.GetById(modelId);
                    ColorDataModel color = _colorRepository.GetById(colorId);

                    // 2. Создаем объект
                    var bus = new Bus(inventoryNumber, registrationNumber, model, engineNumber,
                        bodyNumber, chassisNumber, mileage, color.ColorName, manufactureDate, stateBus,
                        lastOverhaulDate);

                    return bus;
                }
            }
        }
    }
}
