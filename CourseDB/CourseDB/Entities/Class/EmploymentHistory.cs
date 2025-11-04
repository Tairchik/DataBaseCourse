using CourseDB.Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseDB
{
    internal class EmploymentHistory : IEmploymentHistory
    {
        private Post _post;
        private string _nameOrganization;
        private TypeEvent _typeEvent;
        private DateTime _dateEvent;
        private DateTime _dateDocument;
        private string _numberDocument;
        private string _typeDocument;
        private string _reasons;
        public Post Post
        {
            get => _post;
            set => _post = value ?? throw new ArgumentNullException(nameof(Post), "Должность не может быть пустой");
        }

        public string NameOrganization
        {
            get => _nameOrganization;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Наименование организации не может быть пустым");

                _nameOrganization = value.Trim();
            }
        }

        public TypeEvent TypeEvent
        {
            get => _typeEvent;
            set
            {
                _typeEvent = value;
            }
        }

        public string TypeEventStr 
        {
            get
            {
                return TypeEventExtensions.GetStringByEnum(_typeEvent);
            }
            set
            {
                _typeEvent = TypeEventExtensions.GetEnumByString(value);
            }
        }

        public DateTime DateEvent
        {
            get => _dateEvent;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата события не может быть в будущем");

                _dateEvent = value;
            }
        }

        public DateTime DateDocument
        {
            get => _dateDocument;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата документа не может быть в будущем");

                _dateDocument = value;
            }
        }

        public string TypeDocument
        {
            get => _typeDocument;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тип документа не может быть пустым");

                _typeDocument = value.Trim();
            }
        }

        public string NumberDocument
        {
            get => _numberDocument;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер документа не может быть пустым");
                if (!Regex.IsMatch(value, @"^[0-9\-]+$"))
                    throw new ArgumentException("Номер документа содержит недопустимые символы");

                _numberDocument = value.Trim();
            }
        }

        public string Reasons
        {
            get => _reasons;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Причина об увольнении не может быть пустой");

                _reasons = value.Trim();
            }
        }

        public EmploymentHistory() { }

        public EmploymentHistory(Post post, string organization, TypeEvent typeEvent, DateTime dateEvent, DateTime dateDocument, string numberDocument, string typeDocument, string reason)
        {
            Post = post;
            NameOrganization = organization;
            TypeEvent = typeEvent;
            DateEvent = dateEvent;
            NumberDocument = numberDocument;
            DateDocument = dateDocument; 
            TypeDocument = typeDocument;
            Reasons = reason;
        }

        public EmploymentHistory(Post post, string organization, TypeEvent typeEvent, DateTime dateEvent, DateTime dateDocument, string numberDocument, string typeDocument)
        {
            Post = post;
            NameOrganization = organization;
            TypeEvent = typeEvent;
            DateEvent = dateEvent;
            NumberDocument = numberDocument;
            DateDocument = dateDocument;
            TypeDocument = typeDocument;
        }
    }
}
