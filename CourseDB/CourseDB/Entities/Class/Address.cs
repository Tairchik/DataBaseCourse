using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Address
    {
        private string _city;
        private string _street;
        private string _house;
        private string _apartment;

        public string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Город не может быть пустым");
                if (!value.All(c => char.IsLetter(c) || c == '-' || c == ' '))
                    throw new ArgumentException("Название города может содержать только буквы, дефисы и пробелы");
                _city = value.Trim();
            }
        }

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


        public override string ToString()
        {
            return $"{City}, {Street}, {House}" +
                   (string.IsNullOrEmpty(Apartment) ? "" : $", кв. {Apartment}");
        }
    }
}
