using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public interface IControlTrip
    {
        string Id { get; set; }
        TimeSpan TimeLeave { get; set; }
        TimeSpan TimeComingStation { get; set; }
        string ReasonLeave { get; set; }
        int NumRides { get; set; }
    }
}
