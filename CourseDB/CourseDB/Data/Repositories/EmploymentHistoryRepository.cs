using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class EmploymentHistoryRepository : BaseRepository
    {
        protected string TableName => "EmploymentHistory";
        private readonly PostRepository _postRepository;

        public EmploymentHistoryRepository(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// Возвращает список всех записей истории для конкретного сотрудника.
        /// </summary>
        public List<IEmploymentHistory> GetByEmployeeId(int employeeId)
        {
            var histories = new List<IEmploymentHistory>();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT HistoryId, PostId, TypeEvent, Organization, DateEvent, 
                           DateDocument, NumberDocument, TypeDocument, Reasons
                    FROM {TableName}
                    WHERE EmployeeId = @EmployeeId
                    ORDER BY DateEvent DESC;"; // Сортируем по дате, чтобы видеть актуальное сверху

                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        histories.Add(MapToHistory(reader));
                    }
                }
            }
            return histories;
        }

        private EmploymentHistory MapToHistory(SqliteDataReader reader)
        {
            // 1. Чтение ID и загрузка сложного объекта Post
            int postId = reader.GetInt32(reader.GetOrdinal("PostId"));
            Post post = _postRepository.GetById(postId); // Зависимость от PostRepository

            // 2. Обработка nullable-полей
            string reasons = reader.IsDBNull(reader.GetOrdinal("Reasons")) ? null : reader.GetString(reader.GetOrdinal("Reasons"));
            //string deletionDateStr = reader.IsDBNull(reader.GetOrdinal("DeletionDate")) ? null : reader.GetString(reader.GetOrdinal("DeletionDate"));

            var history = new EmploymentHistory(post, reader.GetString(reader.GetOrdinal("Organization")),
                TypeEventExtensions.GetEnumByString(reader.GetString(reader.GetOrdinal("TypeEvent"))), DateTime.Parse(reader.GetString(reader.GetOrdinal("DateEvent"))),
                DateTime.Parse(reader.GetString(reader.GetOrdinal("DateDocument"))), reader.GetString(reader.GetOrdinal("NumberDocument")),
                reader.GetString(reader.GetOrdinal("TypeDocument")), reasons);
  
            return history;
        }

        /// <summary>
        /// Синхронизирует коллекцию записей истории с базой данных, 
        /// полностью перезаписывая записи для данного сотрудника (простая стратегия агрегата).
        /// </summary>
        public void SaveAll(List<IEmploymentHistory> histories, int employeeId)
        {
            if (histories == null) return;

            using (var connection = GetConnection())
            {
                // 1. Очистка: Удаляем все старые записи для данного EmployeeId
                var deleteCommand = connection.CreateCommand();
                deleteCommand.CommandText = $"DELETE FROM {TableName} WHERE EmployeeId = @EmployeeId";
                deleteCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                deleteCommand.ExecuteNonQuery();

                // 2. Вставка: Вставляем все текущие записи из доменной модели
                foreach (var history in histories)
                {
                    // Вставка выполняется в той же транзакции, что и удаление
                    InsertSingleHistory(connection, history, employeeId);
                }
            }
        }

        private void InsertSingleHistory(SqliteConnection connection, IEmploymentHistory history, int employeeId)
        {
            // Сначала получаем ID должности, так как Post - это сложный объект
            int postId = _postRepository.GetByPost(history.Post);

            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = $@"
                INSERT INTO {TableName} (
                    EmployeeId, PostId, TypeEvent, Organization, DateEvent, 
                    DateDocument, NumberDocument, TypeDocument, Reasons
                ) VALUES (
                    @EmployeeId, @PostId, @TypeEvent, @Organization, @DateEvent, 
                    @DateDocument, @NumberDocument, @TypeDocument, @Reasons
                )";

            insertCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            insertCommand.Parameters.AddWithValue("@PostId", postId);

            // Основные поля
            insertCommand.Parameters.AddWithValue("@TypeEvent", history.TypeEventStr);
            insertCommand.Parameters.AddWithValue("@Organization", history.NameOrganization);

            // Даты (в SQLite храним как TEXT YYYY-MM-DD)
            insertCommand.Parameters.AddWithValue("@DateEvent", history.DateEvent.ToString("yyyy-MM-dd"));
            insertCommand.Parameters.AddWithValue("@DateDocument", history.DateDocument.ToString("yyyy-MM-dd"));

            insertCommand.Parameters.AddWithValue("@NumberDocument", history.NumberDocument);
            insertCommand.Parameters.AddWithValue("@TypeDocument", history.TypeDocument);

            // Nullable поля
            insertCommand.Parameters.AddWithValue("@Reasons", (object)history.Reasons ?? DBNull.Value);

            insertCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// Удаляет одну запись трудовой истории по ее внутреннему HistoryId.
        /// (Этот ID нужен только на уровне репозитория, не в доменной модели).
        /// </summary>
        public void Delete(int historyId)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE HistoryId = @HistoryId";
                command.Parameters.AddWithValue("@HistoryId", historyId);
                command.ExecuteNonQuery();
            }
        }
    }
}
