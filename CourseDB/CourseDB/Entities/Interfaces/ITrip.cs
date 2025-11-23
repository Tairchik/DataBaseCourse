using System;
using System.Collections.Generic;

namespace CourseDB
{
    public interface ITrip
    {
        IRout Rout_ { get; set; }
        IEmployee Driver { get; set; }
        IEmployee Conductor { get; set; }
        IBus Bus_ { get; set; }
        DateTime DateStart { get; set; }
        TimeSpan TimeStart { get; set; }
        bool DirectRout { get; set; }
        decimal ActualRevenue { get; set; }
        int DirectRoutInt { set; }
        List<IControlTrip> ControlTrips { get; }
    }
}
