using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Entities.Class
{
    internal class Rout: IRout
    {
        private int _id_rout;
        private string _name_Route;
        private TimeSpan _timeRoute;
        private int _distance;
        private ScheduleList _schedule;
        private TimeSpan _startTimeDirectRout;
        private TimeSpan _endTimeDirectRout;
        private TimeSpan _startTimeReversDirectRout;
        private TimeSpan _endTimeReversDirectRout;

        public int ID_rout
        {
            get => _id_rout;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ID маршрута должен быть положительным числом");
                _id_rout = value;
            }
        }

        public string Name_Route
        {
            get => _name_Route;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название маршрута не может быть пустым");
                if (value.Length > 100)
                    throw new ArgumentException("Название маршрута не может превышать 100 символов");
                _name_Route = value.Trim();
            }
        }

        public TimeSpan TimeRoute
        {
            get => _timeRoute;
            set
            {
                if (value <= TimeSpan.Zero)
                    throw new ArgumentException("Время маршрута должно быть положительным");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время маршрута не может превышать 24 часа");
                _timeRoute = value;
            }
        }

        public int Distance
        {
            get => _distance;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Расстояние должно быть положительным числом");
                _distance = value;
            }
        }

        public ScheduleList Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value ?? throw new ArgumentNullException(nameof(Schedule), "Расписание не может быть null");
            }
        }

        public TimeSpan StartTimeDirectRout
        {
            get => _startTimeDirectRout;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время начала прямого маршрута должно быть положительным числом");
                
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время начала прямого маршрута не может превышать 24 часа");
                _startTimeDirectRout = value;
            }
        }

        public TimeSpan EndTimeDirectRout
        {
            get => _endTimeDirectRout;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время окончания прямого маршрута должно быть положительным числом");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время окончания прямого маршрута не может превышать 24 часа");
                _endTimeDirectRout = value;
            }
        }

        public TimeSpan StartTimeReversDirectRout
        {
            get => _startTimeReversDirectRout;
            set
            {

                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время начала обратного маршрута должно быть положительным числом");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время начала обратного маршрута не может превышать 24 часа");
                _startTimeReversDirectRout = value;
            }
        }

        public TimeSpan EndTimeReversDirectRout
        {
            get => _endTimeReversDirectRout;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время начала обратного маршрута должно быть положительным числом");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время начала обратного маршрута не может превышать 24 часа"); 
                _endTimeReversDirectRout = value;
            }
        }

        // Конструктор по умолчанию
        public Rout()
        {
            _schedule = new ScheduleList();
        }

        // Конструктор с параметрами
        public Rout(int id, string name, TimeSpan timeRoute, int distance,
                   TimeSpan startDirect, TimeSpan endDirect,
                   TimeSpan startReverse, TimeSpan endReverse, ScheduleList schedule)
        {
            ID_rout = id;
            Name_Route = name;
            TimeRoute = timeRoute;
            Distance = distance;
            StartTimeDirectRout = startDirect;
            EndTimeDirectRout = endDirect;
            StartTimeReversDirectRout = startReverse;
            EndTimeReversDirectRout = endReverse;
            Schedule = schedule;

            ValidateTimes();
        }

        private void ValidateTimes()
        {
            if (StartTimeDirectRout >= EndTimeDirectRout)
                throw new ArgumentException("Время начала прямого маршрута должно быть раньше времени окончания");
            if (StartTimeReversDirectRout >= EndTimeReversDirectRout)
                throw new ArgumentException("Время начала обратного маршрута должно быть раньше времени окончания");

        }

        public List<TimeSpan> GetStartTimesTimeSpan(bool direct)
        {
            List<TimeSpan> result = new List<TimeSpan>();
            // Прямое направление
            if (direct == true)
            {
               
            }
            // Обратное направление
            else
            {

            }
        } 
    }
}
