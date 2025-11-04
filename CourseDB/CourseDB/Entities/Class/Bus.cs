using CourseDB.Entities.Class;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Bus : IBus
    {
        private string _inventoryNumber;
        private string _color;
        private string _registrationNumber;
        private string _engineNumber;
        private string _bodyNumber;
        private string _chassisNumber;
        private int _mileage;
        private DateTime _manufactureDate;
        private DateTime? _lastOverhaulDate;
        private Model _model;
        private BusState _state;

        public string InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Инвентарный номер не может быть пустым");
                if (!Regex.IsMatch(value, @"^[A-ZА-Я0-9\-]+$"))
                    throw new ArgumentException("Инвентарный номер может содержать только буквы, цифры и дефис");

                _inventoryNumber = value.Trim().ToUpper();
            }
        }

        public Model Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentNullException(nameof(Model), "Модель автобуса обязательна");
        }

        public string Color
        {
            get => _color;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Цвет не может быть пустым");
                if (!Regex.IsMatch(value, @"^[A-ZА-ЯЁ\s\-]+$", RegexOptions.IgnoreCase))
                    throw new ArgumentException("Цвет может содержать только буквы, пробелы и дефисы");

                _color = value.Trim();
            }
        }

        public BusState State
        {
            get => _state;
            set
            {
                _state = value;
            }
        }

        public string State_str 
        {
            get 
            {
                return BusStateExtensions.GetStringByEnum(State);
            }
            set 
            {
                State = BusStateExtensions.GetEnumByString(value);
            }
        }

        public string RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Регистрационный номер не может быть пустым");
                // Российский формат: А123БВ196
                var regex = new Regex(@"^[АВЕКМНОРСТУХ]\d{3}[АВЕКМНОРСТУХ]{2}\d{1,3}$", RegexOptions.IgnoreCase);
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Неверный формат регистрационного номера. Пример: А123БВ196 или 1234АВ196");

                _registrationNumber = value.ToUpper().Trim();
            }
        }

        public string EngineNumber
        {
            get => _engineNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер двигателя не может быть пустым");
                if (!Regex.IsMatch(value, @"^[A-Z0-9\-]+$"))
                    throw new ArgumentException("Номер двигателя может содержать только латинские буквы, цифры и дефис");

                _engineNumber = value.Trim().ToUpper();
            }
        }

        public string BodyNumber
        {
            get => _bodyNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер кузова не может быть пустым");
                if (!Regex.IsMatch(value, @"^[A-Z0-9\-]+$"))
                    throw new ArgumentException("Номер кузова может содержать только латинские буквы, цифры и дефис");

                _bodyNumber = value.Trim().ToUpper();
            }
        }

        public string ChassisNumber
        {
            get => _chassisNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер шасси не может быть пустым");
                if (!Regex.IsMatch(value, @"^[A-Z0-9\-]+$"))
                    throw new ArgumentException("Номер шасси может содержать только латинские буквы, цифры и дефис");

                _chassisNumber = value.Trim().ToUpper();
            }
        }

        public DateTime ManufactureDate
        {
            get => _manufactureDate;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата выпуска не может быть в будущем");

                _manufactureDate = value;
            }
        }

        public int Mileage
        {
            get => _mileage;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Пробег не может быть отрицательным");

                _mileage = value;
            }
        }

        public DateTime? LastOverhaulDate
        {
            get => _lastOverhaulDate;
            set
            {
                if (value.HasValue)
                {
                    if (value.Value > DateTime.Now)
                        throw new ArgumentException("Дата последнего капремонта не может быть в будущем");
                    if (value.Value < ManufactureDate)
                        throw new ArgumentException("Дата последнего капремонта не может быть раньше даты выпуска");
                }

                _lastOverhaulDate = value;
            }
        }

        // Конструкторы
        public Bus() { }

        public Bus(string inventoryNumber, Model model, string registrationNumber, DateTime manufactureDate)
        {
            InventoryNumber = inventoryNumber;
            Model = model;
            RegistrationNumber = registrationNumber;
            ManufactureDate = manufactureDate;
            State = BusState.InOperation;
        }
    }
}
