using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }

        public virtual List<WorkOrder> WorkOrders { get; set; }
        public virtual List<Part> Parts { get; set; }

        public void CopyInfo(Customer custCopy)
        {
            custCopy.Name = this.Name;
            custCopy.Information = this.Information;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
