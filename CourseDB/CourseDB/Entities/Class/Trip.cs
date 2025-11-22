using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Trip : ITrip
    {
        private string _id;
        private DateTime _dateStart;
        private TimeSpan _timeStart;
        private bool _directRout;
        private decimal _actualRevenue;
        private IRout _rout;
        private IEmployee _driver;
        private IEmployee _conductor;
        private IBus _bus;

        public Trip(string id, DateTime dateStart, TimeSpan timeStart, bool directRout, 
            decimal actualRevenue, IRout rout, IEmployee driver, IEmployee conductor, IBus bus)
        {
            Id = id;
            DateStart = dateStart;
            TimeStart = timeStart;
            DirectRout = directRout;
            ActualRevenue = actualRevenue;
            _rout = rout;
            _driver = driver;
            _conductor = conductor;
            _bus = bus;
        }

        public Trip(DateTime dateStart, TimeSpan timeStart, bool directRout,
           decimal actualRevenue, IRout rout, IEmployee driver, IEmployee conductor, IBus bus)
        {
            DateStart = dateStart;
            TimeStart = timeStart;
            DirectRout = directRout;
            ActualRevenue = actualRevenue;
            _rout = rout;
            _driver = driver;
            _conductor = conductor;
            _bus = bus;
        }

        public Trip() { }

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
        public DateTime DateStart 
        { 
            get => DateStart;
            set
            {
                if (value < DateTime.Now.AddYears(-100))
                    throw new ArgumentException("Дата выезда не может быть более 100 лет назад");
                _dateStart = value;  
            } 
        }
        public TimeSpan TimeStart
        {
            get => _timeStart;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException($"Время начала рейса должно быть положительным числом");
                if (value > TimeSpan.FromHours(24))
                    throw new ArgumentException("Время начала рейса не может превышать 24 часа");
                _timeStart = value;
            }
        }

        /// <summary>
        /// true - прямое направление
        /// false - обратное направление
        /// </summary>
        public bool DirectRout
        {
            get => _directRout;
            set 
            {
                _directRout = value;
            }
        }

        public int DirectRoutInt
        {
            set
            {
                if (value == 0) _directRout = false;
                else if (value == 1) _directRout = true;
                else throw new ArgumentException($"Направление может принимать только такие значения: 1 и 0.\n Получено: {value}");
            }
        }

        public decimal ActualRevenue 
        {
            get => _actualRevenue;
            set 
            {
                if (value < 0) throw new ArgumentException("Некорректные данные. Фактическая выручка не может быть отрицательной.");
                _actualRevenue = value;
            }
        }
        public IRout Rout_ 
        {
            get => _rout;
            set 
            {
                _rout = value ?? throw new ArgumentNullException("Не инициализирован маршрут.");
            }
        }
        public IEmployee Driver 
        { 
            get => _driver;
            set 
            {
                _driver = value ?? throw new ArgumentNullException("Не инициализирован водитель.");
            } 
        }
        public IEmployee Conductor
        {
            get => _conductor;
            set
            {
                _conductor = value ?? throw new ArgumentNullException("Не инициализирован кондуктор.");
            }
        }

        public IBus Bus_
        {
            get => _bus;
            set
            {
                _bus = value ?? throw new ArgumentNullException("Не инициализирован кондуктор.");
            }
        }
  
    }
}
