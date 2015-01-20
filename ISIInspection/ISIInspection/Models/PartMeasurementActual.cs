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
        public string InspectionDevice { get; set; }
        public int QuantityNumber { get; set; }
        public string InspectionComment { get; set; }

        //Mietrak
        public int UserId { get; set; }

        ////Parent Part
        //public Guid FabricatedPartId { get; set; }
        //public virtual FabricatedPart FabricatedPart { get; set; }

        //Parent Measurement
        public Guid PartMeasurementSPId { get; set; }
        public virtual PartMeasurementSP PartMeasurementSP { get; set; }

        //Child Comments
        public virtual List<MeasurementComment> Measurements { get; set; }        
    }
}
