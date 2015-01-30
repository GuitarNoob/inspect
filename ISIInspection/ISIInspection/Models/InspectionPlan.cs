using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    [Serializable]
    public class InspectionPlan
    {
        [Key]
        public Guid InspectionPlanId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 InspectionPlanKey { get; set; }
        public string Type { get; set; }
        public decimal AQLPercentage { get; set; }
        public string Level { get; set; }
        public string CodeLetter { get; set; }
        public int SampleSize { get; set; }
        public int SkipLot { get; set; }
        public int AcceptableDefects { get; set; }
        public int FAIQuantity { get; set; }

        //Mietrak
        public int RouterFK { get; set; }
            
        //Measurements
        public virtual List<PartMeasurementSP> MeasurementCriteria { get; set; }
    }
}
