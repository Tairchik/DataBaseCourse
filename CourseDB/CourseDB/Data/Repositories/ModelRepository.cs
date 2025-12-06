using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CourseDB
{
    public class ModelRepository: BaseRepository
    {
        public string TableName { get => "Models"; }
        private readonly BrandRepository _brandRepository;

        private readonly Dictionary<Model, int> _identityMap = new Dictionary<Model, int>();

        public ModelRepository(BrandRepository brandRepository) 
        {
            _brandRepository = brandRepository;
            GetAll();
        }
        public int GetIdByObject(Model model)
        {
            foreach (var item in _identityMap.Keys)
            {
                if (model.NameModel == item.NameModel) return _identityMap[item];
            }
            throw new Exception($"Объект по значению: {model.NameModel} не найден.");
        }

        public Model GetById(int id)
        {
            return _identityMap.FirstOrDefault(x => x.Value == id).Key;
        }
        /// <summary>
        /// Возвращает актуальную таблицу и обновляет словарь с актуальными записями
        /// </summary>
        /// <returns></returns
        public List<Model> GetAll() 
        {
            _identityMap.Clear();
            var models = new List<Model>();

            using (var connection = GetConnection()) 
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        ModelId, BrandId, ModelName,
                        TotalCapacity, SeatCapacity    
                    FROM {TableName}";
                using (var reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        // 1. Читаем данные из БД
                        int modelId = reader.GetInt32(reader.GetOrdinal("ModelId"));
                        int brandId = reader.GetInt32(reader.GetOrdinal("BrandId"));
                        string modelName = reader.GetString(reader.GetOrdinal("ModelName"));
                        int totalCapacity = reader.GetInt32(reader.GetOrdinal("TotalCapacity"));
                        int seatCapacity = reader.GetInt32(reader.GetOrdinal("SeatCapacity"));

                        BrandDataModel brand = _brandRepository.GetById(brandId);

                        // 2. Создаем объект Model
                        var model = new Model(brand.BrandName, modelName, totalCapacity, seatCapacity);

                        // 3. Заполняем словарь соответствий
                        if (!_identityMap.ContainsKey(model))
                        {
                            _identityMap[model] = modelId;
                        }

                        models.Add(model);
                    }
                }
            }
            return models;
        }

        /// <summary>
        /// Сохранение или создание
        /// </summary>
        /// <param name="post"></param>
        public void Save(Model model)
        {
            using (var connection = GetConnection())
            {
                int brandId = _brandRepository.GetOrCreate(model.NameBrand);
                var command = connection.CreateCommand();

                // Проверяем, есть ли этот объект уже в нашей карте (Identity Map)
                if (_identityMap.TryGetValue(model, out int id))
                {
                    // --- UPDATE (Обновление) ---
                    // Если ID найден, значит запись уже есть в БД -> обновляем её
                    command.CommandText = $@"
                        UPDATE {TableName} 
                        SET BrandId = @BrandId,
                            ModelName = @ModelName, 
                            TotalCapacity = @TotalCapacity,
                            SeatCapacity = @SeatCapacity
                        WHERE ModelId = @ModelId;";

                    command.Parameters.AddWithValue("@ModelId", id);
                }
                else
                {
                    // --- INSERT (Вставка) ---
                    // Если ID нет, значит это новый объект -> создаем запись
                    command.CommandText = $@"
                        INSERT INTO {TableName} (
                            BrandId, ModelName, TotalCapacity, SeatCapacity
                        ) VALUES (
                            @BrandId, @ModelName, @TotalCapacity, @SeatCapacity
                        );";
                }

                // Добавляем параметры (Маппинг свойств объекта в параметры SQL)
                command.Parameters.AddWithValue("@BrandId", brandId);
                command.Parameters.AddWithValue("@ModelName", model.NameModel);
                command.Parameters.AddWithValue("@BrandName", model.NameBrand);
                command.Parameters.AddWithValue("@TotalCapacity", model.FullCapacity);
                command.Parameters.AddWithValue("@SeatCapacity", model.SeatingCapacity);

                command.ExecuteNonQuery();

                // Если это была ВСТАВКА (INSERT), нам нужно получить новый ID
                if (!_identityMap.ContainsKey(model))
                {
                    command.CommandText = "SELECT last_insert_rowid();";
                    long newId = (long)command.ExecuteScalar();

                    // Запоминаем ID для этого объекта
                    _identityMap[model] = (int)newId;
                }
            }
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="post"></param>
        public void Delete(Model model)
        {
            // Мы не можем удалить объект, если не знаем его ID
            if (!_identityMap.TryGetValue(model, out int id))
            {
                // Либо объекта нет в БД, либо мы его еще не загрузили/не сохранили
                return;
            }

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE ModelId = @ModelId;";
                command.Parameters.AddWithValue("@ModelId", id);

                command.ExecuteNonQuery();

                // После удаления убираем объект из карты, так как связи больше нет
                _identityMap.Remove(model);
            }
        }
    }
}
