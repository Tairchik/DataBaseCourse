using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data.Repositories
{
    public class StreetRepository : BaseRepositorySimple
    {
        protected override string TableName => "Streets";
        protected override string Name => "StreetName";
    }
}
