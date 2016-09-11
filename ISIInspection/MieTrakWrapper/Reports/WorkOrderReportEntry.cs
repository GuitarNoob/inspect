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
             string DaysOut,
             string AssemblyFK,
             string SalesOrder,
            string WorkOrderStatus
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
            this.AssemblyFK = AssemblyFK;
            this.SalesOrderFK = SalesOrder;
            this.WorkOrderStatus = WorkOrderStatus;
        }

        public void SetActiveEmployees(string activeEmployees)
        {
            this.ActiveEmployee = activeEmployees;
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

        private string _OpCompleteDate;
        public string OpCompleteDate
        {
            get { return _OpCompleteDate; }
            set
            {
                _OpCompleteDate = DateTime.Parse(value).ToLongDateString();
            }
        }

        private string _DueDate;
        public string DueDate
        {
            get { return _DueDate; }
            set
            {
                _DueDate = DateTime.Parse(value).ToLongDateString();
            }
        }

        public string DaysOut { get; set; }
        public string AssemblyFK { get; set; }
        public string SalesOrderFK { get; set; }
        public string WorkOrderStatus { get; set; }
        public string ActiveEmployee { get; set; }
        public string IsLate { get; set; }

        public string IsDueToday { get; set; }

        public string IsAlmostLate { get; set; }

        public bool IsInProgress()
        {
            return WorkOrderStatus == "1";
        }
    }
}
