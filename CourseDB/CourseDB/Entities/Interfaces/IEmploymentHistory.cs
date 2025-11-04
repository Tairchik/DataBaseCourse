using CourseDB.Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    internal interface IEmploymentHistory
    {
        Post Post { get; set; }
        string NameOrganization { get; set; }
        TypeEvent TypeEvent { get; set; }
        DateTime DateEvent { get; set; }
        DateTime DateDocument { get; set; }
        string NumberDocument { get; set; }
        string TypeDocument { get; set; }
        string Reasons { get; set; }
       
    }
}
