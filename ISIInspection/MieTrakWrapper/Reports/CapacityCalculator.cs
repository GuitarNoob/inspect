using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{
    public class CapacityCalculator
    {
        public List<CapacityWorkOrder> GetCapacityWorkOrderList(List<WorkOrderReportEntry> workOrderEntries)
        {
            List<CapacityWorkOrder> capacityWorkOrders = new List<CapacityWorkOrder>();
            string lastWorkOrder = "";
            List<WorkOrderReportEntry> sortedList = workOrderEntries.OrderBy(x => x.WorkOrder).ToList();
            CapacityWorkOrder lastCapactityWorkOrder = null;
            foreach (WorkOrderReportEntry entry in sortedList)
            {
                if (entry.IsAssemblyActive())
                {
                    if (entry.WorkOrder != lastWorkOrder)
                    {
                        lastWorkOrder = entry.WorkOrder;
                        if (lastCapactityWorkOrder != null)
                        {
                            capacityWorkOrders.Add(lastCapactityWorkOrder);
                        }
                        //create a new capactity work order
                        lastCapactityWorkOrder = new CapacityWorkOrder();
                    }

                    lastCapactityWorkOrder.AddWorkOrderInformation(entry);
                }
            }

            return capacityWorkOrders.OrderBy(x => x.DueDate).ToList();
        }

        public List<CapacityMachine> CalculateCapacity(List<CapacityWorkOrder> workOrderEntries, ref List<CapacityMachine> machineLists)
        {
            foreach (CapacityWorkOrder entry in workOrderEntries)
            {
                AddCapacityWorkOrderToNextAvailableMachine(ref machineLists, entry);
            }

            return machineLists;
        }

        void AddCapacityWorkOrderToNextAvailableMachine(ref List<CapacityMachine> machines, CapacityWorkOrder entryToAdd)
        {
            CapacityMachine machineToAddTo = machines[0];
            foreach (CapacityMachine macineList in machines)
            {
                if (machineToAddTo.GetLatestStartDate() > macineList.GetLatestStartDate())
                {
                    machineToAddTo = macineList;
                }
            }

            machineToAddTo.AddWorkOrder(entryToAdd);
        }
    }
}
