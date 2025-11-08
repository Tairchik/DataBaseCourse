using System;
using System.Linq;


namespace CourseDB
{
    /// <summary>
    /// Класс адрес - хранит информацию о месте проживания сотрудников 
    /// </summary>
    public class Address
    {
        private string _street; 
        private string _house;
        private string _apartment;

        /// <summary>
        /// Улица
        /// </summary>
        public string Street
        {
            get => _street;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Улица не может быть пустой");
                if (!value.All(c => char.IsLetter(c) || char.IsDigit(c) || c == '-' || c == '.' || c == ' '))
                    throw new ArgumentException("Название улицы может содержать только буквы, цифры, точки, дефисы и пробелы");
                _street = value.Trim();
            }
        }

        /// <summary>
        /// Дом
        /// </summary>
        public string House
        {
            get => _house;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер дома не может быть пустым");
                if (value.Length > 10)
                    throw new ArgumentException("Номер дома не может превышать 10 символов");
                if (!value.All(c => char.IsDigit(c) || c == '/' || c == '-' || char.IsLetter(c)))
                    throw new ArgumentException("Номер дома может содержать только цифры, буквы, слеши и дефисы");
                _house = value.Trim();
            }
        }

        /// <summary>
        /// Квартира
        /// </summary>
        public string Apartment
        {
            get => _apartment;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length > 10)
                        throw new ArgumentException("Номер квартиры не может превышать 10 символов");
                    if (!value.All(c => char.IsDigit(c) || c == '/' || c == '-'))
                        throw new ArgumentException("Номер квартиры может содержать только цифры, слеши и дефисы");
                }
                _apartment = value?.Trim();
            }
        }

        /// <summary>
        /// Возвращает: Улица, дом, кв. №кв
        /// <summary>
        public override string ToString()
        {
            return $"{Street}, {House}" +
                   (string.IsNullOrEmpty(Apartment) ? "" : $", кв. {Apartment}");
        }

        public Address() { }
    }
}
