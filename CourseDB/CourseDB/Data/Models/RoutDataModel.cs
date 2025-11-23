using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class RoutDataModel
    {
        public int Id { get; set; } // Technical Primary Key
        public string RouteName { get; set; } // Unique Business Key
        public TimeSpan FullTime { get; set; }
        public TimeSpan FirstBusDepartureTime { get; set; }
        public TimeSpan LastBusDepartureTime { get; set; }
        public TimeSpan FirstBusEndStationDepartureTime { get; set; }
        public TimeSpan LastBusEndStationDepartureTime { get; set; }
        public int Distance { get; set; }
        public decimal PlannedRevenue { get; set; }
    }
}
