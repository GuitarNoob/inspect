using MieTrakWrapper.Reports;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for WorkOrderReport.xaml
    /// </summary>
    public partial class WorkOrderReport : Window
    {
        MieTrakWrapper.Reports.WorkOrderReport report;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        int timeUntilRefreshMax = 60;
        int timeUntilRefreshCounter = 60;
        List<WorkOrderReportEntry> lastQuery;

        public WorkOrderReport(string query)
        {
            InitializeComponent();

            try
            {
                report = new MieTrakWrapper.Reports.WorkOrderReport(query);
                lastQuery = report.GetQuery((decimal)1.5);
                WorkOrderControl.ItemsSource = lastQuery;
                CreateTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }
        }

        private void CreateTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timeUntilRefreshCounter--;
            if (timeUntilRefreshCounter < 0)
            {
                Refresh();
            }
            TextBoxCounter.Text = timeUntilRefreshCounter.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (dispatcherTimer != null)
            {
                if (dispatcherTimer.IsEnabled)
                    dispatcherTimer.Stop();
            }
        }

        void Refresh()
        {
            timeUntilRefreshCounter = timeUntilRefreshMax;
            decimal decResult;
            if (decimal.TryParse(TextBoxMultiplier.Text, out decResult))
            {
                lastQuery = report.GetQuery(decResult);
                WorkOrderControl.ItemsSource = lastQuery;
            }
            else
            {
                MessageBox.Show("Unable to run query. The Multiplier is not a valid number.",
                    "Invalid Multiplier",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                TextBoxMultiplier.Focus();
            }
        }

        private void MandatoryRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void TextBoxMultiplier_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal decResult;
            if (decimal.TryParse(TextBoxMultiplier.Text, out decResult))
            {
                TextBoxMultiplier.BorderBrush = Brushes.Green;
            }
            else
            {
                TextBoxMultiplier.BorderBrush = Brushes.Red;
            }
        }

        private void ExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog()
                {
                    Filter = "CSV Files(*.csv)|*.csv|All(*.*)|*"
                };

                if (dialog.ShowDialog() == true)
                {
                    using (StreamWriter fw = new StreamWriter(dialog.FileName, false))
                    {
                        fw.WriteLine("Sales Order,Work Order,Customer,Qty To Fab,Part Number,Description,Operation,Work Center,Finish,Setup Time,Run Time,Op Complete Date,Due Date,Current Employee");
                        foreach (WorkOrderReportEntry entry in lastQuery)
                        {
                            string outputLine = "";
                            outputLine += "\"" + entry.SalesOrderFK.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.WorkOrder.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.Customer.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.QtyToFab.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.PartNumber.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.Description.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.Operation.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.WorkCenter.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.Finish.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.SetupTime.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.RunTime.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.OpCompleteDate.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.DueDate.Replace("\"", "\"\"") + "\",";
                            outputLine += "\"" + entry.ActiveEmployee + "\"";
                            fw.WriteLine(outputLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
