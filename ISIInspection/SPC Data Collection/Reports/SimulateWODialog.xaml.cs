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
    /// Interaction logic for SimulateWODialog.xaml
    /// </summary>
    public partial class SimulateWODialog : Window
    {
        public CapacityWorkOrder capacity = null;
        public SimulateWODialog()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool errorOcc = false;
            try
            {
                if (WO_DatePick.SelectedDate == null)
                {
                    throw new Exception();
                }
                int work = Convert.ToInt32(WO_Work.Text) * 60;
                capacity = new CapacityWorkOrder();
                capacity.LenthOfTimeToCompletion = work;
                capacity.DueDate = WO_DatePick.SelectedDate ?? DateTime.Now;
                capacity.WorkOrder = "SIMULATED";
                capacity.PartNumber = "SIMULATED";
                capacity.Description = "SIMULATED";
                capacity.QuantityToDo = 1;
            }
            catch
            {
                errorOcc = true;
            }

            if (errorOcc)
            {
                MessageBox.Show("Incorrect data cannot parse!");
            }
            else
            {
                this.DialogResult = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;            
        }
    }
}
