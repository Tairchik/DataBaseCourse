using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class EmployeeDataModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public int WorkExperienceYears { get; set; }
        public int DriverClass { get; set; }
        public decimal Bonus { get; set; }

        // Foreign Keys
        public int StreetId { get; set; }
        public int PostId { get; set; }
    }
}
