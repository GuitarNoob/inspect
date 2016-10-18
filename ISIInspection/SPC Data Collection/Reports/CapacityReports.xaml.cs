using MieTrakWrapper.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SPC_Data_Collection.Reports
{
    /// <summary>
    /// Interaction logic for CapacityReports.xaml
    /// </summary>
    public partial class CapacityReports : Window
    {
        MieTrakWrapper.Reports.WorkOrderReport report;
        List<WorkOrderReportEntry> lastQuery;
        List<WorkOrderReportEntry> latheLastQuery;

        CapacityWorkOrder simulatedWO = null;
        List<CapacityWorkOrder> capacityWorkOrders;
        List<CapacityWorkOrder> latheCapacityWorkOrders;
        CapacityCalculator capacityCalc = new CapacityCalculator();
        CapacityCalculator latheCapacityCalc = new CapacityCalculator();

        public CapacityReports()
        {
            InitializeComponent();

            try
            {
                report = new MieTrakWrapper.Reports.WorkOrderReport(true);
                RunQuery();
                //WorkOrderControl.ItemsSource = lastQuery;
                //CreateTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void RunQuery()
        {
            int machine1Hours = 8;
            int machine2Hours = 8;
            int machine3Hours = 8;
            int machine4Hours = 8;
            try
            {
                machine1Hours = Convert.ToInt32(Machine1Hours.Text);
            }
            catch
            {
                MessageBox.Show("Machine 1 hours is not a number.");
            }

            try
            {
                machine2Hours = Convert.ToInt32(Machine2Hours.Text);
            }
            catch
            {
                MessageBox.Show("Machine 2 hours is not a number.");
            }

            try
            {
                machine3Hours = Convert.ToInt32(Machine3Hours.Text);
            }
            catch
            {
                MessageBox.Show("Machine 3 hours is not a number.");
            }

            try
            {
                machine4Hours = Convert.ToInt32(Machine4Hours.Text);
            }
            catch
            {
                MessageBox.Show("Machine 4 hours is not a number.");
            }

            decimal decResult = (decimal)1.5;
            if (!decimal.TryParse(TextBoxMultiplier.Text, out decResult))
            {
                MessageBox.Show("Unable to run query. The Multiplier is not a valid number.",
                    "Invalid Multiplier",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                TextBoxMultiplier.Focus();
            }

            List<CapacityMachine> machinesList = new List<CapacityMachine>();
            machinesList.Add(new CapacityMachine(machine1Hours));
            machinesList.Add(new CapacityMachine(machine2Hours));
            machinesList.Add(new CapacityMachine(machine3Hours));

            lastQuery = report.GetQuery(decResult, WorkOrderReportSort.WorkOrderSort, WorkOrderReportFilter.Mill);
            capacityWorkOrders = capacityCalc.GetCapacityWorkOrderList(lastQuery, decResult);
            if (simulatedWO != null)
            {
                capacityWorkOrders.Add(simulatedWO);
                capacityWorkOrders = capacityWorkOrders.OrderBy(x => x.DueDate).ToList();
            }

            List<CapacityMachine> machines = capacityCalc.CalculateCapacity(capacityWorkOrders, ref machinesList);
            Machine1.ItemsSource = machines[0].GetWorkOrderList();
            Machine2.ItemsSource = machines[1].GetWorkOrderList();
            Machine3.ItemsSource = machines[2].GetWorkOrderList();

            List<CapacityMachine> latheMachinesList = new List<CapacityMachine>();
            latheMachinesList.Add(new CapacityMachine(machine4Hours));
            latheLastQuery = report.GetQuery(decResult, WorkOrderReportSort.WorkOrderSort, WorkOrderReportFilter.Lathe);
            latheCapacityWorkOrders = capacityCalc.GetCapacityWorkOrderList(latheLastQuery, decResult);
            List<CapacityMachine> latheMachines = capacityCalc.CalculateCapacity(latheCapacityWorkOrders, ref latheMachinesList);
            Machine4.ItemsSource = latheMachines[0].GetWorkOrderList();

            CalcUtilization(machine1Hours, machine2Hours, machine3Hours, machines);
        }

        void CalcUtilization(int mHours1, int mHours2, int mHours3, List<CapacityMachine> machines)
        {
            int daysInWeek = 5;
            int weeksInMonth = 4;
            decimal hoursInMonth = (mHours1 + mHours2 + mHours3) * daysInWeek * weeksInMonth;
            decimal hoursDoneInMonth = 0;

            int daysOutForUtilCalc = 28;
            DateTime today = DateTime.Now;
            DateTime cutOffDate = today.AddDays(daysOutForUtilCalc);
            //get the actual run time
            foreach (CapacityMachine machine in machines)
            {
                List<CapacityWorkOrder> woList = machine.GetWorkOrderList();
                foreach (CapacityWorkOrder wo in woList)
                {
                    if (wo.EndWorkDate <= cutOffDate)
                    {
                        hoursDoneInMonth += wo.GetHoursOfWork();
                    }
                }
            }

            decimal utilization = (hoursDoneInMonth / hoursInMonth) * 100;
            TextBoxUtilization.Text = Convert.ToInt16(utilization).ToString() + "%";
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RunQuery();
        }

        private void SimulateWO_Click(object sender, RoutedEventArgs e)
        {
            SimulateWODialog diag = new SimulateWODialog();
            diag.Owner = this;
            if (diag.ShowDialog() == true)
            {
                simulatedWO = diag.capacity;
                RunQuery();
            }
        }
    }
}
