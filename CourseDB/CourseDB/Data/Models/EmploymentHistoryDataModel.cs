using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class EmploymentHistoryDataModel
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime StartEventDate { get; set; }
        public string NumberEvent { get; set; }
        public string DocumentType { get; set; }
        public int Archive {  get; set; }
        public string ReasonStopEvent { get; set; }
        public DateTime? DeletionDate { get; set; }
        // Foreign Keys 
        public int EmployeeId { get; set; }
        public int PostId { get; set; }
    }
}
