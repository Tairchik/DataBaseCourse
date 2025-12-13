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
                using (var transaction = connection.BeginTransaction())
                {
                        // Удаляем старые контрольные точки
                        var deleteCommand = connection.CreateCommand();
                        deleteCommand.CommandText = $"DELETE FROM {TableName} WHERE TripId = @TripId";
                        deleteCommand.Parameters.AddWithValue("@TripId", tripId);
                        deleteCommand.ExecuteNonQuery();

                        // Добавляем новые контрольные точки
                        foreach (var controlTrip in controlTrips)
                        {
                            var insertCommand = connection.CreateCommand();
                           
                            insertCommand.CommandText = $@"
                                INSERT INTO {TableName} (
                                    TripId, LeaveTime, ArrivalTime, LeaveReason, RidesCount
                                ) VALUES (
                                    @TripId, @LeaveTime, @ArrivalTime, @LeaveReason, @RidesCount
                                )";

                            insertCommand.Parameters.AddWithValue("@TripId", tripId);
                            insertCommand.Parameters.AddWithValue("@RidesCount", controlTrip.NumRides);
                            if (controlTrip.TimeLeave != null) 
                            {
                                TimeSpan timeLeave = (TimeSpan) controlTrip.TimeLeave;
                                insertCommand.Parameters.AddWithValue("@LeaveTime", timeLeave.ToString(@"hh\:mm"));
                                if (controlTrip.TimeComingStation != null) 
                                {
                                    TimeSpan arrivalTime = (TimeSpan) controlTrip.TimeComingStation;
                                    insertCommand.Parameters.AddWithValue("@ArrivalTime", arrivalTime.ToString(@"hh\:mm"));
                                }
                                else 
                                {
                                    insertCommand.Parameters.AddWithValue("@ArrivalTime", DBNull.Value);
                                }
                            }
                            else 
                            {
                                TimeSpan arrivalTime = (TimeSpan)controlTrip.TimeComingStation;
                                insertCommand.Parameters.AddWithValue("@LeaveTime", DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@ArrivalTime", arrivalTime.ToString(@"hh\:mm"));
                            }
                            if (controlTrip.ReasonLeave == null)
                                insertCommand.Parameters.AddWithValue("@LeaveReason", DBNull.Value);
                            else 
                                insertCommand.Parameters.AddWithValue("@LeaveReason", controlTrip.ReasonLeave);
                            insertCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
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
                        TimeSpan? arrivalTime = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("ArrivalTime")))
                        {
                            arrivalTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("ArrivalTime")));
                        }
                        int leaveReasonOrdinal = reader.GetOrdinal("LeaveReason");
                        int ridesCount = reader.GetInt32(reader.GetOrdinal("RidesCount"));

                        if (!reader.IsDBNull(leaveReasonOrdinal))
                        {
                            string leaveReason = reader.GetString(leaveReasonOrdinal);
                            TimeSpan leaveTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("LeaveTime")));
                            var controlTrip = new ControlTrip(
                                timeLeave: leaveTime,
                                timeComingStation: arrivalTime,
                                reasonLeave: leaveReason,
                                numRides: ridesCount
                            );
                            result.Add(controlTrip);
                        }
                        else 
                        {
                            var controlTrip = new ControlTrip(
                                timeComingStation: (TimeSpan) arrivalTime,
                                numRides: ridesCount
                            );
                            result.Add(controlTrip);
                        }
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
