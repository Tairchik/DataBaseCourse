using CourseDB.Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    internal interface IBus
    {
        string InventoryNumber { get; set; }
        Model Model { get; set; }
        string Color { get; set; }
        BusState State { get; set; }
        string RegistrationNumber { get; set; }
        string EngineNumber { get; set; }
        string BodyNumber { get; set; }
        string ChassisNumber { get; set; }
        DateTime ManufactureDate { get; set; }
        int Mileage { get; set; }
        DateTime? LastOverhaulDate { get; set; }
    }
}
