using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class RanPart
    {
        public Guid RanPartId { get; set; }        
        public string Information { get; set; }
        public DateTime LastRanTime { get; set; }

        public Guid PartTypeId { get; set; }
        public virtual Part PartType { get; set; }
        public Guid WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual List<PartMeasurementActual> Measurements { get; set; }
    }
}
