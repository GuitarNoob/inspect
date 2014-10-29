using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class PartMeasurementActual
    {
        public Guid PartMeasurementActualId { get; set; }        
        public DateTime CompletedTime { get; set; }
        public decimal MeasuredValue { get; set; }

        public Guid RouterId { get; set; }
        public Guid WorkOrderId { get; set; }

        public Guid UserId { get; set; }
    }
}
