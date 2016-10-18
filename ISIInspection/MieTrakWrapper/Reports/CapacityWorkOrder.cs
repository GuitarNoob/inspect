using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{
    public class CapacityWorkOrder
    {

        public void AddWorkOrderInformation(WorkOrderReportEntry entry, decimal constMultiplier)
        {
            CheckInformation(entry);

            int hoursInDay = 8;
            int minutesInDay = hoursInDay * 60;

            decimal minPerPart = 0;
            decimal.TryParse(entry.RunTime, out minPerPart);
            decimal qtyRqd = 0;
            decimal.TryParse(entry.QtyToFab, out qtyRqd);
            decimal setupTime = 0;
            decimal.TryParse(entry.SetupTime, out setupTime);
            decimal daysOut = 0;
            decimal.TryParse(entry.DaysOut, out daysOut);

            if (daysOut > 0)
            {
                LenthOfTimeToCompletion += (minutesInDay * Convert.ToInt32(daysOut));
            }
            else
            {
                decimal totalTimeRqd = (((minPerPart * qtyRqd) + setupTime) * constMultiplier);
                int totalTimeInt = Convert.ToInt32(totalTimeRqd);
                LenthOfTimeToCompletion += totalTimeInt;
            }
        }

        void CheckInformation(WorkOrderReportEntry entry)
        {
            if (hasInfoBeenSet)
            {
                if (this.WorkOrder != entry.WorkOrder ||
                    this.DueDate != entry.DueDate_DateTime ||
                    this.PartNumber != entry.PartNumber ||
                    this.Description != entry.Description)
                {
                    throw new Exception("Mismatched work order information during capacity calc");
                }
            }

            this.WorkOrder = entry.WorkOrder;
            this.DueDate = entry.DueDate_DateTime;
            this.PartNumber = entry.PartNumber;
            this.Description = entry.Description;

            decimal qtyRqd = 0;
            decimal.TryParse(entry.QtyToFab, out qtyRqd);
            Int32 qtyRqdInt = Convert.ToInt32(qtyRqd);
            this.QuantityToDo += qtyRqdInt;

            decimal qtyComplete = 0;
            decimal.TryParse(entry.QtyComplete, out qtyComplete);
            Int32 qtyCompleteInt = Convert.ToInt32(qtyComplete);
            this.QuantityCompleted += qtyCompleteInt;

            hasInfoBeenSet = true;
        }

        public void AssignStartDate(DateTime startDate)
        {
            this.StartWorkDate = startDate;
        }

        public void AssignEndDate(DateTime endDate)
        {
            this.EndWorkDate = endDate;
            TimeSpan daysEarlyLate = DueDate - EndWorkDate;
            DaysLateOrAhead = daysEarlyLate.Days;
        }

        private string DateFormat = "ddd, MMM dd, yy";

        private bool hasInfoBeenSet = false;

        public int LenthOfTimeToCompletion = 0;

        public decimal GetHoursOfWork()
        {
            return ((decimal)LenthOfTimeToCompletion) / ((decimal)60);
        }

        public string HoursOfWork
        {
            get
            {
                //minutes to hours
                decimal hours = GetHoursOfWork();
                return hours.ToString("0.0");
            }
            set
            { }
        }

        public DateTime StartWorkDate { get; set; }
        public string StartWorkDateString
        {
            get
            {
                return StartWorkDate.ToString(DateFormat);
            }
            set
            { }
        }

        public DateTime EndWorkDate { get; set; }
        public string EndWorkDateString

        {
            get
            {
                return EndWorkDate.ToString(DateFormat);
            }
            set
            { }
        }

        public DateTime DueDate { get; set; }
        public string DueDateString

        {
            get
            {
                return DueDate.ToString(DateFormat);
            }
            set
            { }
        }

        public int QuantityToDo { get; set; }
        public int QuantityCompleted { get; set; }
        public int DaysLateOrAhead { get; set; }
        public string WorkOrder { get; set; }

        public string PartNumber { get; set; }
        public string Description { get; set; }
    }
}
