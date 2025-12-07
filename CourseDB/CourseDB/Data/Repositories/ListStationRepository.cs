using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class ListStationRepository: BaseRepository
    {
        private const string TableName = "ListStations";
        private readonly StationRepository _stationRepository;

        public ListStationRepository(StationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Сохраняет список остановок для маршрута
        /// </summary>
        public void SaveForRout(int routId, List<string> stations)
        {
            for (int i = 0; i < stations.Count; i++)
            {
                // Получаем или создаем остановку
                int stationId = _stationRepository.GetOrCreate(stations[i]);
            }
            using (var connection = GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаляем старые остановки
                        var deleteCommand = connection.CreateCommand();
                        deleteCommand.CommandText = $"DELETE FROM {TableName} WHERE RoutId = @RoutId";
                        deleteCommand.Parameters.AddWithValue("@RoutId", routId);
                        deleteCommand.ExecuteNonQuery();

                        // Добавляем новые остановки с порядковыми номерами
                        for (int i = 0; i < stations.Count; i++)
                        {
                            string stationName = stations[i];

                            var insertCommand = connection.CreateCommand();
                            insertCommand.CommandText = $@"
                                INSERT INTO {TableName} (
                                    RoutId, StationId, OrderNumber
                                ) VALUES (
                                    @RoutId, @StationId, @OrderNumber
                                )";

                            insertCommand.Parameters.AddWithValue("@RoutId", routId);
                            insertCommand.Parameters.AddWithValue("@StationId", _stationRepository.GetIdByName(stationName));
                            insertCommand.Parameters.AddWithValue("@OrderNumber", i + 1); // Порядковый номер с 1

                            insertCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Получает список остановок для маршрута
        /// </summary>
        public List<string> GetByRoutId(int routId)
        {
            var stations = new List<string>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT s.StationName 
                    FROM {TableName} ls
                    INNER JOIN Stations s ON ls.StationId = s.Id
                    WHERE ls.RoutId = @RoutId 
                    ORDER BY ls.OrderNumber";
                command.Parameters.AddWithValue("@RoutId", routId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string stationName = reader.GetString(reader.GetOrdinal("StationName"));
                        stations.Add(stationName);
                    }
                }
            }

            return stations;
        }

        /// <summary>
        /// Получает ID остановок для маршрута
        /// </summary>
        public List<int> GetStationIdsByRoutId(int routId)
        {
            var stationIds = new List<int>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT StationId 
                    FROM {TableName} 
                    WHERE RoutId = @RoutId 
                    ORDER BY OrderNumber";
                command.Parameters.AddWithValue("@RoutId", routId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int stationId = reader.GetInt32(reader.GetOrdinal("StationId"));
                        stationIds.Add(stationId);
                    }
                }
            }

            return stationIds;
        }

        /// <summary>
        /// Удаляет все остановки для маршрута
        /// </summary>
        public int DeleteByRoutId(int routId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE RoutId = @RoutId";
                command.Parameters.AddWithValue("@RoutId", routId);

                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Получает маршруты, проходящие через остановку
        /// </summary>
        public List<int> GetRoutsByStationId(int stationId)
        {
            var routIds = new List<int>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT DISTINCT RoutId 
                    FROM {TableName} 
                    WHERE StationId = @StationId";
                command.Parameters.AddWithValue("@StationId", stationId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int routId = reader.GetInt32(reader.GetOrdinal("RoutId"));
                        routIds.Add(routId);
                    }
                }
            }

            return routIds;
        }

        /// <summary>
        /// Получает порядковый номер остановки в маршруте
        /// </summary>
        public int GetOrderNumber(int routId, int stationId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT OrderNumber 
                    FROM {TableName} 
                    WHERE RoutId = @RoutId AND StationId = @StationId";
                command.Parameters.AddWithValue("@RoutId", routId);
                command.Parameters.AddWithValue("@StationId", stationId);

                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }
}
