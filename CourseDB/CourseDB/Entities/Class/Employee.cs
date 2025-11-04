using CourseDB.Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Employee : IEmployee
    {
        private string _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthday;
        private int _timeWork;
        private int _classDriver;
        private Post _post;
        private Address _address;
        public List<IEmploymentHistory> _employmentHistories;


        public string ID
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID не может быть пустым");
                if (value.Length > 20)
                    throw new ArgumentException("ID не может превышать 20 символов");
                _id = value.Trim();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым");
                if (value.Length > 50)
                    throw new ArgumentException("Имя не может превышать 50 символов");
                if (!value.All(char.IsLetter))
                    throw new ArgumentException("Имя может содержать только буквы");
                _name = value.Trim();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой");
                if (value.Length > 50)
                    throw new ArgumentException("Фамилия не может превышать 50 символов");
                if (!value.All(char.IsLetter))
                    throw new ArgumentException("Фамилия может содержать только буквы");
                _surname = value.Trim();
            }
        }

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length > 50)
                        throw new ArgumentException("Отчество не может превышать 50 символов");
                    if (!value.All(char.IsLetter))
                        throw new ArgumentException("Отчество может содержать только буквы");
                }
                _patronymic = value?.Trim();
            }
        }

        public Gender Gender { get; set; }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата рождения не может быть в будущем");
                if (value < DateTime.Now.AddYears(-100))
                    throw new ArgumentException("Дата рождения не может быть более 100 лет назад");
                _birthday = value;
            }
        }

        public Address Address
        { 
            get => _address;
            set => _address = value ?? throw new ArgumentNullException(nameof(Address), "Должность не может быть пустой");
        }

        public Post Post
        {
            get => _post;
            set => _post = value ?? throw new ArgumentNullException(nameof(Post), "Должность не может быть пустой");
        }
        
        public int TimeWork
        {
            get => _timeWork;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стаж работы не может быть отрицательным");
                if (value > 60)
                    throw new ArgumentException("Стаж работы не может превышать 60 лет");
                _timeWork = value;
            }
        }

        public int ClassDriver
        {
            get => _classDriver;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Класс водителя не может быть отрицательным");
                if (value > 3)
                    throw new ArgumentException("Класс водителя должен быть в диапазоне от 0 до 3");
                _classDriver = value;
            }
        }


        public List<IEmploymentHistory> GetSortedByTypeEvent(string typeEvent)
        {
            var typeEventEnum = TypeEventExtensions.GetEnumByString(typeEvent);
            return GetSortedByTypeEvent(typeEventEnum);
        }

        public List<IEmploymentHistory> GetSortedByTypeEvent(TypeEvent typeEvent)
        {
            return _employmentHistories
                .Where(history => history.TypeEvent == typeEvent)
                .OrderByDescending(history => history.DateEvent)
                .ToList();
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        public string GetFullName()
        {
            return $"{Surname} {Name} {Patronymic}".Trim();
        }

        public bool HasDriverLicense()
        {
            return ClassDriver > 0;
        }

        public override string ToString()
        {
            return $"{GetFullName()} - {Post?.NamePost}";
        }
    }
}
