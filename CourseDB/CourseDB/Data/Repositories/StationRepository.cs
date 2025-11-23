using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class StationRepository : BaseRepositorySimple
    {
        protected override string TableName => "Stations";
        protected override string Name => "StationName";
    }
}
