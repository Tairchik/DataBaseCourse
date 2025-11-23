using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class BrandRepository : BaseRepository
    {
        protected override string TableName => "Brands";
        /// <summary>
        /// Находит ID марки по имени или создает новую запись.
        /// </summary>
        public int GetOrCreateBrandId(string brandName)
        {
            // 1. Поиск ID по имени
            int existingId = FindBrandIdByName(brandName);

            if (existingId > 0)
            {
                return existingId;
            }

            // 2. Если не найдено, создаем новую запись и получаем новый int ID
            return CreateNewBrand(brandName);
        }
        private int FindBrandIdByName(string brandName)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                // Ищем Id, который должен быть int
                command.CommandText = "SELECT Id FROM Brands WHERE BrandName = @BrandName COLLATE NOCASE;";
                command.Parameters.AddWithValue("@BrandName", brandName);

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
        private int CreateNewBrand(string brandName)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // 1. INSERT: Исключаем Id из запроса, чтобы SQLite сгенерировал его
                command.CommandText = @"
                    INSERT INTO Brands (BrandName) 
                    VALUES (@BrandName)";

                command.Parameters.AddWithValue("@BrandName", brandName);

                command.ExecuteNonQuery();

                // 2. Получаем сгенерированный ID
                command.CommandText = "SELECT last_insert_rowid();";
                long newIdLong = (long)command.ExecuteScalar();

                return (int)newIdLong;
            }
        }
        /// <summary>
        /// Удаляет марку из БД по ее имени. Поиск нечувствителен к регистру (COLLATE NOCASE).
        /// </summary>
        /// <param name="brandName">Имя марки для удаления.</param>
        /// <returns>Количество удаленных строк (0 или 1).</returns>
        public int Delete(string brandName)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Удаляем запись, используя COLLATE NOCASE для поиска без учета регистра.
                command.CommandText = "DELETE FROM Brands WHERE BrandName = @BrandName COLLATE NOCASE;";
                command.Parameters.AddWithValue("@BrandName", brandName);

                return command.ExecuteNonQuery();
            }
        }


    }
}
