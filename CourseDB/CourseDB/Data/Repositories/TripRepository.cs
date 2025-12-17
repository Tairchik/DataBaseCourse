using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class TripRepository: BaseRepository
    {
        private const string TableName = "Trips";
        private readonly RoutRepository _routRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly BusRepository _busRepository;
        private readonly ControlTripRepository _controlTripRepository;

        // Identity Map как в EmployeeRepository
        private readonly Dictionary<Trip, int> _identityMap = new Dictionary<Trip, int>();
        private readonly Dictionary<int, Trip> _entitiesById = new Dictionary<int, Trip>();

        public TripRepository(RoutRepository routRepository,
                            EmployeeRepository employeeRepository,
                            BusRepository busRepository,
                            ControlTripRepository controlTripRepository)
        {
            _routRepository = routRepository;
            _employeeRepository = employeeRepository;
            _busRepository = busRepository;
            _controlTripRepository = controlTripRepository;

            // При инициализации загружаем все рейсы в кэш
            GetAll();
        }

        /// <summary>
        /// Сохраняет рейс в БД (создает новый или обновляет существующий)
        /// </summary>
        public void Save(Trip trip)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                // Проверяем, есть ли рейс в identity map
                if (_identityMap.TryGetValue(trip, out int existingId))
                {
                    // UPDATE существующего рейса
                    command.CommandText = $@"
                        UPDATE {TableName} 
                        SET 
                            RoutId = @RoutId,
                            DriverId = @DriverId,
                            BusId = @BusId,
                            ConductorId = @ConductorId,
                            TripDate = @TripDate,
                            StartTime = @StartTime,
                            Direction = @Direction,
                            ActualRevenue = @ActualRevenue
                        WHERE TripId = @TripId";
                    command.Parameters.AddWithValue("@TripId", existingId);
                }
                else
                {
                    // INSERT нового рейса
                    command.CommandText = $@"
                        INSERT INTO {TableName} (
                            RoutId, DriverId, BusId, ConductorId,
                            TripDate, StartTime, Direction, ActualRevenue
                        ) VALUES (
                            @RoutId, @DriverId, @BusId, @ConductorId,
                            @TripDate, @StartTime, @Direction, @ActualRevenue
                        );
                        SELECT last_insert_rowid();";
                }

                // Добавляем параметры
                command.Parameters.AddWithValue("@RoutId", _routRepository.GetIdByNumber(trip.Rout_.NameRoute));
                command.Parameters.AddWithValue("@DriverId", _employeeRepository.GetIdByObject(trip.Driver as Employee));
                command.Parameters.AddWithValue("@BusId", _busRepository.GetIdByObject((trip.Bus_ as Bus)));

                if (trip.Conductor != null)
                    command.Parameters.AddWithValue("@ConductorId", _employeeRepository.GetIdByObject(trip.Conductor as Employee));
                else
                    command.Parameters.AddWithValue("@ConductorId", DBNull.Value);

                command.Parameters.AddWithValue("@TripDate", trip.DateStart.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@StartTime", trip.TimeStart.ToString(@"hh\:mm"));
                command.Parameters.AddWithValue("@Direction", trip.DirectRout ? 1 : 0);
                command.Parameters.AddWithValue("@ActualRevenue", trip.ActualRevenue);

                if (_identityMap.ContainsKey(trip))
                {
                    // UPDATE: выполняем команду и сохраняем связанные данные
                    command.ExecuteNonQuery();

                    // Сохраняем контрольные точки
                    _controlTripRepository.SaveForTrip(existingId, trip._controlTrips);
                }
                else
                {
                    // INSERT: получаем новый ID
                    long newId = (long)command.ExecuteScalar();
                    int newIdInt = (int)newId;

                    // Добавляем в словари
                    _identityMap[trip] = newIdInt;
                    _entitiesById[newIdInt] = trip;

                    // Сохраняем контрольные точки
                    _controlTripRepository.SaveForTrip(newIdInt, trip.ControlTrips);
                }
            }
        }

        /// <summary>
        /// Получает список контрольных точек из объекта Trip через рефлексию
        /// </summary>
        private List<IControlTrip> GetControlTripsFromTrip(Trip trip)
        {
            var controlTripsField = typeof(Trip).GetField("_controlTrips",
                BindingFlags.NonPublic | BindingFlags.Instance);

            return controlTripsField?.GetValue(trip) as List<IControlTrip> ?? new List<IControlTrip>();
        }

        /// <summary>
        /// Получает рейс по ID (из кэша или из БД)
        /// </summary>
        public Trip GetById(int id)
        {
            // Сначала ищем в кэше
            if (_entitiesById.TryGetValue(id, out Trip trip))
            {
                return trip;
            }

            // Если нет в кэше, загружаем из БД
            return LoadFromDatabase(id);
        }

        /// <summary>
        /// Загружает рейс из БД по ID
        /// </summary>
        private Trip LoadFromDatabase(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        TripId, RoutId, DriverId, BusId, ConductorId,
                        TripDate, StartTime, Direction, ActualRevenue
                    FROM {TableName}
                    WHERE TripId = @TripId";
                command.Parameters.AddWithValue("@TripId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    reader.Read();

                    // Маппинг данных из БД
                    int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                    int routId = reader.GetInt32(reader.GetOrdinal("RoutId"));
                    int driverId = reader.GetInt32(reader.GetOrdinal("DriverId"));
                    int busId = reader.GetInt32(reader.GetOrdinal("BusId"));

                    // Conductor может быть NULL
                    int? conductorId = null;
                    int conductorOrdinal = reader.GetOrdinal("ConductorId");
                    if (!reader.IsDBNull(conductorOrdinal))
                    {
                        conductorId = reader.GetInt32(conductorOrdinal);
                    }

                    DateTime tripDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("TripDate")));
                    TimeSpan startTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("StartTime")));
                    bool direction = reader.GetInt32(reader.GetOrdinal("Direction")) == 1;
                    decimal actualRevenue = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("ActualRevenue")));

                    // Получаем связанные объекты
                    var rout = _routRepository.GetById(routId);
                    var driver = _employeeRepository.GetById(driverId);
                    var bus = _busRepository.GetObjectById(busId);

                    Employee conductor = null;
                    if (conductorId.HasValue)
                    {
                        conductor = _employeeRepository.GetById(conductorId.Value);
                    }

                    // Создаем объект Trip
                    var trip = new Trip(
                        dateStart: tripDate,
                        timeStart: startTime,
                        directRout: direction,
                        actualRevenue: actualRevenue,
                        rout: rout,
                        driver: driver,
                        conductor: conductor,
                        bus: bus
                    );

                    // Загружаем контрольные точки
                    LoadControlTrips(trip, tripId);

                    // Добавляем в словари
                    _identityMap[trip] = tripId;
                    _entitiesById[tripId] = trip;

                    return trip;
                }
            }
        }

        /// <summary>
        /// Загружает контрольные точки для рейса
        /// </summary>
        private void LoadControlTrips(Trip trip, int tripId)
        {
            var controlTrips = _controlTripRepository.GetByTripId(tripId);

            // Добавляем контрольные точки в объект Trip через рефлексию
            trip._controlTrips = controlTrips;
        }

        /// <summary>
        /// Получает все рейсы (загружает в кэш)
        /// </summary>
        public List<Trip> GetAll()
        {
            // Очищаем словари перед загрузкой
            _identityMap.Clear();
            _entitiesById.Clear();

            var result = new List<Trip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        TripId, RoutId, DriverId, BusId, ConductorId,
                        TripDate, StartTime, Direction, ActualRevenue
                    FROM {TableName}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                        int routId = reader.GetInt32(reader.GetOrdinal("RoutId"));
                        int driverId = reader.GetInt32(reader.GetOrdinal("DriverId"));
                        int busId = reader.GetInt32(reader.GetOrdinal("BusId"));

                        int? conductorId = null;
                        int conductorOrdinal = reader.GetOrdinal("ConductorId");
                        if (!reader.IsDBNull(conductorOrdinal))
                        {
                            conductorId = reader.GetInt32(conductorOrdinal);
                        }

                        DateTime tripDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("TripDate")));
                        TimeSpan startTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("StartTime")));
                        bool direction = reader.GetInt32(reader.GetOrdinal("Direction")) == 1;
                        decimal actualRevenue = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("ActualRevenue")));

                        // Получаем связанные объекты
                        var rout = _routRepository.GetById(routId);
                        var driver = _employeeRepository.GetById(driverId);
                        var bus = _busRepository.GetObjectById(busId);

                        Employee conductor = null;
                        if (conductorId.HasValue)
                        {
                            conductor = _employeeRepository.GetById(conductorId.Value);
                        }

                        // Создаем объект Trip
                        var trip = new Trip(
                            dateStart: tripDate,
                            timeStart: startTime,
                            directRout: direction,
                            actualRevenue: actualRevenue,
                            rout: rout,
                            driver: driver,
                            conductor: conductor,
                            bus: bus
                        );

                        // Загружаем контрольные точки
                        LoadControlTrips(trip, tripId);

                        // Добавляем в словари
                        _identityMap[trip] = tripId;
                        _entitiesById[tripId] = trip;

                        result.Add(trip);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Удаляет рейс по ID
        /// </summary>
        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE TripId = @TripId";
                command.Parameters.AddWithValue("@TripId", id);

                command.ExecuteNonQuery();

                // Удаляем из словарей
                if (_entitiesById.TryGetValue(id, out Trip trip))
                {
                    _entitiesById.Remove(id);
                    _identityMap.Remove(trip);
                }
            }
        }

        /// <summary>
        /// Удаляет рейс по объекту
        /// </summary>
        public void Delete(Trip trip)
        {
            if (_identityMap.TryGetValue(trip, out int existingId))
            {
                Delete(existingId);
            }
        }

        /// <summary>
        /// Получает ID рейса по объекту
        /// </summary>
        public int GetIdByObject(Trip trip)
        {
            if (_identityMap.TryGetValue(trip, out int id))
            {
                return id;
            }

            throw new Exception($"Рейс не найден в репозитории");
        }

        /// <summary>
        /// Получает рейсы по дате
        /// </summary>
        public List<Trip> GetByDate(DateTime date)
        {
            var result = new List<Trip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT TripId 
                    FROM {TableName} 
                    WHERE TripDate = @TripDate";
                command.Parameters.AddWithValue("@TripDate", date.ToString("yyyy-MM-dd"));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                        var trip = GetById(tripId); // Загрузит в кэш
                        if (trip != null)
                        {
                            result.Add(trip);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получает рейсы по водителю
        /// </summary>
        public List<Trip> GetByDriver(int driverId)
        {
            var result = new List<Trip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT TripId 
                    FROM {TableName} 
                    WHERE DriverId = @DriverId";
                command.Parameters.AddWithValue("@DriverId", driverId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                        var trip = GetById(tripId);
                        if (trip != null)
                        {
                            result.Add(trip);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получает рейсы по автобусу
        /// </summary>
        public List<Trip> GetByBus(int busId)
        {
            var result = new List<Trip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT TripId 
                    FROM {TableName} 
                    WHERE BusId = @BusId";
                command.Parameters.AddWithValue("@BusId", busId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                        var trip = GetById(tripId);
                        if (trip != null)
                        {
                            result.Add(trip);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получает рейсы по маршруту
        /// </summary>
        public List<Trip> GetByRout(int routId)
        {
            var result = new List<Trip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT TripId 
                    FROM {TableName} 
                    WHERE RoutId = @RoutId";
                command.Parameters.AddWithValue("@RoutId", routId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                        var trip = GetById(tripId);
                        if (trip != null)
                        {
                            result.Add(trip);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получает рейсы за период
        /// </summary>
        public List<Trip> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = new List<Trip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT TripId 
                    FROM {TableName} 
                    WHERE TripDate >= @StartDate AND TripDate <= @EndDate";
                command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tripId = reader.GetInt32(reader.GetOrdinal("TripId"));
                        var trip = GetById(tripId);
                        if (trip != null)
                        {
                            result.Add(trip);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получает суммарную выручку за период
        /// </summary>
        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT SUM(ActualRevenue) as TotalRevenue
                    FROM {TableName} 
                    WHERE TripDate >= @StartDate AND TripDate <= @EndDate";
                command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                var result = command.ExecuteScalar();
                return result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0;
            }
        }
    }
}
