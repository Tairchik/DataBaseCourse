using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseDB
{
    public class EmploymentHistory : IEmploymentHistory
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

        /// <summary>
        /// Место работы
        /// </summary>
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

        /// <summary>
        /// Тип мероприятия: Прием, Увольнение, Перевод
        /// </summary>
        public TypeEvent TypeEvent
        {
            get => _typeEvent;
            set
            {
                _typeEvent = value;
            }
        }

        /// <summary>
        /// Тип мероприятия: Прием, Увольнение, Перевод. В строковом представлении.
        /// </summary>
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
        /// <summary>
        /// Дата вступления в силу мероприятия 
        /// </summary>
        public DateTime DateEvent
        {
            get => _dateEvent;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата мероприятия не может быть в будущем");

                _dateEvent = value;
            }
        }
        /// <summary>
        /// Дата подписания документа 
        /// </summary>
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

        /// <summary>
        /// Тип документа, например, Приказ, Записка 
        /// </summary>
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

        /// <summary>
        /// Номер документа.
        /// </summary>
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

        /// <summary>
        /// Причина прекращения трудового договора
        /// </summary>
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

        /// <summary>
        /// Если увольнение
        /// </summary>
        /// <param name="post">Должность</param>
        /// <param name="organization">Место работы</param>
        /// <param name="typeEvent">Тип мероприятия</param>
        /// <param name="dateEvent">Дата вступления в силу мероприятия</param>
        /// <param name="dateDocument">Дата подписания договора</param>
        /// <param name="numberDocument">Номер договора</param>
        /// <param name="typeDocument">Тип документа</param>
        /// <param name="reason">Причина об увольнении</param>
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
        /// <summary>
        /// Все кроме увольнения
        /// </summary>
        /// <param name="post">Должность</param>
        /// <param name="organization">Место работы</param>
        /// <param name="typeEvent">Тип мероприятия</param>
        /// <param name="dateEvent">Дата вступления в силу мероприятия</param>
        /// <param name="dateDocument">Дата подписания договора</param>
        /// <param name="numberDocument">Номер договора</param>
        /// <param name="typeDocument">Тип документа</param>
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
