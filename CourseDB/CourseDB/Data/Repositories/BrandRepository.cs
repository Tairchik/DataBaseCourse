using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB.Data
{
    public class BrandRepository : BaseRepositorySimple
    {
        protected override string TableName => "Brands";
        protected override string Name => "BrandName";
    }
}
