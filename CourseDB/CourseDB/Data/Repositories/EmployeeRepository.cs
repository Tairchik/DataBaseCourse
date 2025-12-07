using CourseDB.Data.Repositories;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class EmployeeRepository : BaseRepository
    {
        private readonly PostRepository _postRepository;
        private readonly StreetRepository _streetRepository;
        private readonly EmploymentHistoryRepository _historyRepository;

        // 1. СЛОВАРЬ ДЛЯ SAVE (Найти ID по Объекту)
        private readonly Dictionary<Employee, int> _identityMap = new Dictionary<Employee, int>();

        // 2. СЛОВАРЬ ДЛЯ GET (Найти Объект по ID) - Новое!
        private readonly Dictionary<int, Employee> _entitiesById = new Dictionary<int, Employee>();

        public EmployeeRepository(PostRepository postRepo, StreetRepository streetRepo, EmploymentHistoryRepository historyRepo)
        {
            _postRepository = postRepo;
            _streetRepository = streetRepo;
            _historyRepository = historyRepo;
            DeleteExpiredEmployees();
            GetAll();
        }

        protected string TableName => "Employees";

        /// <summary>
        /// Возвращает актуальную таблицу и обновляет словари с актуальными записями
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll()
        {
            // Если данные уже загружены в кэш, можно вернуть их (опционально)
            // Но для надежности при старте чистим и грузим заново

            var result = new List<Employee>();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        EmployeeId, PostId, StreetId, 
                        Surname, FirstName, Patronymic, 
                        Gender, BirthDate, 
                        House, Apartment, 
                        TimeWork, DriverClass, Bonus, DeletionDate
                    FROM {TableName}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = MapToEmployee(reader);
                        result.Add(employee);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает сотрудника по его Id в БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id)
        {
            if (_entitiesById.TryGetValue(id, out Employee employee))
            {
                return employee;
            }

            return null;
        }

        public int GetIdByObject(Employee employee) 
        {
            if (_identityMap.TryGetValue(employee, out int id))
            {
                return id;
            }

            throw new Exception($"Сотрудник '{employee.Name}' не найден в БД");
        }

        private Employee MapToEmployee(SqliteDataReader reader)
        {

            int employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
            int postId = reader.GetInt32(reader.GetOrdinal("PostId"));
            int streetId = reader.GetInt32(reader.GetOrdinal("StreetId"));

            Post post = _postRepository.GetById(postId);

            var streetModel = _streetRepository.GetById(streetId);

            string house = reader.GetString(reader.GetOrdinal("House"));
            string apartment = reader.IsDBNull(reader.GetOrdinal("Apartment")) ? null : reader.GetString(reader.GetOrdinal("Apartment"));

            var address = new Address(streetModel.StreetName, house, apartment);

            var employee = new Employee
            {
                Surname = reader.GetString(reader.GetOrdinal("Surname")),
                Name = reader.GetString(reader.GetOrdinal("FirstName")),
                Patronymic = reader.IsDBNull(reader.GetOrdinal("Patronymic")) ? null : reader.GetString(reader.GetOrdinal("Patronymic")),
                GenderStr = reader.GetString(reader.GetOrdinal("Gender")),
                Birthday = DateTime.Parse(reader.GetString(reader.GetOrdinal("BirthDate"))),
                TimeWork = reader.GetInt32(reader.GetOrdinal("TimeWork")),
                ClassDriver = reader.GetInt32(reader.GetOrdinal("DriverClass")),
                Bonus = reader.GetDecimal(reader.GetOrdinal("Bonus")),
                Post = post,
                Address = address
            };

            // --- ЗАПОЛНЯЕМ ОБА СЛОВАРЯ ---
            if (!_identityMap.ContainsKey(employee))
            {
                _identityMap[employee] = employeeId;
                _entitiesById[employeeId] = employee;
            }

            // Подгружаем историю
            if (_historyRepository != null)
            {
                employee._employmentHistories = _historyRepository.GetByEmployeeId(employeeId);
            }

            return employee;
        }
        /// <summary>
        /// Удаляет всех сотрудников, у которых дата удаления уже наступила
        /// </summary>
        private void DeleteExpiredEmployees()
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    DELETE FROM {TableName} 
                    WHERE DeletionDate IS NOT NULL 
                    AND DeletionDate < @CurrentDate";

                command.Parameters.AddWithValue("@CurrentDate",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

               command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Сохраняет уже существующего сотрудника или создает нового сотрудника
        /// </summary>
        /// <param name="employee"></param>
        public void Save(Employee employee)
        {
            using (var connection = GetConnection())
            {
                int postId = _postRepository.GetIdByObject(employee.Post);
                int streetId = _streetRepository.GetOrCreate(employee.Address.Street);

                var command = connection.CreateCommand();

                if (_identityMap.TryGetValue(employee, out int existingId))
                {
                    command.CommandText = $@"
                        UPDATE {TableName} 
                        SET PostId=@PostId, StreetId=@StreetId, Surname=@Surname, FirstName=@FirstName,
                            Patronymic=@Patronymic, Gender=@Gender, BirthDate=@BirthDate, House=@House, 
                            Apartment=@Apartment, TimeWork=@TimeWork, DriverClass=@DriverClass, Bonus=@Bonus
                        WHERE EmployeeId = @Id";
                    command.Parameters.AddWithValue("@Id", existingId);
                }
                else
                {
                    command.CommandText = $@"
                        INSERT INTO {TableName} (
                            PostId, StreetId, Surname, 
                            FirstName, Patronymic, Gender, 
                            BirthDate, House, Apartment, 
                            TimeWork, DriverClass, Bonus
                        ) VALUES (
                            @PostId, @StreetId, @Surname, 
                            @FirstName, @Patronymic, @Gender, 
                            @BirthDate, @House, @Apartment, 
                            @TimeWork, @DriverClass, @Bonus
                        );
                        SELECT last_insert_rowid();";
                }

                command.Parameters.AddWithValue("@PostId", postId);
                command.Parameters.AddWithValue("@StreetId", streetId);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@FirstName", employee.Name);
                command.Parameters.AddWithValue("@Patronymic", (object)employee.Patronymic ?? DBNull.Value);
                command.Parameters.AddWithValue("@Gender", employee.GenderStr);
                command.Parameters.AddWithValue("@BirthDate", employee.Birthday.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@House", employee.Address.House);
                command.Parameters.AddWithValue("@Apartment", (object)employee.Address.Apartment ?? DBNull.Value);
                command.Parameters.AddWithValue("@TimeWork", employee.TimeWork);
                command.Parameters.AddWithValue("@DriverClass", employee.ClassDriver);
                command.Parameters.AddWithValue("@Bonus", employee.Bonus);

                if (_identityMap.ContainsKey(employee))
                {
                    command.ExecuteNonQuery();
                    if (_historyRepository != null && employee._employmentHistories != null)
                        _historyRepository.SaveAll(employee._employmentHistories, existingId);
                }
                else
                {
                    long newId = (long)command.ExecuteScalar();
                    int newIdInt = (int)newId;

                    // Добавляем нового сотрудника в словари, чтобы GetById его сразу увидел
                    _identityMap[employee] = newIdInt;
                    _entitiesById[newIdInt] = employee;

                    if (_historyRepository != null && employee._employmentHistories != null)
                        _historyRepository.SaveAll(employee._employmentHistories, newIdInt);
                }
            }
        }
        
        /// <summary>
        /// Удаление сотрудника по id в таблице
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            // 1. Удаление из БД
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE EmployeeId = @Id";
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

            // 2. Удаление из КЭША (Identity Map)
            if (_entitiesById.TryGetValue(id, out Employee employee))
            {
                // Если объект найден по ID, удаляем его из обоих словарей
                _entitiesById.Remove(id);
                _identityMap.Remove(employee);
            }
        }
        /// <summary>
        /// Удаление сотрудника по экземпляру из словаря
        /// </summary>
        /// <param name="employee"></param>
        public void Delete(Employee employee)
        {
            if (_identityMap.TryGetValue(employee, out int existingId))
            {
                Delete(existingId);
            }
        }

        /// <summary>
        /// Установить статус удаления из БД по id сотрудника
        /// </summary>
        /// <param name="idEmployee"></param>
        public void SetStatusOfArchive(int idEmployee) 
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                if (_entitiesById.TryGetValue(idEmployee, out Employee employee))
                {
                    DateTime dateOfDelete = DateTime.Now.AddYears(5);
                    command.CommandText = $@"
                        UPDATE {TableName} 
                        SET DeletionDate=@DelDay 
                        WHERE EmployeeId = @Id";
                    command.Parameters.AddWithValue("@Id", idEmployee);
                    command.Parameters.AddWithValue("@DelDay", dateOfDelete.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        /// <summary>
        /// Установить время удаления из БД 
        /// </summary>
        /// <param name="employee"></param>
        public void SetStatusOfArchive(Employee employee)
        {
            if (_identityMap.TryGetValue(employee, out int existingId))
            {
                SetStatusOfArchive(existingId);
            }
        }
    }
}
