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
        public string Comment { get; set; }

        public Guid PartMeasurementActualId { get; set; }
        public virtual PartMeasurementActual PartMeasurementActual { get; set; }
        
    }
}
