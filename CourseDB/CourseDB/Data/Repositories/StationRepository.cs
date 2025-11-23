using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CourseDB.Data
{
    public class StationRepository : BaseRepositorySimple<BusStationDataModel>
    {
        protected override string TableName => "Stations";
        protected override string Name => "StationName";

        protected override List<BusStationDataModel> Converter(Dictionary<int, string> data)
        {
            var models = new List<BusStationDataModel>();
            foreach (var item in data)
            {
                models.Add(new BusStationDataModel { Id = item.Key, StationName = item.Value });
            }
            return models;
        }
        /// <summary>
        /// Получает запись станции по ее ID и переводит ее в объект BusStationDataModel.
        /// </summary>
        public override BusStationDataModel GetDataModelById(int id)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Запрос: выбираем все столбцы
                command.CommandText = $"SELECT Id, {Name} FROM {TableName} WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BusStationDataModel
                        {
                            // 1. Извлечение Id (как Int32)
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),

                            // 2. Извлечение имени
                            StationName = reader.GetString(reader.GetOrdinal(Name))
                        };
                        // ------------------------
                    }
                    return null; // Возвращаем null, если станция не найдена
                }
            }
        }
        /// <summary>
        /// Обновляет существующую запись Station в базе данных по ее ID.
        /// </summary>
        /// <param name="station">Объект BusStationDataModel с заполненными Id и StationName.</param>
        /// <returns>Количество измененных строк (0 или 1).</returns>
        public override int Update(BusStationDataModel station)
        {
            // Проверяем, что ID установлен
            if (station.Id <= 0)
            {
                throw new ArgumentException("ID станции должен быть больше нуля для выполнения обновления.");
            }
            if (string.IsNullOrEmpty(station.StationName))
            {
                throw new ArgumentException("Название станции не должно быть пустым.");
            }
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // 1. Формируем UPDATE-запрос:
                // - SET: Устанавливаем новое значение столбца {Name}
                // - WHERE: Идентифицируем строку по Id
                command.CommandText = $@"
                    UPDATE {TableName} 
                    SET {Name} = @NewName
                    WHERE Id = @Id;";

                // 2. ДЕМАППИНГ: Связываем свойства объекта с параметрами SQL

                // Новое значение имени
                command.Parameters.AddWithValue("@NewName", station.StationName);

                // ID для WHERE-условия
                command.Parameters.AddWithValue("@Id", station.Id);

                // 3. Выполняем команду
                return command.ExecuteNonQuery();
            }
        }
    }
}
