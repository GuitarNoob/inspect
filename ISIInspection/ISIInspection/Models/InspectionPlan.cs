using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class InspectionPlan
    {
        public Guid InspectionPlanId { get; set; }
        public string Type { get; set; }
        public decimal Size { get; set; }
        public int Frequency { get; set; }
        public decimal AQLPercentage { get; set; }
        public int Level { get; set; }
        public int SkipLot { get; set; }
        public bool FAI { get; set; } //First article inspection

        //Mietrak
        int RouterFK { get; set; }
            
        //Measurements
        public virtual List<PartMeasurementSP> MeasurementCriteria { get; set; } 
    }
}
