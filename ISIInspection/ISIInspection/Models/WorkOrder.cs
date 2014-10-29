using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class WorkOrder
    {
        public Guid WorkOrderId { get; set; }
        public string OrderNumber { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        //public Guid PartId { get; set; }        
        //public virtual Part PartTyps { get; set; }
        
        public virtual List<RanPart> PartsRan { get; set; }
    
        public void CopyInfo(WorkOrder copy)
        {
            copy.OrderNumber = this.OrderNumber;
            copy.CustomerId = this.CustomerId;
            copy.Customer = this.Customer;
        }        
    }
}
