using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class Part
    {
        public Guid PartId { get; set; }        
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<PartMeasurementSP> MeasurementSP { get; set; }

        public void CopyInfo(Part copy)
        {
            copy.PartNumber = this.PartNumber;
            copy.Revision = this.Revision;
            copy.Item = this.Item;
            copy.Description = this.Description;            
        }
    }
}
