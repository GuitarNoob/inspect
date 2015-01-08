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
        public decimal Requirement { get; set; }
        public int? Quantity { get; set; }
        public string Units { get; set; }
        public decimal PlusTolerance { get; set; }
        public decimal MinusTolerance { get; set; }
        public string CharacteristicDesignator { get; set; }
        public string Note { get; set; }
        public string Comment { get; set; }        

        //Parent Inspection Plan
        public Guid InspectionPlanId { get; set; }
        public virtual InspectionPlan InspectionPlan { get; set; }

        //Child Measurement
        public virtual List<PartMeasurementActual> Measurements { get; set; }  
    }
}
