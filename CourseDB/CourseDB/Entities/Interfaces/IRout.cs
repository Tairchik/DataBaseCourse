using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    internal interface IRout
    {
        int ID_rout { get; set; }
        string Name_Route { get; set; }
        TimeSpan TimeRoute { get; set; }
        int Distance {  get; set; }
        ScheduleList Schedule { get; set; }
        TimeSpan StartTimeDirectRout { get; set; }
        TimeSpan EndTimeDirectRout { get; set; }
        TimeSpan StartTimeReversDirectRout { get; set; }
        TimeSpan EndTimeReversDirectRout { get; set; }
        string GetStartTimesStr(bool direct);
        List<TimeSpan> GetStartTimesTimeSpan(bool direct);
    }
}
