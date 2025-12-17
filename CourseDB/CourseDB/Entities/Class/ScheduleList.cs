using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace CourseDB
{
    public class ScheduleList
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
        /// <summary>
        /// Добавить с проверкой, что графики не пересекаются и в порядке возрастания от 0 до 23
        /// </summary>
        /// <param name="schedule">Добавляемый график</param>
        public void Add(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule), "Расписание не может быть null");

            bool fl = false;

            foreach (var existingSchedule in schedules)
            {
                if (DoSchedulesOverlap(existingSchedule, schedule))
                {
                    throw new Exception($"Расписание пересекается с существующим: {existingSchedule.StartHour:00}:00 - {existingSchedule.EndHour:00}:00");
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
            if (schedule2.StartHour <= schedule1.StartHour && schedule2.EndHour > schedule1.StartHour) return true;
            else if (schedule2.StartHour < schedule1.EndHour && schedule2.EndHour >= schedule1.EndHour) return true;
            return false;
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

        public int GetHourSchedule(int hour)
        {
            foreach (var schedule in schedules)
            {
                if (hour <= schedule.EndHour && hour >= schedule.StartHour) return hour;
            }
            throw new ArgumentException($"Неверно задан час начала или конца движения автобусов: {hour} часов");
        }
         

        public List<TimeSpan> GetFullSchedule(TimeSpan start, TimeSpan end)
        {
            GetHourSchedule(start.Hours);
            GetHourSchedule(end.Hours);

            int fl_start;
            int fl_end;

            List<TimeSpan> result = new List<TimeSpan>();

            foreach (var schedule in schedules)
            {
                if (schedule.StartHour * 60 > end.TotalMinutes) break;

                fl_start = schedule.StartHour * 60;
                fl_end = schedule.EndHour * 60;

                if (schedule.StartHour * 60 <= start.TotalMinutes && start.TotalMinutes < schedule.EndHour * 60) fl_start = (int)start.TotalMinutes;
                if (schedule.StartHour * 60 < end.TotalMinutes && end.TotalMinutes <= schedule.EndHour * 60) fl_end = (int)end.TotalMinutes;

                for (int c = fl_start; c < fl_end; c += schedule.Interval) 
                {
                    result.Add(TimeSpan.FromMinutes(c));
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
