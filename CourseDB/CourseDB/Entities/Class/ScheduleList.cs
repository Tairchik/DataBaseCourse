using System;
using System.Collections.Generic;
using System.Linq;
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

        public IReadOnlyList<Schedule> Schedules => schedules.AsReadOnly();

        // Добавить с проверкой, что графики не пересекаются и в порядке возрастания от 0 до 23
        public void Add(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule), "Расписание не может быть null");

            // Проверка корректности времени расписания
            if (schedule.StartHour >= schedule.EndHour)
                throw new ArgumentException("Время начала должно быть меньше времени окончания");

            // Проверка общего времени выполнения (не более 8 часов)
            if (schedule.EndHour - schedule.StartHour > 8)
                throw new ArgumentException("Общее время выполнения рейса не может превышать 8 часов");

            // Проверка на пересечение с существующими расписаниями
            foreach (var existingSchedule in schedules)
            {
                if (DoSchedulesOverlap(existingSchedule, schedule))
                    throw new InvalidOperationException($"Расписание пересекается с существующим: {existingSchedule.StartHour:00}:00 - {existingSchedule.EndHour:00}:00");
            }

            // Добавление и сортировка
            schedules.Add(schedule);
            schedules.Sort();

            // Проверка непрерывности от 0 до 23
            ValidateContinuousSchedule();
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

        public void Remove(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule));

            if (!schedules.Remove(schedule))
                throw new InvalidOperationException("Указанное расписание не найдено в списке");
        }

        // Проверка пересечения двух расписаний
        private bool DoSchedulesOverlap(Schedule schedule1, Schedule schedule2)
        {
            return schedule1.StartHour < schedule2.EndHour && schedule2.StartHour < schedule1.EndHour;
        }

        // Проверка непрерывности расписания от 0 до 23
        private void ValidateContinuousSchedule()
        {
            if (schedules.Count == 0) return;

            // Проверка начала с 0
            if (schedules[0].StartHour != 0)
                throw new InvalidOperationException("Первое расписание должно начинаться с 0 часов");

            // Проверка окончания в 23
            if (schedules[schedules.Count - 1].EndHour != 23)
                throw new InvalidOperationException("Последнее расписание должно заканчиваться в 23 часа");

            // Проверка непрерывности между расписаниями
            for (int i = 0; i < schedules.Count - 1; i++)
            {
                if (schedules[i].EndHour != schedules[i + 1].StartHour)
                    throw new InvalidOperationException($"Обнаружен разрыв между расписаниями: {schedules[i].EndHour:00}:00 - {schedules[i + 1].StartHour:00}:00");
            }
        }

        // Получение расписания для указанного часа
        public Schedule GetScheduleForHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentException("Час должен быть в диапазоне от 0 до 23");

            return schedules.FirstOrDefault(s => s.StartHour <= hour && s.EndHour > hour);
        }

        // Проверка, покрывает ли расписание весь день (0-23)
        public bool CoversFullDay()
        {
            if (schedules.Count == 0) return false;

            return schedules[0].StartHour == 0 &&
                   schedules[schedules.Count - 1].EndHour == 23 &&
                   !HasGaps();
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

        // Получение всех времени рейсов за день
        public List<TimeSpan> GetAllTripTimes()
        {
            var allTripTimes = new List<TimeSpan>();

            foreach (var schedule in schedules)
            {
                for (int hour = schedule.StartHour; hour < schedule.EndHour; hour++)
                {
                    for (int minute = 0; minute < 60; minute += schedule.Interval)
                    {
                        allTripTimes.Add(new TimeSpan(hour, minute, 0));
                    }
                }
            }

            return allTripTimes.OrderBy(t => t).ToList();
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
