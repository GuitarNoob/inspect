using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class PartComment
    {
        //public Guid RouterId { get; set; }
        public Guid WorkOrderId { get; set; }
        
        public string Comment { get; set; }
    }
}
