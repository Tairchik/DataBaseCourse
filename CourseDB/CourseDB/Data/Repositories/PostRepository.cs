using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseDB.Data
{
    public class PostRepository: BaseRepository
    {
        public string TableName { get => "Posts"; }
        // Identity Map: Связывает объект Post (ключ) с его ID в БД (значение)
        // Это нужно, потому что в самом классе Post нет свойства Id.
        private readonly Dictionary<Post, int> _identityMap = new Dictionary<Post, int>();

        public PostRepository() 
        {
            GetAll();
        }
        
        public int GetIdByObject(Post post)
        {
            foreach (var item in _identityMap.Keys)
            {
                if (post.NamePost == item.NamePost) return _identityMap[item];
            }
            throw new Exception($"Объект по значению: {post.NamePost} не найден.");
        }

        public int GetIdByObject(string post)
        {
            foreach (var item in _identityMap.Keys)
            {
                if (post == item.NamePost) return _identityMap[item];
            }
            return 0;
        }

        public Post GetById(int id)
        {
            return _identityMap.FirstOrDefault(x => x.Value == id).Key;
        }

        /// <summary>
        /// Чтение
        /// </summary>
        /// <returns></returns>
        public List<Post> GetAll()
        {
            var posts = new List<Post>();
            _identityMap.Clear();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, PostName, Salary FROM {TableName};";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 1. Читаем данные из БД
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        decimal salary = reader.GetDecimal(2);

                        // 2. Создаем доменный объект
                        // Важно: Валидация в сеттерах Post сработает здесь. 
                        // Если в БД лежат некорректные данные, тут вылетит ошибка.
                        var post = new Post(name, salary);

                        // 3. Сохраняем связь "Объект <-> ID" в Identity Map
                        if (!_identityMap.ContainsKey(post))
                        {
                            _identityMap[post] = id;
                        }

                        posts.Add(post);
                    }
                }
            }
            return posts;
        }

        /// <summary>
        /// Сохранение или создание
        /// </summary>
        /// <param name="post"></param>
        public void Save(Post post)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Проверяем, есть ли этот объект уже в нашей карте (Identity Map)
                if (_identityMap.TryGetValue(GetById(GetIdByObject(post.NamePost)), out int id))
                {
                    // --- UPDATE (Обновление) ---
                    // Если ID найден, значит запись уже есть в БД -> обновляем её
                    command.CommandText = $@"
                        UPDATE {TableName} 
                        SET PostName = @PostName, 
                            Salary = @Salary 
                        WHERE Id = @Id;";

                    command.Parameters.AddWithValue("@Id", id);
                }
                else
                {
                    // --- INSERT (Вставка) ---
                    // Если ID нет, значит это новый объект -> создаем запись
                    command.CommandText = $@"
                        INSERT INTO {TableName} (PostName, Salary) 
                        VALUES (@PostName, @Salary);";
                }

                // Добавляем параметры (Маппинг свойств объекта в параметры SQL)
                command.Parameters.AddWithValue("@PostName", post.NamePost);
                command.Parameters.AddWithValue("@Salary", post.Salary);

                command.ExecuteNonQuery();

                // Если это была ВСТАВКА (INSERT), нам нужно получить новый ID
                if (!_identityMap.ContainsKey(post))
                {
                    command.CommandText = "SELECT last_insert_rowid();";
                    long newId = (long)command.ExecuteScalar();

                    // Запоминаем ID для этого объекта
                    _identityMap[post] = (int)newId;
                }
            }
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="post"></param>
        public void Delete(Post post)
        {
            // Мы не можем удалить объект, если не знаем его ID
            if (!_identityMap.TryGetValue(post, out int id))
            {
                // Либо объекта нет в БД, либо мы его еще не загрузили/не сохранили
                return;
            }

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();

                // После удаления убираем объект из карты, так как связи больше нет
                _identityMap.Remove(post);
            }
        }
    }
}
