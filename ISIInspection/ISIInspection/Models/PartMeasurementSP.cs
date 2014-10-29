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
        public decimal SetPoint { get; set; }
        public decimal Tolerance { get; set; }
        public string Units { get; set; }

        public Guid RouterId { get; set; }

        public void CopyInfo(PartMeasurementSP part)
        {
            part.CharNumber = this.CharNumber;
            part.SetPoint = this.SetPoint;
            part.Tolerance = this.Tolerance;
            part.Units = this.Units;
        }
    }
}
