using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime LastLogin { get; set; }
        public string Information { get; set; }

        public virtual List<RanPart> PartsRan { get; set; }
        public virtual List<PartMeasurementActual> Measurements { get; set; }
    }
}
