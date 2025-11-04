using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Model
    {
        private string _nameBrand;
        private string _nameModel;
        private int _fullCapacity;
        private int _seatingCapacity;

        public string NameBrand
        {
            get => _nameBrand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название бренда не может быть пустым");
                if (!value.All(c => char.IsLetter(c) || char.IsDigit(c) || c == '-' || c == ' '))
                    throw new ArgumentException("Название бренда может содержать только буквы, цифры, дефисы и пробелы");
                _nameBrand = value.Trim();
            }
        }

        public string NameModel
        {
            get => _nameModel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название модели не может быть пустым");
                if (!value.All(c => char.IsLetter(c) || char.IsDigit(c) || c == '-' || c == ' ' || c == '.'))
                    throw new ArgumentException("Название модели может содержать только буквы, цифры, дефисы, точки и пробелы");
                _nameModel = value.Trim();
            }
        }

        public int FullCapacity
        {
            get => _fullCapacity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полная вместимость должна быть положительным числом");
                if (value < _seatingCapacity)
                    throw new ArgumentException("Полная вместимость не может быть меньше сидячей вместимости");
                _fullCapacity = value;
            }
        }

        public int SeatingCapacity
        {
            get => _seatingCapacity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Посадочная вместимость должна быть положительным числом");
                if (value > _fullCapacity && _fullCapacity > 0)
                    throw new ArgumentException("Сидячая вместимость не может быть больше полной вместимости");
                _seatingCapacity = value;
            }
        }


        public override string ToString()
        {
            return $"{NameBrand} {NameModel} - {FullCapacity} мест ({SeatingCapacity} сидячих)";
        }
    }
}
