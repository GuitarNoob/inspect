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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonCreateEdit_Click(object sender, RoutedEventArgs e)
        {
            if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
            {
                MessageBox.Show("No Work Order is currently selected.",
                    "No Work Order selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CreatePlan createPlan = null;

            if (App.Engine.InspectionPlanMgr.SelectedIP == null)
                createPlan = new CreatePlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder);
            else
                createPlan = new CreatePlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder, App.Engine.InspectionPlanMgr.SelectedIP);

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
                DataGridResults.ItemsSource = App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.ToList();
                return;
            }
            switch (type)
            {
                case "W.O. Number":
                    DataGridResults.ItemsSource = App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.Where(x => x.WorkOrderNumber.Contains(search)).ToList();
                    break;
                case "Part Number":
                    DataGridResults.ItemsSource = App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.Where(x => x.PartNumber.Contains(search)).ToList();
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
                    App.Engine.InspectionPlanMgr.LoadWorkOrder((WorkOrder)item);
                    ReloadUI();
                }
            }
        }

        void ReloadUI()
        {
            App.Engine.InspectionPlanMgr.ReloadInspectionPlan();
            FillWOTextBoxes();
            FillIPTextBoxes();
            EnableDisableButtons();
        }

        void EnableDisableButtons()
        {
            if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
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
            WorkOrder wo = App.Engine.InspectionPlanMgr.SelectedWorkOrder ?? new WorkOrder();
            WorkOrderInfo.FillTextBoxes(wo);
        }

        void FillIPTextBoxes()
        {
            InspectionPlan ip = App.Engine.InspectionPlanMgr.SelectedIP ?? new InspectionPlan();
            TxtBoxIPAcptDefect.Text = ip.AcceptableDefects.ToString();
            TxtBoxIPAql.Text = ip.AQLPercentage.ToString();
            TxtBoxIPId.Text = ip.InspectionPlanId.ToString();
            TxtBoxIPLvl.Text = ip.Level;
            TxtBoxIPSkipLot.Text = ip.SkipLot.ToString();
            TxtBoxIPType.Text = ip.Type;

            DataGridMeasurements.ItemsSource = null;
            if (ip.MeasurementCriteria != null)
                DataGridMeasurements.ItemsSource = ip.MeasurementCriteria.OrderBy(x => x.CharNumber);
            else
                DataGridMeasurements.ItemsSource = null;
        }

        private void ButtonCollectIP_Click(object sender, RoutedEventArgs e)
        {
            CheckInspectionPlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder, App.Engine.InspectionPlanMgr.SelectedIP);
            App.Engine.InspectionPlanMgr.ReloadInspectionPlan();
            CollectDataWindow win = new CollectDataWindow(App.Engine.InspectionPlanMgr.SelectedWorkOrder, App.Engine.InspectionPlanMgr.SelectedIP);
            win.ShowDialog();
        }

        void CheckInspectionPlan(WorkOrder wo, InspectionPlan iplan)
        {
            int sampleSize = 0;

            if (iplan.Type == "FAI")
                sampleSize = iplan.FAIQuantity;
            else
                sampleSize = iplan.SampleSize;

            if (sampleSize == 0)
            {
                if (MessageBox.Show("The sample size is 0! The Inspection Plan may have an error. Do you want to continue?", "Error",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                    return;
            }

            foreach (PartMeasurementSP sp in iplan.MeasurementCriteria)
            {
                if (sp.Measurements != null)
                {
                    if (sp.Measurements.Count != sampleSize && sp.Measurements.Count != 0)
                    {
                        if (MessageBox.Show("Error sample size does not match! The Inspection Plan has been mofied and the results no longer match!" +
                         " Would you like to attempt a merge? (Warning: a merge may result in a loss of saved data)", "Error Inspection Plan has been modified!",
                         MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            if (sp.Measurements.Count > sampleSize)
                            {
                                int numToRemove = sp.Measurements.Count - sampleSize;
                                RemoveMeasurementSP(sp, numToRemove);
                            }
                            else
                            {
                                int numToAdd = sampleSize - sp.Measurements.Count;
                                AddMeasurementForSP(sp, numToAdd);
                            }
                        }
                    }
                }

                if (sp.Measurements == null || sp.Measurements.Count == 0)
                {
                    AddMeasurementForSP(sp, sampleSize);
                }
            }

            App.Engine.Database.isiEngine.InspectionDb.SaveChanges();
        }

        void RemoveMeasurementSP(PartMeasurementSP sp, int measurementsToRemove)
        {
            List<PartMeasurementActual> measurements = new List<PartMeasurementActual>();
            for (int i = 0; i < measurementsToRemove; i++)
            {
                measurements.Add(sp.Measurements[((sp.Measurements.Count - 1) - i)]);
            }

            foreach (PartMeasurementActual measurement in measurements)
            {
                App.Engine.Database.isiEngine.InspectionDb.MeasurementActual.Remove(measurement);
            }
        }

        void AddMeasurementForSP(PartMeasurementSP sp, int measurementsToAdd)
        {
            for (int i = 0; i < measurementsToAdd; i++)
            {
                PartMeasurementActual measurement = new PartMeasurementActual();
                measurement.PartMeasurementActualId = Guid.NewGuid();
                measurement.PartMeasurementSPId = sp.PartMeasurementSPId;
                measurement.CompletedTime = new DateTime(1975, 1, 1);
                App.Engine.Database.isiEngine.InspectionDb.MeasurementActual.Add(measurement);
            }
        }
    }
}
