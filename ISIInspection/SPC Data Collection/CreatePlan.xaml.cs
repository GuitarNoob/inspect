using ISIInspection.Models;
using MieTrakWrapper.MieTrak;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CreatePlan.xaml
    /// </summary>
    public partial class CreatePlan : Window
    {
        bool isEdit = false;
        WorkOrder m_workOrder { get; set; }
        InspectionPlan m_inspectionPlan { get; set; }
        ObservableCollection<PartMeasurementSP> m_measurementCriteria { get; set; }

        public CreatePlan(WorkOrder workOrder)
        {
            InitializeComponent();
            MainGrid.DataContext = this;
            m_workOrder = workOrder;
            m_inspectionPlan = new InspectionPlan();
            m_inspectionPlan.InspectionPlanId = Guid.NewGuid();
            m_inspectionPlan.RouterFK = m_workOrder.RouterFK ?? -1;
        }

        public CreatePlan(WorkOrder workOrder, InspectionPlan inspectionPlan)
        {
            isEdit = true;
            InitializeComponent();
            MainGrid.DataContext = this;
            m_workOrder = workOrder;
            m_inspectionPlan = inspectionPlan;
        }

        void LoadInspectionPlanInfo()
        {
            InspectionPlan ip = m_inspectionPlan;
            TxtBoxIPID.Text = ip.InspectionPlanId.ToString();
            TxtBoxIPType.SelectedItem = ip.Type;
            TxtBoxIPLotSize.Text = m_workOrder.QuantityRequired.ToString();
            TxtBoxIPFrequency.Text = ip.Frequency.ToString();
            ComboBoxAQL.SelectedItem = ip.AQLPercentage.ToString();
            ComboBoxIpLvl.SelectedItem = ip.Level;
            TxtBoxIPSkipLot.Text = ip.SkipLot.ToString();
            TxtBoxIPAcceptableDefects.Text = ip.AcceptableDefects.ToString();
        }

        InspectionPlan GetInspectionPlan()
        {
            InspectionPlan ip = new InspectionPlan();

            ip.RouterFK = m_inspectionPlan.RouterFK;
            ip.InspectionPlanId = m_inspectionPlan.InspectionPlanId;

            ip.Type = TxtBoxIPType.Text;
            ip.Frequency = Convert.ToInt32(TxtBoxIPFrequency.Text);
            if (ComboBoxAQL.Text == "")
                ip.AQLPercentage = 0;
            else
                ip.AQLPercentage = Convert.ToDecimal(ComboBoxAQL.Text);

            ip.Level = ComboBoxIpLvl.Text;
            ip.SkipLot = Convert.ToInt32(TxtBoxIPSkipLot.Text);
            ip.AcceptableDefects = Convert.ToInt32(TxtBoxIPAcceptableDefects.Text);

            return ip;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshIPFields(DataGridResults.SelectedItem as PartMeasurementSP);
        }

        void RefreshIPFields(PartMeasurementSP measurement)
        {
            if (measurement == null)
            {
                TxtBoxDimCharNum.Text = "";
                TxtBoxDimRefLoc.Text = "";
                TxtBoxDimReq.Text = "";
                TxtBoxDimUpperLimit.Text = "";
                TxtBoxDimLowerLimit.Text = "";
                ComboBoxUofM.SelectedIndex = 0;
                ComboBoxCharDesig.SelectedIndex = 0;
                ComboBoxInspectionDevice.SelectedIndex = 0;
            }
            else
            {
                TxtBoxDimCharNum.Text = measurement.CharNumber;
                TxtBoxDimRefLoc.Text = measurement.RefLocation;
                TxtBoxDimReq.Text = measurement.Requirement;
                TxtBoxDimUpperLimit.Text = measurement.UpperLimit.ToString();
                TxtBoxDimLowerLimit.Text = measurement.LowerLimit.ToString();

                ComboBoxUofM.SelectedItem = measurement.Units;
                ComboBoxCharDesig.SelectedItem = measurement.CharacteristicDesignator;
                ComboBoxInspectionDevice.SelectedItem = measurement.InspectionDevice;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            InspectionPlan ip = GetInspectionPlan();

            var ipOriginal = App.isiEngine.InspectionDb.InspectionPlans.Find(ip.InspectionPlanId);
            if (ipOriginal != null)
                App.isiEngine.InspectionDb.Entry(ipOriginal).CurrentValues.SetValues(ip);
            else
                App.isiEngine.InspectionDb.InspectionPlans.Add(ip);

            foreach (PartMeasurementSP newSetpoint in m_measurementCriteria)
            {
                var spOriginal = App.isiEngine.InspectionDb.MeasurementSetpoints.Find(newSetpoint.PartMeasurementSPId);
                if (spOriginal != null)
                    App.isiEngine.InspectionDb.Entry(spOriginal).CurrentValues.SetValues(newSetpoint);
                else
                    App.isiEngine.InspectionDb.MeasurementSetpoints.Add(newSetpoint);
            }

            App.isiEngine.InspectionDb.SaveChanges();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_measurementCriteria = new ObservableCollection<PartMeasurementSP>();
            LoadInspectionPlanInfo();
            WorkOrderInfo.FillTextBoxes(m_workOrder);
            if (m_inspectionPlan.MeasurementCriteria != null)
                m_inspectionPlan.MeasurementCriteria.ForEach(x => m_measurementCriteria.Add(x));

            DataGridResults.ItemsSource = m_measurementCriteria;
        }

        private void ButtonAddMeasurement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PartMeasurementSP measurement = new PartMeasurementSP();

                measurement.PartMeasurementSPId = Guid.NewGuid();
                measurement.CharNumber = TxtBoxDimCharNum.Text;
                measurement.RefLocation = TxtBoxDimRefLoc.Text;
                measurement.Requirement = TxtBoxDimReq.Text;
                measurement.Units = ComboBoxUofM.Text;
                measurement.UpperLimit = Convert.ToDecimal(TxtBoxDimUpperLimit.Text);
                measurement.LowerLimit = Convert.ToDecimal(TxtBoxDimLowerLimit.Text);
                measurement.CharacteristicDesignator = ComboBoxCharDesig.Text;
                measurement.InspectionDevice = ComboBoxInspectionDevice.Text;

                measurement.InspectionPlanId = m_inspectionPlan.InspectionPlanId;

                m_measurementCriteria.Add(measurement);

                DataGridResults.ItemsSource = m_measurementCriteria;
                RefreshIPFields(null);
            }
            catch
            {
                ShowErrorMessage();
            }
        }

        private void ButtonSaveMeasurement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PartMeasurementSP measurement = DataGridResults.SelectedItem as PartMeasurementSP;

                measurement.CharNumber = TxtBoxDimCharNum.Text;
                measurement.RefLocation = TxtBoxDimRefLoc.Text;
                measurement.Requirement = TxtBoxDimReq.Text;
                measurement.Units = ComboBoxUofM.Text;
                measurement.UpperLimit = Convert.ToDecimal(TxtBoxDimUpperLimit.Text);
                measurement.LowerLimit = Convert.ToDecimal(TxtBoxDimLowerLimit.Text);
                measurement.CharacteristicDesignator = ComboBoxCharDesig.Text;
                measurement.InspectionDevice = ComboBoxInspectionDevice.Text;

                measurement.InspectionPlanId = m_inspectionPlan.InspectionPlanId;

                DataGridResults.ItemsSource = null;
                DataGridResults.ItemsSource = m_measurementCriteria;
            }
            catch
            {
                ShowErrorMessage();   
            }
        }

        void ShowErrorMessage()
        {
            MessageBox.Show("Unable to save the measurement criteria.",
                               "Error saving measurement criteria!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
