using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseDB.Data;

namespace CourseDB
{
    public class StreetRepository : BaseRepositorySimple<StreetDataModel>
    {
        protected override string TableName => "Streets";
        protected override string Name => "StreetName";
        protected override List<StreetDataModel> Converter(Dictionary<int, string> data)
        {
            var models = new List<StreetDataModel>();
            foreach (var item in data)
            {
                models.Add(new StreetDataModel { Id = item.Key, StreetName = item.Value });
            }
            return models;
        }
        /// <summary>
        /// Получает запись станции по ее ID и переводит ее в объект BusStationDataModel.
        /// </summary>
        public override StreetDataModel GetById(int id)
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
                        return new StreetDataModel
                        {
                            // 1. Извлечение Id (как Int32)
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),

                            // 2. Извлечение имени
                            StreetName = reader.GetString(reader.GetOrdinal(Name))
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
        public override int Update(StreetDataModel model)
        {
            // Проверяем, что ID установлен
            if (model.Id <= 0)
            {
                throw new ArgumentException("ID улицы должен быть больше нуля для выполнения обновления.");
            }
            if (string.IsNullOrEmpty(model.StreetName))
            {
                throw new ArgumentException("Название улицы не должно быть пустым.");
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
                command.Parameters.AddWithValue("@NewName", model.StreetName);

                // ID для WHERE-условия
                command.Parameters.AddWithValue("@Id", model.Id);

                // 3. Выполняем команду
                return command.ExecuteNonQuery();
            }
        }
    }
}
