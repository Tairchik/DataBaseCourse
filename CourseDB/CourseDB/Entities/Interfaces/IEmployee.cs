using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    internal interface IEmployee
    {
        string ID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        Gender Gender { get; set; }
        DateTime Birthday { get; set; }



    }
}
