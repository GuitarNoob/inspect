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
    /// Interaction logic for WorkOrderReport.xaml
    /// </summary>
    public partial class WorkOrderReport : Window
    {
        MieTrakWrapper.Reports.WorkOrderReport report;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        int timeUntilRefreshMax = 60;
        int timeUntilRefreshCounter = 60;

        public WorkOrderReport(string query)
        {
            InitializeComponent();

            try
            {
                report = new MieTrakWrapper.Reports.WorkOrderReport(query);
                WorkOrderControl.ItemsSource = report.GetQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }

            CreateTimer();
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
                timeUntilRefreshCounter = timeUntilRefreshMax;
                WorkOrderControl.ItemsSource = report.GetQuery();
            }
            TextBoxCounter.Text = timeUntilRefreshCounter.ToString();            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (dispatcherTimer.IsEnabled)
                dispatcherTimer.Stop();
        }
    }
}
