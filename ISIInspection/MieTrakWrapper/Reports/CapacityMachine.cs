using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{
    public class CapacityMachine
    {
        public CapacityMachine(int hoursOnMachines = 8)
        {
            hoursInDay = hoursOnMachines;
        }
        
        int hoursInDay;

        List<CapacityWorkOrder> workOrders = new List<CapacityWorkOrder>();

        public List<CapacityWorkOrder> GetWorkOrderList()
        {
            return workOrders;
        }

        public void AddWorkOrder(CapacityWorkOrder workOrder)
        {
            workOrders.Add(workOrder);
            //force an update of the start end dates
            GetLatestStartDate();
        }

        public DateTime GetLatestStartDate()
        {
            DateTime returnStartDate = DateTime.Today;
            while ((returnStartDate.DayOfWeek == DayOfWeek.Saturday) || (returnStartDate.DayOfWeek == DayOfWeek.Sunday))
            {
                returnStartDate = returnStartDate.AddDays(1);
            }
            
            int minutesInDay = hoursInDay * 60;
            int minuteCounter = minutesInDay;

            foreach (CapacityWorkOrder workOrder in workOrders)
            {
                workOrder.AssignStartDate(returnStartDate);
                minuteCounter -= workOrder.LenthOfTimeToCompletion;
                if (minuteCounter < 0)
                {
                    while (minuteCounter < 0)
                    {
                        minuteCounter += minutesInDay;
                        returnStartDate = IncrementDueDate(returnStartDate);
                    }
                }
                workOrder.AssignEndDate(returnStartDate);
            }

            if (minuteCounter < minutesInDay)
            {
                returnStartDate = returnStartDate.AddMinutes(minuteCounter);
            }
            return returnStartDate;
        }

        DateTime IncrementDueDate(DateTime inDate, int daysToAdd = 1)
        {
            DateTime returnDay = inDate;
            for (int i = 0; i < daysToAdd; i++)
            {
                returnDay = returnDay.AddDays(1);
                while ((returnDay.DayOfWeek == DayOfWeek.Saturday) || (returnDay.DayOfWeek == DayOfWeek.Sunday))
                {
                    returnDay = returnDay.AddDays(1);
                }
            }
            return returnDay;
        }
    }
}
