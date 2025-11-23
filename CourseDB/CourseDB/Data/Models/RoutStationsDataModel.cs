using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class RoutStationsDataModel
    {
        public int Id { get; set; }
        public int SequenceNumber { get; set; }

        // Foreign Keys
        public int RouteId { get; set; }
        public int StopId { get; set; }
    }
}
