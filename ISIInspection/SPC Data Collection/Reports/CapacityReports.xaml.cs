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
        List<CapacityWorkOrder> capacityWorkOrders;
        CapacityCalculator capacityCalc = new CapacityCalculator();

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

            List<CapacityMachine> machinesList = new List<CapacityMachine>();
            machinesList.Add(new CapacityMachine(machine1Hours));
            machinesList.Add(new CapacityMachine(machine2Hours));
            machinesList.Add(new CapacityMachine(machine3Hours));

            lastQuery = report.GetQuery((decimal)1.5, WorkOrderReportSort.WorkOrderSort, WorkOrderReportFilter.Mill);
            capacityWorkOrders = capacityCalc.GetCapacityWorkOrderList(lastQuery);
            List<CapacityMachine> machines = capacityCalc.CalculateCapacity(capacityWorkOrders, ref machinesList);
            Machine1.ItemsSource = machines[0].GetWorkOrderList();
            Machine2.ItemsSource = machines[1].GetWorkOrderList();
            Machine3.ItemsSource = machines[2].GetWorkOrderList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RunQuery();
        }
    }
}
