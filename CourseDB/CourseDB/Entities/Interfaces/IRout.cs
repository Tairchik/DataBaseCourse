using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public interface IRout
    {
        int ID_rout { get; set; }
        string Name_Route { get; set; }
        TimeSpan TimeRoute { get; set; }
        int Distance {  get; set; }
        decimal Revenue { get;}
        ScheduleList Schedule { get; set; }
        TimeSpan StartTimeDirectRout { get; set; }
        TimeSpan EndTimeDirectRout { get; set; }
        TimeSpan StartTimeReversDirectRout { get; set; }
        TimeSpan EndTimeReversDirectRout { get; set; }
        string StartStation { get;}
        string EndStation { get;}
        List<string> Stations { get; }
        List<string> GetStartTimesString(bool direct);
        List<TimeSpan> GetStartTimesTimeSpan(bool direct);
        string[] GetStartEndStationByDirect(bool direct);
        bool AddStation(string stationName);
        bool RemoveStationByIndex(int index);
        bool TryRemoveStationByIndex(int index);
        bool ContainsStation(string stationName, StringComparison comparison = StringComparison.OrdinalIgnoreCase);
        int GetStationIndex(string stationName, StringComparison comparison = StringComparison.OrdinalIgnoreCase);
        int StationsCount { get; }

    }
}
