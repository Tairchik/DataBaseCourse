using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public interface ITrip
    {
        string Id { get; set; }
        IRout Rout_ { get; set; }
        IEmployee Driver { get; set; }
        IEmployee Conductor { get; set; }
        IBus Bus_ { get; set; }
        DateTime DateStart { get; set; }
        TimeSpan TimeStart { get; set; }
        bool DirectRout { get; set; }
        decimal ActualRevenue { get; set; }
        int DirectRoutInt { set; }
    }
}
