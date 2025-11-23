using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class ModelDataModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int TotalCapacity { get; set; }
        public int SeatingCapacity { get; set; }

        // Foreign Key to Brand
        public int BrandId { get; set; }
    }
}
