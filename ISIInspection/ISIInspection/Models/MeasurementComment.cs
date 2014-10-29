using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class MeasurementComment
    {
        public Guid MeasurementCommentId { get; set; }

        public Guid RouterId { get; set; }
        public Guid WorkOrderId { get; set; }
        public Guid UserId { get; set; }

        public Guid MeasurementId { get; set; }
        public PartMeasurementActual Measurement { get; set; }

        public string Comment { get; set; }
    }
}
