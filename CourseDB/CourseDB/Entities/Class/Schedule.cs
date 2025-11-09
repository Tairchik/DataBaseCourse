using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    internal class Schedule: IComparable<Schedule>
    {
        private int _startHour;
        private int _endHour;
        private int _interval;

        public int StartHour
        {
            get => _startHour;
            set
            {
                if (value < 0 || value >= 23)
                    throw new ArgumentException("Час начала должен быть в диапазоне от 0 до 23");
                _startHour = value;
            }
        }

        public int EndHour
        {
            get => _endHour;
            set
            {
                if (value < 0 || value >= 23)
                    throw new ArgumentException("Час окончания должен быть в диапазоне от 0 до 23");
                _endHour = value;
            }
        }

        public int Interval
        {
            get => _interval;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Интервал должен быть положительным числом");
                if (value > 1440)
                    throw new ArgumentException("Интервал не может превышать 1440 минут (24 часа)");
                _interval = value;
            }
        }
        public Schedule() { }

        public Schedule (int startHour, int endHour, int interval)
        {
            StartHour = startHour;
            EndHour = endHour;
            if (StartHour > EndHour && EndHour != 0) throw new Exception($"Час старта: {StartHour} не может произойти раньше {EndHour}.\n " +
                $"Перезапишите в виде двух промежутков: от 0 до {EndHour} и от {StartHour} до 0");
            Interval = interval;
        }

        public int CompareTo(Schedule other)
        {
            if (_startHour < other.StartHour) return -1;
            else if (_startHour > other.StartHour) return 1;
            return 0;
        }
    }
}
