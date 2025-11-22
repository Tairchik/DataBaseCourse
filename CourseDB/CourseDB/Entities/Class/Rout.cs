using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
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
        private List<string> _stations;
        private decimal _revenue;

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

        public decimal Revenue
        {
            get => _revenue;
            set 
            {
                if (value < 0) throw new ArgumentException("Плановая выручка не может быть отрицательной.");
                _revenue = value;
            }
        }
        public TimeSpan TimeRoute
        {
            get => _timeRoute;
            set
            {
                if (value <= TimeSpan.Zero)
                    throw new ArgumentException("Время маршрута должно быть положительным");
                if (value.Minutes < 0) 
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
                if (value < TimeSpan.Zero || value.Minutes < 0)
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
                if (value < TimeSpan.Zero || value.Minutes < 0)
                    throw new ArgumentException($"Время начала обратного маршрута должно быть положительным числом");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время начала обратного маршрута не может превышать 24 часа"); 
                _endTimeReversDirectRout = value;
            }
        }

        public List<string> Stations
        {
            get => _stations;
        }

        public string StartStation
        {
            get
            {
                if (Stations.Count == 0) throw new ArgumentException("Не задан список автобусов.");
                return Stations.First();
            } 
        }

        public string EndStation
        {
            get
            {
                if (Stations.Count == 0) throw new ArgumentException("Не задан список автобусов.");
                return Stations.Last();
            }
        }

        // Конструктор по умолчанию
        public Rout()
        {
            _schedule = new ScheduleList();
            _stations = new List<string>();
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

        // Добавление станции с проверкой на дубликат
        public bool AddStation(string stationName)
        {
            if (string.IsNullOrWhiteSpace(stationName))
            {
                throw new ArgumentException("Название станции не может быть пустым");
            }

            // Проверяем, существует ли уже такая станция (без учета регистра)
            if (Stations.Any(s => s.Equals(stationName, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Станция уже существует
            }

            Stations.Add(stationName);
            return true;
        }

        // Удаление станции по порядковому номеру (индексу)
        public bool RemoveStationByIndex(int index)
        {
            if (index < 0 || index >= Stations.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Индекс должен быть в диапазоне от 0 до {Stations.Count - 1}");
            }

            Stations.RemoveAt(index);
            return true;
        }

        // Альтернативный метод удаления по индексу с проверкой существования
        public bool TryRemoveStationByIndex(int index)
        {
            if (index >= 0 && index < Stations.Count)
            {
                Stations.RemoveAt(index);
                return true;
            }
            return false;
        }

        // Поиск станции по названию (с учетом регистра или без)
        public bool ContainsStation(string stationName, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return Stations.Any(s => s.Equals(stationName, comparison));
        }

        // Получение индекса станции по названию
        public int GetStationIndex(string stationName, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return Stations.FindIndex(s => s.Equals(stationName, comparison));
        }

        // Получение количества станций
        public int StationsCount => Stations.Count;

        // Очистка всех станций
        public void ClearAllStations()
        {
            Stations.Clear();
        }

        private void ValidateTimes()
        {
            if (StartTimeDirectRout > EndTimeDirectRout)
                throw new ArgumentException("Время начала прямого маршрута должно быть раньше времени окончания");
            if (StartTimeReversDirectRout > EndTimeReversDirectRout)
                throw new ArgumentException("Время начала обратного маршрута должно быть раньше времени окончания");

        }

        public List<TimeSpan> GetStartTimesTimeSpan(bool direct)
        {
            // Прямое направление
            if (direct == true)
            {
                return Schedule.GetFullSchedule(StartTimeDirectRout, EndTimeDirectRout);
            }
            // Обратное направление
            else
            {
                return Schedule.GetFullSchedule(StartTimeReversDirectRout, EndTimeReversDirectRout);
            }
        }

        public List<string> GetStartTimesString(bool direct)
        {
            List<string> result = new List<string>();
            // Прямое направление
            if (direct == true)
            {
                foreach (TimeSpan val in Schedule.GetFullSchedule(StartTimeDirectRout, EndTimeDirectRout))
                {
                    result.Add(val.ToString(@"hh\:mm"));
                }

                return result;
            }
            // Обратное направление
            else
            {
                foreach (TimeSpan val in Schedule.GetFullSchedule(StartTimeReversDirectRout, EndTimeReversDirectRout))
                {
                    result.Add(val.ToString(@"hh\:mm"));
                }

                return result;
            }
        }

        public string[] GetStartEndStationByDirect(bool direct) 
        {
            if (direct == true) return new string[] {StartStation, EndStation};
            return new string[] {EndStation, StartStation};
        }
    }
}
