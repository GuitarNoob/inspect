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
        public MainWindow()
        {
            InitializeComponent();
            App.Engine.UserChanged += App_UserChanged;
            App.Engine.InspectionPlanMgr.WorkOrderChanged += InspectionPlanMgr_WorkOrderChanged;

            MainGrid.DataContext = this;
            EnableDisableButtons();
            CheckUser();
        }

        void App_UserChanged(object sender, EventArgs e)
        {
            CheckUser();
        }

        void InspectionPlanMgr_WorkOrderChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void CheckUser()
        {
            
            if (App.Engine.CurrentUser == null)
            {
                LogonWindow logon = new LogonWindow();
                logon.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnWorkOrderSearch_Click(object sender, RoutedEventArgs e)
        {
            string type = ((ComboBoxType.SelectedItem ?? "") as ComboBoxItem).Content.ToString();
            string search = TextBoxSearchValue.Text;
            if (search == "")
            {
                DataGridResults.ItemsSource = App.Current.GetAllWorkOrders();
                return;
            }
            switch (type)
            {
                case "W.O. Number":
                    DataGridResults.ItemsSource = App.Current.SearchForWorkOrder(search);
                    break;
                case "Part Number":
                    DataGridResults.ItemsSource = App.Current.SearchForPartNumber(search);
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
                    App.Engine.InspectionPlanMgr.SetSelectedWorkOrder((WorkOrder)item);
                    ReloadUI();
                }
            }
        }

        public void ReloadUI()
        {
            App.Engine.InspectionPlanMgr.ReloadInspectionPlan();
            FillWOTextBoxes();
            FillIPTextBoxes();
            EnableDisableButtons();
            ReloadInspectionPlanList();
        }

        void ReloadInspectionPlanList()
        {
            WorkOrder wo = App.Engine.InspectionPlanMgr.SelectedWorkOrder ?? new WorkOrder();
            DataGridInspectionPlan.ItemsSource = App.Engine.InspectionPlanMgr.GetInspectionPlan(wo);
        }

        void EnableDisableButtons()
        {
            //if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
            //{
                //ButtonAddIP.IsEnabled = ButtonCollectIP.IsEnabled = false;
            //}
            //else
            //{
                //ButtonAddIP.IsEnabled = ButtonCollectIP.IsEnabled = true;
            //}
        }

        void FillWOTextBoxes()
        {
            WorkOrder wo = App.Engine.InspectionPlanMgr.SelectedWorkOrder ?? new WorkOrder();
            WorkOrderInfo.FillTextBoxes(wo);
        }

        void FillIPTextBoxes()
        {
            InspectionPlan ip = App.Engine.InspectionPlanMgr.SelectedIP ?? new InspectionPlan();
            TxtBoxIPAcptDefect.Text = ip.AcceptableDefects.ToString();
            TxtBoxIPAql.Text = ip.AQLPercentage.ToString();
            TxtBoxIPId.Text = ip.InspectionPlanKey.ToString();
            TxtBoxIPLvl.Text = ip.Level;
            TxtBoxIPQty.Text = ip.FAIQuantity.ToString();
            TxtBoxIPType.Text = ip.Type;

            DataGridMeasurements.ItemsSource = null;
            if (ip.MeasurementCriteria != null)
                DataGridMeasurements.ItemsSource = ip.MeasurementCriteria.OrderBy(x => x.CharNumber);
            else
                DataGridMeasurements.ItemsSource = null;
        }

        private void ButtonCollectIP_Click(object sender, RoutedEventArgs e)
        {
            App.Current.CollectDataFromCurrentIP();
        }
        
        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Merlin_ISI_Inspection_Data_Collector_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButton.YesNo, MessageBoxImage.Information)
                != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void DataGridInspectionPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = DataGridInspectionPlan.SelectedItem;
            if (item != null)
            {
                if (item is InspectionPlan)
                {
                    App.Engine.InspectionPlanMgr.LoadInspectionPlan((InspectionPlan)item);                    
                }
            }
            else
                App.Engine.InspectionPlanMgr.LoadInspectionPlan(null);

            ReloadUI();
        }
    }
}
