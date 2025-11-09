using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseDB
{
    internal class ScheduleList
    {
        private List<Schedule> schedules;

        public ScheduleList()
        {
            this.schedules = new List<Schedule>();
        }

        public List<Schedule> Schedules 
        {  
            get 
            { 
                return schedules; 
            } 
        }

        // Добавить с проверкой, что графики не пересекаются и в порядке возрастания от 0 до 23
        public void Add(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule), "Расписание не может быть null");

            bool fl = false;


            foreach (var existingSchedule in schedules)
            {
                if (DoSchedulesOverlap(existingSchedule, schedule))
                {
                    throw new InvalidOperationException($"Расписание пересекается с существующим: {existingSchedule.StartHour:00}:00 - {existingSchedule.EndHour:00}:00");
                }
            }

            foreach (var existingSchedule in schedules)
            {
                if (CompareSchedule(existingSchedule, schedule)) 
                {
                    continue;
                }
                fl = true;
                schedules.Insert(schedules.IndexOf(existingSchedule), schedule);
            }

            if (fl == false) schedules.Add(schedule);
        }

        /// <summary>
        /// Сравнивает два графика по часам.
        /// schedule1 - Эталонный,
        /// schedule2 - Сравниваемый
        /// </summary>
        /// <param name="schedule1"></param>
        /// <param name="schedule2"></param>
        /// <returns>True - schedule1 происходит раньше или в момент schedule2</returns>
        public bool CompareSchedule(Schedule schedule1, Schedule schedule2)
        {
            if (schedule1.StartHour <= schedule2.StartHour) return true;
            return false;
        }

        public void Add(int startHour, int endHour, int interval)
        {
            var schedule = new Schedule
            {
                StartHour = startHour,
                EndHour = endHour,
                Interval = interval
            };
            Add(schedule);
        }

        public int GetStartHourScheduleBy(int hour)
        {
            foreach (var schedule in schedules)
            {
                if (hour <= schedule.StartHour) return schedule.StartHour;
                else if (hour <= schedule.EndHour) return hour;
            }
            throw new ArgumentException($"Неверно задан час начала движения автобусов {hour}");
        }
        public int GetEndHourSchedule(int hour)
        {
            for (int i = schedules.Count - 1; i > 0; i--) 
            {
                if (hour >= schedules[i].EndHour) return schedules[i].EndHour;
                else if (hour >= schedules[i].StartHour) return hour;
            }
            throw new ArgumentException($"Неверно задан час конца движения автобусов {hour}");
        }

        public List<TimeSpan> GetFullSchedule(TimeSpan start, TimeSpan end)
        {
            int start_hour = GetStartHourScheduleBy(start.Hours);
            int end_hour = GetEndHourSchedule(end.Hours);

            List<TimeSpan> result = new List<TimeSpan>();

            foreach (var schedule in schedules)
            {
                if (start_hour >= schedule.StartHour && end_hour <= schedule.EndHour)
                {
                    if (end_hour == schedule.EndHour)
                    {
                        TimeSpan time = new TimeSpan();
                        for (int minute = start.Minutes; minute < (schedule.EndHour - schedule.StartHour) * 60; minute+= schedule.Interval)
                        {
                            time = TimeSpan.FromMinutes(minute + schedule.StartHour * 60);
                            result.Add(time);
                        }
                    }
                    else
                    {
                        TimeSpan time = new TimeSpan();
                        for (int minute = start.Minutes; minute < (schedule.EndHour - schedule.StartHour) * 60 - ; minute += schedule.Interval)
                        {
                            time = TimeSpan.FromMinutes(minute + schedule.StartHour * 60);
                            result.Add(time);
                        }
                    }
                    return result;
                }    
                else if (start_hour >= schedule.StartHour && start_hour <= schedule.EndHour)
                {
                    TimeSpan time = new TimeSpan();
                    for (int minute = start.Minutes;  minute < (schedule.EndHour - schedule.StartHour) * 60; minute+=schedule.Interval)
                    {
                        time = TimeSpan.FromMinutes(minute + schedule.StartHour * 60);
                        result.Add(time);
                    }
                }
                else if (end_hour >= schedule.StartHour && end_hour <= schedule.EndHour) 
                {

                }
                else
                {

                }
            }

            return result;
        }

        public void Remove(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule));

            if (!schedules.Remove(schedule))
                throw new InvalidOperationException("Указанное расписание не найдено в списке");
        }
        public void Remove(int start, int end)
        {
            foreach (var schedule in schedules) if (start == schedule.StartHour && end == schedule.EndHour) Remove(schedule);
            throw new InvalidOperationException("Указанное расписание не найдено в списке");
        }

        /// <summary>
        /// Проверка пересечения двух расписаний.
        /// schedule1 - Эталонный,
        /// schedule2 - Сравниваемый
        /// </summary>
        /// <param name="schedule1"></param>
        /// <param name="schedule2"></param>
        /// <returns>True - пересекаются. Примечание: если один график начинается когда второй заканчивается это значит,
        /// что они не пересекаются, вернется false</returns>
        public static bool DoSchedulesOverlap(Schedule schedule1, Schedule schedule2)
        {
            if (schedule1.StartHour <= schedule2.StartHour && schedule1.EndHour > schedule2.StartHour) return true;
            else if (schedule1.StartHour < schedule2.EndHour && schedule1.EndHour >= schedule2.EndHour) return true;
            if(schedule2.StartHour <= schedule1.StartHour && schedule2.EndHour > schedule1.StartHour) return true;
            else if (schedule2.StartHour < schedule1.EndHour && schedule2.EndHour >= schedule1.EndHour) return true;
            return false;
        }

        // Получение расписания для указанного часа
        public Schedule GetScheduleForHour(int start, int end)
        {
            foreach (var schedule in schedules) if (start == schedule.StartHour && end == schedule.EndHour) return schedule;
            throw new InvalidOperationException("Указанное расписание не найдено в списке");
        }


        // Проверка наличия разрывов в расписании
        public bool HasGaps()
        {
            if (schedules.Count < 2) return false;

            for (int i = 0; i < schedules.Count - 1; i++)
            {
                if (schedules[i].EndHour != schedules[i + 1].StartHour)
                    return true;
            }
            return false;
        }

        // Получение общего количества рейсов за день
        public int GetTotalTripsCount()
        {
            int total = 0;
            foreach (var schedule in schedules)
            {
                int duration = schedule.EndHour - schedule.StartHour;
                int trips = (duration * 60) / schedule.Interval + 1;
                total += trips;
            }
            return total;
        }

        // Очистка списка расписаний
        public void Clear()
        {
            schedules.Clear();
        }

        public override string ToString()
        {
            if (schedules.Count == 0) return "Расписаний нет";

            var scheduleStrings = schedules.Select(s => $"{s.StartHour:00}:00-{s.EndHour:00}:00 (инт.{s.Interval}мин)");
            return string.Join(" → ", scheduleStrings);
        }
    }
}
