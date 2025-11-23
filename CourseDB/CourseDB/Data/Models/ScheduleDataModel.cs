using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class ScheduleDataModel
    {
        public int Id { get; set; }
        public int Interval { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        // Foreign Key
        public int RouteId { get; set; }
    }
}
