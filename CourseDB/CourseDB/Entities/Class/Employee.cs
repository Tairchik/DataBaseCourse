using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Employee : IEmployee
    {
        private string _name;
        private string _surname;
        private string _patronymic;
        private DateTime _birthday;
        private int _timeWork;
        private int _classDriver;
        private Post _post;
        private Address _address;
        public List<IEmploymentHistory> _employmentHistories;
        private Gender _gender;
        private decimal _bonus;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым");
                if (!value.All(char.IsLetter))
                    throw new ArgumentException("Имя может содержать только буквы");
                _name = value.Trim();
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой");
                if (!value.All(char.IsLetter))
                    throw new ArgumentException("Фамилия может содержать только буквы");
                _surname = value.Trim();
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (!value.All(char.IsLetter))
                        throw new ArgumentException("Отчество может содержать только буквы");
                }
                _patronymic = value?.Trim();
            }
        }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender 
        {
            get => _gender;
            set
            {
                _gender = value;
            }
        }
        /// <summary>
        /// Пол в строковом представлении. Возвращает: "Мужской", "Женский"
        /// </summary>
        public string GenderStr
        {
            get
            {
                return GenderExtensions.GetStringByEnum(_gender);
            }
            set 
            {
                _gender = GenderExtensions.GetEnumByString(value);
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
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

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public Address Address
        { 
            get => _address;
            set => _address = value ?? throw new ArgumentNullException(nameof(Address), "Адрес не может быть пустым");
        }

        /// <summary>
        /// Должность в компании
        /// </summary>
        public Post Post
        {
            get => _post;
            set => _post = value ?? throw new ArgumentNullException(nameof(Post), "Должность не может быть пустой");
        }
        
        /// <summary>
        /// Стаж работы в компании
        /// </summary>
        public int TimeWork
        {
            get => _timeWork;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стаж работы не может быть отрицательным");
                if (value > 80)
                    throw new ArgumentException("Стаж работы не может превышать 80 лет");
                _timeWork = value;
            }
        }

        /// <summary>
        /// Класс водителя от 0 до 3
        /// </summary>
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

        public decimal Bonus
        {
            get => _bonus;
            set
            {
                if (value < 0m) throw new ArgumentException("Премия не может быть меньше нуля");
                _bonus = value;
            }
        }

        /// <summary>
        /// Возвращает список трудовых записей с сортировкой по мероприятию:
        /// уволен
        /// прием
        /// перевод
        /// </summary>
        /// <param name="typeEvent"></param>
        /// <returns></returns>
        public List<IEmploymentHistory> GetSortedByTypeEvent(string typeEvent)
        {
            var typeEventEnum = TypeEventExtensions.GetEnumByString(typeEvent);
            return GetSortedByTypeEvent(typeEventEnum);
        }
        /// <summary>
        /// Возвращает список трудовых записей с сортировкой по мероприятию:
        /// уволен
        /// прием
        /// перевод
        /// </summary>
        /// <param name="typeEvent"></param>
        /// <returns></returns>
        public List<IEmploymentHistory> GetSortedByTypeEvent(TypeEvent typeEvent)
        {
            return _employmentHistories
                .Where(history => history.TypeEvent == typeEvent)
                .OrderByDescending(history => history.DateEvent)
                .ToList();
        }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        /// <returns>Целое число</returns>
        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        /// <summary>
        /// ФИО 
        /// </summary>
        /// <returns>Строка вида Фамилия Имя Отчество</returns>
        public string GetFullName()
        {
            return $"{Surname} {Name} {Patronymic}".Trim();
        }

        /// <summary>
        /// Имеет ли водитель право вождения
        /// </summary>
        /// <returns>True если класс водителя больше нуля
        /// False - в остальных случаях</returns>
        public bool HasDriverLicense()
        {
            return ClassDriver > 0;
        }

        public override string ToString()
        {
            return $"{GetFullName()} - {Post?.NamePost}";
        }

        public Employee(string name, string surname, Gender gender, DateTime birthday, Address address, Post post, int timeWork, string patronymic="", decimal bonus=0, int classDriver=0)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Gender = gender;
            Birthday = birthday;
            Address = address;
            Post = post;
            TimeWork = timeWork;
            Bonus = bonus;
            ClassDriver = classDriver;
            _employmentHistories = new List<IEmploymentHistory>();
        }

        public Employee() 
        {
            _employmentHistories = new List<IEmploymentHistory>();
        }
    }
}
