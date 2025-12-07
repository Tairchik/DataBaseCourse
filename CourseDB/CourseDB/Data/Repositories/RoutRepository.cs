using CourseDB.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class RoutRepository: BaseRepository
    {
        private const string TableName = "Routs";
        private readonly ScheduleRepository _scheduleRepository;
        private readonly ListStationRepository _listStationRepository;

        // Identity Map как в EmployeeRepository
        private readonly Dictionary<Rout, int> _identityMap = new Dictionary<Rout, int>();
        private readonly Dictionary<int, Rout> _entitiesById = new Dictionary<int, Rout>();

        public RoutRepository(ScheduleRepository scheduleRepository,
                             ListStationRepository listStationRepository)
        {
            _scheduleRepository = scheduleRepository;
            _listStationRepository = listStationRepository;
            // При инициализации загружаем все маршруты в кэш
            GetAll();
        }

        /// <summary>
        /// Сохраняет маршрут в БД (создает новый или обновляет существующий)
        /// </summary>
        public void Save(Rout rout)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Проверяем, есть ли маршрут в identity map
                if (_identityMap.TryGetValue(GetById(GetIdByNumber(rout.NameRoute)), out int existingId))
                {
                    // UPDATE существующего маршрута
                    command.CommandText = $@"
                        UPDATE {TableName} 
                        SET 
                            RoutNumber = @RoutNumber,
                            FullTurnoverTime = @FullTurnoverTime,
                            FirstBusStartTime = @FirstBusStartTime,
                            LastBusStartTime = @LastBusStartTime,
                            FirstBusDepartureFromTerminal = @FirstBusDepartureFromTerminal,
                            LastBusDepartureFromTerminal = @LastBusDepartureFromTerminal,
                            Distance = @Distance,
                            PlannedRevenue = @PlannedRevenue
                        WHERE RoutId = @RoutId";
                    command.Parameters.AddWithValue("@RoutId", existingId);
                }
                else
                {
                    // INSERT нового маршрута
                    command.CommandText = $@"
                        INSERT INTO {TableName} (
                            RoutNumber,
                            FullTurnoverTime, 
                            FirstBusStartTime, 
                            LastBusStartTime, 
                            FirstBusDepartureFromTerminal, 
                            LastBusDepartureFromTerminal, 
                            Distance, 
                            PlannedRevenue
                        ) VALUES (
                            @RoutNumber, 
                            @FullTurnoverTime, 
                            @FirstBusStartTime, 
                            @LastBusStartTime, 
                            @FirstBusDepartureFromTerminal, 
                            @LastBusDepartureFromTerminal, 
                            @Distance, 
                            @PlannedRevenue
                        );
                        SELECT last_insert_rowid();";
                }

                // Добавляем параметры
                command.Parameters.AddWithValue("@RoutNumber", rout.NameRoute);
                command.Parameters.AddWithValue("@FullTurnoverTime", rout.TimeRoute.ToString(@"hh\:mm"));
                command.Parameters.AddWithValue("@FirstBusStartTime", rout.StartTimeDirectRout.ToString(@"hh\:mm"));
                command.Parameters.AddWithValue("@LastBusStartTime", rout.EndTimeDirectRout.ToString(@"hh\:mm"));
                command.Parameters.AddWithValue("@FirstBusDepartureFromTerminal", rout.StartTimeReversDirectRout.ToString(@"hh\:mm"));
                command.Parameters.AddWithValue("@LastBusDepartureFromTerminal", rout.EndTimeReversDirectRout.ToString(@"hh\:mm"));
                command.Parameters.AddWithValue("@Distance", rout.Distance);
                command.Parameters.AddWithValue("@PlannedRevenue", rout.Revenue);

                if (_identityMap.ContainsKey(GetById(GetIdByNumber(rout.NameRoute))))
                {
                    // UPDATE: выполняем команду и сохраняем связанные данные
                    command.ExecuteNonQuery();
                    SaveRelatedData(existingId, rout);
                }
                else
                {
                    // INSERT: получаем новый ID
                    long newId = (long)command.ExecuteScalar();
                    int newIdInt = (int)newId;

                    // Добавляем в словари
                    _identityMap[rout] = newIdInt;
                    _entitiesById[newIdInt] = rout;

                    // Сохраняем связанные данные
                    SaveRelatedData(newIdInt, rout);
                }
            }
        }

        /// <summary>
        /// Сохраняет связанные данные (расписание и остановки)
        /// </summary>
        private void SaveRelatedData(int routId, Rout rout)
        {
            // Сохраняем расписание
            _scheduleRepository.SaveForRout(routId, rout.Schedule);

            // Сохраняем остановки
            _listStationRepository.SaveForRout(routId, rout.Stations);
        }

        /// <summary>
        /// Получает список станций из объекта Rout
        /// </summary>
        private List<string> GetStationsFromRout(Rout rout)
        {
            // Используем рефлексию для доступа к приватному полю _stations
            var stationsField = typeof(Rout).GetField("_stations",
                BindingFlags.NonPublic | BindingFlags.Instance);
            return stationsField?.GetValue(rout) as List<string> ?? new List<string>();
        }

        /// <summary>
        /// Получает маршрут по ID (из кэша)
        /// </summary>
        public Rout GetById(int id)
        {
            if (_entitiesById.TryGetValue(id, out Rout rout))
            {
                return rout;
            }

            // Если нет в кэше, загружаем из БД
            return LoadFromDatabase(id);
        }

        /// <summary>
        /// Загружает маршрут из БД по ID
        /// </summary>
        private Rout LoadFromDatabase(int id)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        RoutId, RoutNumber, FullTurnoverTime,
                        FirstBusStartTime, LastBusStartTime,
                        FirstBusDepartureFromTerminal, LastBusDepartureFromTerminal,
                        Distance, PlannedRevenue
                    FROM {TableName}
                    WHERE RoutId = @RoutId";
                command.Parameters.AddWithValue("@RoutId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var rout = MapReaderToRout(reader);

                        // Загружаем связанные данные
                        LoadRelatedData(rout, id);

                        // Добавляем в словари
                        _identityMap[rout] = id;
                        _entitiesById[id] = rout;

                        return rout;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Маппинг данных из reader в объект Rout
        /// </summary>
        private Rout MapReaderToRout(SqliteDataReader reader)
        {
            return new Rout(
                name: reader.GetString(reader.GetOrdinal("RoutNumber")),
                timeRoute: TimeSpan.Parse(reader.GetString(reader.GetOrdinal("FullTurnoverTime"))),
                distance: reader.GetInt32(reader.GetOrdinal("Distance")),
                startDirect: TimeSpan.Parse(reader.GetString(reader.GetOrdinal("FirstBusStartTime"))),
                endDirect: TimeSpan.Parse(reader.GetString(reader.GetOrdinal("LastBusStartTime"))),
                startReverse: TimeSpan.Parse(reader.GetString(reader.GetOrdinal("FirstBusDepartureFromTerminal"))),
                endReverse: TimeSpan.Parse(reader.GetString(reader.GetOrdinal("LastBusDepartureFromTerminal"))),
                schedule: new ScheduleList() // Временный объект, будет заменен при загрузке
            )
            {
                Revenue = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("PlannedRevenue")))
            };
        }

        /// <summary>
        /// Загружает связанные данные (расписание и остановки)
        /// </summary>
        private void LoadRelatedData(Rout rout, int routId)
        {
            // Загружаем расписание
            var scheduleList = _scheduleRepository.GetByRoutId(routId);
            rout.Schedule = scheduleList;

            // Загружаем остановки
            var stations = _listStationRepository.GetByRoutId(routId);
            foreach (var station in stations) 
            {
                rout.AddStation(station);
            }
        }

        /// <summary>
        /// Получает все маршруты (загружает в кэш при первом вызове)
        /// </summary>
        public List<Rout> GetAll()
        {
            // Очищаем словари перед загрузкой
            _identityMap.Clear();
            _entitiesById.Clear();

            var result = new List<Rout>();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        RoutId, RoutNumber, FullTurnoverTime,
                        FirstBusStartTime, LastBusStartTime,
                        FirstBusDepartureFromTerminal, LastBusDepartureFromTerminal,
                        Distance, PlannedRevenue
                    FROM {TableName}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int routId = reader.GetInt32(reader.GetOrdinal("RoutId"));

                        var rout = MapReaderToRout(reader);

                        // Загружаем связанные данные
                        LoadRelatedData(rout, routId);

                        // Добавляем в словари
                        _identityMap[rout] = routId;
                        _entitiesById[routId] = rout;

                        result.Add(rout);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Удаляет маршрут по ID
        /// </summary>
        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE RoutId = @RoutId";
                command.Parameters.AddWithValue("@RoutId", id);

                command.ExecuteNonQuery();

                // Удаляем из словарей
                if (_entitiesById.TryGetValue(id, out Rout rout))
                {
                    _entitiesById.Remove(id);
                    _identityMap.Remove(rout);
                }
            }
        }

        /// <summary>
        /// Удаляет маршрут по объекту
        /// </summary>
        public void Delete(Rout rout)
        {
            if (rout == null) throw new ArgumentNullException("Маршрут не найден");
            if (_identityMap.TryGetValue(rout, out int existingId))
            {
                Delete(existingId);
            }
           
        }

        /// <summary>
        /// Получает маршрут по номеру
        /// </summary>
        public Rout GetByNumber(string routNumber)
        {
            // Сначала ищем в кэше
            foreach (var kvp in _identityMap)
            {
                if (kvp.Key.NameRoute == routNumber)
                {
                    return kvp.Key;
                }
            }

            // Если нет в кэше, ищем в БД
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT RoutId 
                    FROM {TableName}
                    WHERE RoutNumber = @RoutNumber";
                command.Parameters.AddWithValue("@RoutNumber", routNumber);

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    int routId = Convert.ToInt32(result);
                    return GetById(routId); // Загрузит в кэш
                }

                return null;
            }
        }

        /// <summary>
        /// Получает ID маршрута по объекту
        /// </summary>
        public int GetIdByObject(Rout rout)
        {
            if (_identityMap.TryGetValue(rout, out int id))
            {
                return id;
            }

            throw new Exception($"Маршрут '{rout.NameRoute}' не найден в БД");
        }

        /// <summary>
        /// Получает ID маршрута по номеру
        /// </summary>
        public int GetIdByNumber(string routNumber)
        {
            var rout = GetByNumber(routNumber);
            if (rout != null)
            {
                return GetIdByObject(rout);
            }

            throw new Exception($"Маршрут '{routNumber}' не найден");
        }
    }
}
