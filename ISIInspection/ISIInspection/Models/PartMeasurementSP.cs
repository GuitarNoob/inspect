using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class PartMeasurementSP
    {
        public Guid PartMeasurementSPId { get; set; }        
        public string CharNumber { get; set; }
        public string RefLocation { get; set; }
        public string Requirement { get; set; }
        public string Units { get; set; }
        public decimal PlusTolerance { get; set; }
        public decimal MinusTolerance { get; set; }
        public string CharacteristicDesignator { get; set; }
        public string InspectionDevice { get; set; }

        //Parent Inspection Plan
        public Guid InspectionPlanId { get; set; }
        public virtual InspectionPlan InspectionPlan { get; set; }

        //Child Measurement
        public virtual List<PartMeasurementActual> Measurements { get; set; }  
    }
}
