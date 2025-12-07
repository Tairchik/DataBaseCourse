using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class ControlTripRepository: BaseRepository
    {
        private const string TableName = "ControlTrips";

        /// <summary>
        /// Сохраняет контрольные точки для рейса
        /// </summary>
        public void SaveForTrip(int tripId, List<IControlTrip> controlTrips)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаляем старые контрольные точки
                        var deleteCommand = connection.CreateCommand();
                        deleteCommand.Transaction = transaction;
                        deleteCommand.CommandText = $"DELETE FROM {TableName} WHERE TripId = @TripId";
                        deleteCommand.Parameters.AddWithValue("@TripId", tripId);
                        deleteCommand.ExecuteNonQuery();

                        // Добавляем новые контрольные точки
                        foreach (var controlTrip in controlTrips)
                        {
                            var insertCommand = connection.CreateCommand();
                            insertCommand.Transaction = transaction;
                            insertCommand.CommandText = $@"
                                INSERT INTO {TableName} (
                                    TripId, LeaveTime, ArrivalTime, LeaveReason, RidesCount
                                ) VALUES (
                                    @TripId, @LeaveTime, @ArrivalTime, @LeaveReason, @RidesCount
                                )";

                            insertCommand.Parameters.AddWithValue("@TripId", tripId);
                            insertCommand.Parameters.AddWithValue("@LeaveTime", controlTrip.TimeLeave.ToString(@"hh\:mm"));
                            insertCommand.Parameters.AddWithValue("@ArrivalTime", controlTrip.TimeComingStation.ToString(@"hh\:mm"));

                            if (!string.IsNullOrEmpty(controlTrip.ReasonLeave))
                                insertCommand.Parameters.AddWithValue("@LeaveReason", controlTrip.ReasonLeave);
                            else
                                insertCommand.Parameters.AddWithValue("@LeaveReason", DBNull.Value);

                            insertCommand.Parameters.AddWithValue("@RidesCount", controlTrip.NumRides);

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
        /// Получает все контрольные точки для рейса
        /// </summary>
        public List<IControlTrip> GetByTripId(int tripId)
        {
            var result = new List<IControlTrip>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT 
                        LeaveTime, ArrivalTime, LeaveReason, RidesCount
                    FROM {TableName} 
                    WHERE TripId = @TripId
                    ORDER BY ArrivalTime";
                command.Parameters.AddWithValue("@TripId", tripId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeSpan leaveTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("LeaveTime")));
                        TimeSpan arrivalTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("ArrivalTime")));

                        string leaveReason = null;
                        int leaveReasonOrdinal = reader.GetOrdinal("LeaveReason");
                        if (!reader.IsDBNull(leaveReasonOrdinal))
                        {
                            leaveReason = reader.GetString(leaveReasonOrdinal);
                        }

                        int ridesCount = reader.GetInt32(reader.GetOrdinal("RidesCount"));

                        var controlTrip = new ControlTrip(
                            timeLeave: leaveTime,
                            timeComingStation: arrivalTime,
                            reasonLeave: leaveReason,
                            numRides: ridesCount
                        );

                        result.Add(controlTrip);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Удаляет все контрольные точки для рейса
        /// </summary>
        public int DeleteByTripId(int tripId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE TripId = @TripId";
                command.Parameters.AddWithValue("@TripId", tripId);

                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Получает суммарное число поездок для рейса
        /// </summary>
        public int GetTotalRidesCountByTripId(int tripId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT SUM(RidesCount) as TotalRides
                    FROM {TableName} 
                    WHERE TripId = @TripId";
                command.Parameters.AddWithValue("@TripId", tripId);

                var result = command.ExecuteScalar();
                return result != DBNull.Value && result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
