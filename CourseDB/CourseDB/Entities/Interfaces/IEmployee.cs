using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public interface IEmployee
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        decimal Bonus { get; set; }
        Gender Gender { get; set; }
        DateTime Birthday { get; set; }
        Address Address { get; set; }
        Post Post { get; set; }
        int TimeWork { get; set; }
        int ClassDriver { get; set; }
        List<IEmploymentHistory> GetSortedByTypeEvent(string typeEvent);
        List<IEmploymentHistory> GetSortedByTypeEvent(TypeEvent typeEvent);
    }
}
