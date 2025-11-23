using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class TripDataModel
    {
        public int Id { get; set; } 
        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int RouteDirection { get; set; }
        public decimal TotalRevenue { get; set; }
        // Foreign Keys
        public int RouteId { get; set; }
        public int DriverId { get; set; }
        public int ConductorId { get; set; }
        public string BusInventoryNumber { get; set; }
    }
}
