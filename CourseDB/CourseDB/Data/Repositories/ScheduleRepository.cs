using CourseDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class ScheduleRepository: BaseRepository
    {
        private const string TableName = "Schedules";

        /// <summary>
        /// Сохраняет расписание для маршрута
        /// </summary>
        public void SaveForRout(int routId, ScheduleList scheduleList)
        {
            using (var connection = GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Удаляем старое расписание
                        var deleteCommand = connection.CreateCommand();
                        deleteCommand.CommandText = $"DELETE FROM {TableName} WHERE RoutId = @RoutId";
                        deleteCommand.Parameters.AddWithValue("@RoutId", routId);
                        deleteCommand.ExecuteNonQuery();

                        // Добавляем новое расписание
                        foreach (var schedule in scheduleList.Schedules)
                        {
                            var insertCommand = connection.CreateCommand();
                            insertCommand.CommandText = $@"
                                INSERT INTO {TableName} (
                                    RoutId, Interval, StartHour, EndHour
                                ) VALUES (
                                    @RoutId, @Interval, @StartHour, @EndHour
                                )";

                            insertCommand.Parameters.AddWithValue("@RoutId", routId);
                            insertCommand.Parameters.AddWithValue("@Interval", schedule.Interval);
                            insertCommand.Parameters.AddWithValue("@StartHour", schedule.StartHour);
                            insertCommand.Parameters.AddWithValue("@EndHour", schedule.EndHour);

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
        /// Получает расписание для маршрута
        /// </summary>
        public ScheduleList GetByRoutId(int routId)
        {
            var scheduleList = new ScheduleList();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT Interval, StartHour, EndHour 
                    FROM {TableName} 
                    WHERE RoutId = @RoutId 
                    ORDER BY StartHour";
                command.Parameters.AddWithValue("@RoutId", routId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var schedule = new Schedule
                        {
                            Interval = reader.GetInt32(reader.GetOrdinal("Interval")),
                            StartHour = reader.GetInt32(reader.GetOrdinal("StartHour")),
                            EndHour = reader.GetInt32(reader.GetOrdinal("EndHour"))
                        };

                        scheduleList.Add(schedule);
                    }
                }
            }

            return scheduleList;
        }

        /// <summary>
        /// Удаляет все расписания для маршрута
        /// </summary>
        public int DeleteByRoutId(int routId)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableName} WHERE RoutId = @RoutId";
                command.Parameters.AddWithValue("@RoutId", routId);

                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Получает все расписания для всех маршрутов
        /// </summary>
        public Dictionary<int, ScheduleList> GetAll()
        {
            var result = new Dictionary<int, ScheduleList>();

            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $@"
                    SELECT RoutId, Interval, StartHour, EndHour 
                    FROM {TableName} 
                    ORDER BY RoutId, StartHour";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int currentRoutId = reader.GetInt32(reader.GetOrdinal("RoutId"));

                        if (!result.ContainsKey(currentRoutId))
                        {
                            result[currentRoutId] = new ScheduleList();
                        }

                        var schedule = new Schedule
                        {
                            Interval = reader.GetInt32(reader.GetOrdinal("Interval")),
                            StartHour = reader.GetInt32(reader.GetOrdinal("StartHour")),
                            EndHour = reader.GetInt32(reader.GetOrdinal("EndHour"))
                        };

                        result[currentRoutId].Add(schedule);
                    }
                }
            }

            return result;
        }
    }
}
