using ISIInspection.Models;
using MieTrakWrapper.MieTrak;
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

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public WorkOrder selectedWO { get; set; }
        public InspectionPlan selectedInspectionPlan { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.DataContext = this;
            EnableDisableButtons();          
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonCreateEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedWO == null)
            {
                MessageBox.Show("No Work Order is currently selected.",
                    "No Work Order selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CreatePlan createPlan = null;
            
            if (selectedInspectionPlan == null)            
                createPlan = new CreatePlan(selectedWO);
            else
                createPlan = new CreatePlan(selectedWO, selectedInspectionPlan);
            
            createPlan.Owner = this;
            createPlan.ShowDialog();
            ReloadUI();
        }
        
        private void BtnWorkOrderSearch_Click(object sender, RoutedEventArgs e)
        {
            string type = ((ComboBoxType.SelectedItem ?? "") as ComboBoxItem).Content.ToString();
            string search = TextBoxSearchValue.Text;
            if (search == "")
            {
                DataGridResults.ItemsSource = App.mietrakConn.mietrakDb.WorkOrders.ToList();
                return;
            }
            switch (type)
            {
                case "W.O. Number":
                    DataGridResults.ItemsSource = App.mietrakConn.mietrakDb.WorkOrders.Where(x => x.WorkOrderNumber.Contains(search)).ToList();
                    break;
                case "Part Number":
                    DataGridResults.ItemsSource = App.mietrakConn.mietrakDb.WorkOrders.Where(x => x.PartNumber.Contains(search)).ToList();
                    break;
            }
        }

        public void DataGridResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = DataGridResults.SelectedItem;
            if (item != null)
            {
                if (item is WorkOrder)
                {
                    selectedWO = (WorkOrder)item;
                    ReloadUI();
                }
            }
        }

        void ReloadUI()
        {
            GetInspectionPlan();
            FillWOTextBoxes();
            FillIPTextBoxes();
            EnableDisableButtons();
        }

        void GetInspectionPlan()
        {
            //find the inspection plans with this router
            List<InspectionPlan> iPlans = App.isiEngine.InspectionDb.InspectionPlans.Where(x=>x.RouterFK == selectedWO.RouterFK).ToList();
            if (iPlans.Count > 0)
                selectedInspectionPlan = iPlans[0];
            else
                selectedInspectionPlan = null;
        }

        void EnableDisableButtons()
        {
            if (selectedWO == null)
            {
                ButtonAddIP.IsEnabled = ButtonCollectIP.IsEnabled = false;
            }
            else
            {
                ButtonAddIP.IsEnabled = ButtonCollectIP.IsEnabled = true;
            }
        }

        void FillWOTextBoxes()
        {            
            WorkOrder wo = selectedWO ?? new WorkOrder();
            WorkOrderInfo.FillTextBoxes(wo);
        }

        void FillIPTextBoxes()
        {
            InspectionPlan ip = selectedInspectionPlan ?? new InspectionPlan();
            try
            {
                TxtBoxIPAcptDefect.Text = ip.AcceptableDefects.ToString();
                TxtBoxIPAql.Text = ip.AQLPercentage.ToString();
                TxtBoxIPFreq.Text = ip.Frequency.ToString();
                TxtBoxIPId.Text = ip.InspectionPlanId.ToString();
                TxtBoxIPLvl.Text = ip.Level.ToString();
                TxtBoxIPSkipLot.Text = ip.SkipLot.ToString();
                TxtBoxIPType.Text = ip.Type;
            }
            catch 
            {

            }
            DataGridMeasurements.ItemsSource = null;
            DataGridMeasurements.ItemsSource = ip.MeasurementCriteria;
        }        
    }
}
