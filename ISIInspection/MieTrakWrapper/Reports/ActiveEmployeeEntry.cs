using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{
    public class ActiveEmployeeEntry
    {
        public ActiveEmployeeEntry(
            string workOrder, 
            string assembly, 
            string fname, 
            string lname)
        {
            this.WorkOrderPK = workOrder;
            this.WorkOrderAssemblyPK = assembly;
            this.FirstName = fname;
            this.LastName = lname;
        }


        public string WorkOrderPK { get; set; }
        public string WorkOrderAssemblyPK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
