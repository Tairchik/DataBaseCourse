using System;
using System.Collections.Generic;


namespace CourseDB.Data
{
    public class ColorRepository : BaseRepositorySimple<ColorDataModel>
    {
        protected override string TableName => "Colors";
        protected override string Name => "ColorName";

        protected override List<ColorDataModel> Converter(Dictionary<int, string> data)
        {
            var models = new List<ColorDataModel>();
            foreach (var item in data)
            {
                models.Add(new ColorDataModel { Id = item.Key, ColorName = item.Value });
            }
            return models;
        }

        /// <summary>
        /// Получает запись станции по ее ID и переводит ее в объект BusStationDataModel.
        /// </summary>
        public override ColorDataModel GetById(int id)
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
                        return new ColorDataModel
                        {
                            // 1. Извлечение Id (как Int32)
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),

                            // 2. Извлечение имени
                            ColorName = reader.GetString(reader.GetOrdinal(Name))
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
        public override int Update(ColorDataModel model)
        {
            // Проверяем, что ID установлен
            if (model.Id <= 0)
            {
                throw new ArgumentException("ID цвета должен быть больше нуля для выполнения обновления.");
            }
            if (string.IsNullOrEmpty(model.ColorName))
            {
                throw new ArgumentException("Название цвета не должно быть пустым.");
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
                command.Parameters.AddWithValue("@NewName", model.ColorName);

                // ID для WHERE-условия
                command.Parameters.AddWithValue("@Id", model.Id);

                // 3. Выполняем команду
                return command.ExecuteNonQuery();
            }
        }
    }
}
