using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class FabricatedPart
    {
        public int RouterFK { get; set; }
        public int WorkOrderFK { get; set; }

        public Guid FabricatedPartId { get; set; }

        //Measurements
        public virtual List<PartMeasurementActual> Measurements { get; set; }
    }
}
