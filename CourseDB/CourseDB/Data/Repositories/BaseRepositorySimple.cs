using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CourseDB.Data
{
    public abstract class BaseRepositorySimple<T> : BaseRepository
    {
        // Название таблицы
        protected abstract string TableName { get; }
        protected abstract string Name { get; }

        /// <summary>
        /// Находит ID по имени или создает новую запись.
        /// </summary>
        public int GetOrCreate(string name)
        {
            // 1. Поиск ID по имени
            int existingId = FindIdByName(name);

            if (existingId > 0)
            {
                return existingId;
            }

            // 2. Если не найдено, создаем новую запись и получаем новый int ID
            return CreateNew(name);
        }
        public int GetIdByName(string name)
        {
            // 1. Поиск ID по имени
            int existingId = FindIdByName(name);

            if (existingId > 0)
            {
                return existingId;
            }

            throw new Exception($"Такого объекта не существует: {name}");
        }
        private int FindIdByName(string name)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                // Ищем Id, который должен быть int
                command.CommandText = $"SELECT Id FROM {TableName} WHERE {Name} = @name COLLATE NOCASE;";
                command.Parameters.AddWithValue("@name", name);

                object result = command.ExecuteScalar();

                // Проверяем результат. Если null, возвращаем 0.
                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }

                // SQLite возвращает long, поэтому преобразуем его
                return (int)(long)result;
            }
        }
        private int CreateNew(string name)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // 1. INSERT: Исключаем Id из запроса, чтобы SQLite сгенерировал его
                command.CommandText = $@"
                    INSERT INTO {TableName} ({Name}) 
                    VALUES (@name)";

                command.Parameters.AddWithValue("@name", name);

                command.ExecuteNonQuery();

                // 2. Получаем сгенерированный ID
                command.CommandText = "SELECT last_insert_rowid();";
                long newIdLong = (long)command.ExecuteScalar();

                return (int)newIdLong;
            }
        }
        /// <summary>
        /// Удаляет строку из БД по ключу.
        /// </summary>
        /// <param name="id">Id для удаления.</param>
        /// <returns>Количество удаленных строк (0 или 1).</returns>
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
        /// <summary>
        /// Удаляет строку из БД по ее имени. Поиск нечувствителен к регистру (COLLATE NOCASE).
        /// </summary>
        /// <param name="name">Имя для удаления.</param>
        /// <returns>Количество удаленных строк (0 или 1).</returns>
        public virtual int Delete(string name)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Используем интерполяцию строки для подстановки имени таблицы
                command.CommandText = $"DELETE FROM {TableName} WHERE {Name} = @name;";
                command.Parameters.AddWithValue("@name", name);
                return command.ExecuteNonQuery();
            }
        }
        public List<T> GetAll()
        {
            var Data = new Dictionary<int, string>();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, {Name} FROM {TableName};";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);                
                        Data.Add(id, name);
                    }
                }
            }
            return Converter(Data);
        }
        protected abstract List<T> Converter(Dictionary<int, string> data);
        public abstract T GetById(int Id);
        public abstract int Update(T model);
    }
}
