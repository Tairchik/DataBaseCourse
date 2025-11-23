using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class BusDataModel
    {
        public string InventoryNumber { get; set; } // Primary Key (Business Key)
        public string State { get; set; }
        public string RegistrationNumber { get; set; }
        public string EngineNumber { get; set; }
        public string BodyNumber { get; set; }
        public string ChassisNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Mileage { get; set; }
        public DateTime LastMajorRepairDate { get; set; }

        // Foreign Keys
        public int ModelId { get; set; }
        public int ColorId { get; set; }
    }
}
