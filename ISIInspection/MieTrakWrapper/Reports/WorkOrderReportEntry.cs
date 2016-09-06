using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{
    public class WorkOrderReportEntry
    {
        public WorkOrderReportEntry(
             string WorkOrder,
             string Customer,
             string QtyToFab,
             string PartNumber,
             string Description,
             string Operation,
             string WorkCenter,
             string Finish,
             string SetupTime,
             string RunTime,
             string OpCompleteDate,
             string DueDate,
             string DaysOut
            )
        {
            this.WorkOrder = WorkOrder;
            this.Customer = Customer;
            this.QtyToFab = QtyToFab;
            this.PartNumber = PartNumber;
            this.Description = Description;
            this.Operation = Operation;
            this.WorkCenter = WorkCenter;
            this.Finish = Finish;
            this.SetupTime = SetupTime;
            this.RunTime = RunTime;
            this.OpCompleteDate = OpCompleteDate;
            this.DueDate = DueDate;
            this.DaysOut = DaysOut;
        }
        public string WorkOrder { get; set; }
        public string Customer { get; set; }
        public string QtyToFab { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string Operation { get; set; }
        public string WorkCenter { get; set; }
        public string Finish { get; set; }
        public string SetupTime { get; set; }
        public string RunTime { get; set; }
        public string OpCompleteDate { get; set; }
        public string DueDate { get; set; }
        public string DaysOut { get; set; }

        public string IsLate { get; set; }

        public string IsDueToday { get; set; }

        public string IsAlmostLate { get; set; }
    }
}
