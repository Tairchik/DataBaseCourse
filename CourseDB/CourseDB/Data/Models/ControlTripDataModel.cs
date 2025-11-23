using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class ControlTripDataModel
    {
        public int Id { get; set; }
        public TimeSpan TimeOffRoute { get; set; }
        public TimeSpan ArrivalTimeAtTerminal { get; set; }
        public string ReasonForRemoval { get; set; }
        public int NumberOfRuns { get; set; }

        // Foreign Key
        public int TripId { get; set; }
    }
}
