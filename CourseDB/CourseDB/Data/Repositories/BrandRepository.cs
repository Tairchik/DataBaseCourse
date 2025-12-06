using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class BrandRepository : BaseRepositorySimple<BrandDataModel>
    {
        protected override string TableName => "Brands";
        protected override string Name => "BrandName";

        protected override List<BrandDataModel> Converter(Dictionary<int, string> data)
        {
            var models = new List<BrandDataModel>();
            foreach (var item in data) 
            {
                models.Add(new BrandDataModel { Id = item.Key, BrandName = item.Value });
            }
            return models;
        }

        /// <summary>
        /// Получает запись марки по ее ID и переводит ее в объект BrandDataModel.
        /// </summary>
        public override BrandDataModel GetById(int id)
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
                        return new BrandDataModel
                        {
                            // 1. Извлечение Id (как Int32)
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),

                            // 2. Извлечение имени
                            BrandName = reader.GetString(reader.GetOrdinal(Name))
                        };
                        // ------------------------
                    }
                    return null; // Возвращаем null, если марка не найдена
                }
            }
        }
        /// <summary>
        /// Обновляет существующую запись Brand в базе данных по ее ID.
        /// </summary>
        /// <param name="station">Объект BrandDataModel с заполненными Id и BrandName.</param>
        /// <returns>Количество измененных строк (0 или 1).</returns>
        public override int Update(BrandDataModel model)
        {
            // Проверяем, что ID установлен
            if (model.Id <= 0)
            {
                throw new ArgumentException("ID модели должен быть больше нуля для выполнения обновления.");
            }
            if (string.IsNullOrEmpty(model.BrandName)) 
            {
                throw new ArgumentException("Название модели не должно быть пустым.");
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
                command.Parameters.AddWithValue("@NewName", model.BrandName);

                // ID для WHERE-условия
                command.Parameters.AddWithValue("@Id", model.Id);

                // 3. Выполняем команду
                return command.ExecuteNonQuery();
            }
        }
    }
}
