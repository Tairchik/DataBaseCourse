using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class ControlTrip : IControlTrip
    {
        private string _id;
        private TimeSpan _timeLeave;
        private TimeSpan _timeComingStation;
        private string _reasonLeave;
        private int _numRides;

        public string Id 
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID не может быть пустым");
                _id = value.Trim();
            }
        }
        public TimeSpan TimeLeave 
        {
            get => _timeLeave;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время снятия с маршрута должно быть положительным");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время снятия с маршрута не может превышать 24 часа");
                _timeLeave = value;
            }
        }
        public TimeSpan TimeComingStation 
        {
            get => _timeComingStation;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время прибытия на конечную должно быть положительным");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время прибытия на конечную не может превышать 24 часа");
                _timeComingStation = value;
            }
        }
        public string ReasonLeave 
        {
            get => _reasonLeave;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Причина снятия с маршрута не может быть пустой.");
                _reasonLeave = value.Trim();
            }
        }
        public int NumRides 
        {
            get => _numRides;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Число поездок не может быть отрицательным.");
                _numRides = value;
            }
        }

        public ControlTrip(string id, TimeSpan timeLeave, TimeSpan timeComingStation, string reasonLeave, int numRides)
        {
            Id = id;
            TimeLeave = timeLeave;
            TimeComingStation = timeComingStation;
            ReasonLeave = reasonLeave;
            NumRides = numRides;
        }
        public ControlTrip(string id, TimeSpan timeComingStation, int numRides)
        {
            Id = id;
            TimeComingStation = timeComingStation;
            NumRides = numRides;
        }
    }
}
