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
//            TxtBoxIPFrequency.Text = ip.Frequency.ToString();
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
//            ip.Frequency = Convert.ToInt32(TxtBoxIPFrequency.Text);
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
        private void WorkOrderInfo_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TxtBoxIPType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var bc = new BrushConverter();
            if (TxtBoxIPType.SelectedIndex == 0) /// Auto
            {
                BtnIPCalculate.Visibility = Visibility.Visible;
                ComboBoxAQL.SelectedIndex = 10;
                ComboBoxIpLvl.SelectedIndex = 1;
                ComboBoxAQL.IsEnabled = true;
                ComboBoxIpLvl.IsEnabled = true;
                LabelSampleSize.Opacity = 1.0;
                LabelFAI.Opacity = 0.25;
                LabelAQL.Opacity = 1.0;
                LabelLevel.Opacity = 1.0;
                LabelCodeLetter.Opacity = 1.0;
                LabelAccDefects.Opacity = 1.0;
                LabelLotSize.Opacity = 1.0;
                TxtBoxIPCodeLetter.IsEnabled = true;
                TxtBoxIPAcceptableDefects.IsEnabled = true;
                //TxtBoxIPRejectNumber.IsEnabled = true;
                TxtBoxIPAcceptableDefects.Text = "";
                TxtBoxIPSampleSize.IsEnabled = true;
                TxtBoxIPSampleSize.IsReadOnly = true;
                TxtBoxIPFAIQty.IsEnabled = false;
                TxtBoxIPSampleSize.Text = "";
                TxtBoxIPSampleSize.Background = (Brush)bc.ConvertFrom("#FFFFFFBE");

            }
            if (TxtBoxIPType.SelectedIndex == 1) /// Manual
            {
                BtnIPCalculate.Visibility = Visibility.Hidden;
                ComboBoxAQL.SelectedIndex = -1;
                ComboBoxIpLvl.SelectedIndex = -1;
                ComboBoxAQL.IsEnabled = false;
                ComboBoxIpLvl.IsEnabled = false;
                LabelAQL.Opacity = 0.25;
                LabelLevel.Opacity = 0.25;
                LabelCodeLetter.Opacity = 0.25;
                LabelFAI.Opacity = 0.25;
                LabelAccDefects.Opacity = 0.25;
                LabelSampleSize.Opacity = 1.0;
                LabelLotSize.Opacity = 1.0;
                TxtBoxIPLotSize.IsEnabled = true;
                TxtBoxIPFAIQty.IsEnabled = false;
                TxtBoxIPCodeLetter.IsEnabled = false;
                TxtBoxIPCodeLetter.Text = "";
                TxtBoxIPAcceptableDefects.IsEnabled = false;
                TxtBoxIPAcceptableDefects.Text = "";
                TxtBoxIPSampleSize.Text = "";
                TxtBoxIPSampleSize.IsReadOnly = false;
                TxtBoxIPSampleSize.Background = Brushes.White;
            }
            if (TxtBoxIPType.SelectedIndex == 2) /// First Article
            {
                BtnIPCalculate.Visibility = Visibility.Hidden;
                ComboBoxAQL.SelectedIndex = -1;
                ComboBoxIpLvl.SelectedIndex = -1;
                ComboBoxAQL.IsEnabled = false;
                ComboBoxIpLvl.IsEnabled = false;
                LabelSampleSize.Opacity = 0.25;
                LabelFAI.Opacity = 1.0;
                LabelAQL.Opacity = 0.25;
                LabelLevel.Opacity = 0.25;
                LabelCodeLetter.Opacity = 0.25;
                LabelAccDefects.Opacity = 0.25;
                LabelLotSize.Opacity = 1.0;
                TxtBoxIPLotSize.IsEnabled = true;
                TxtBoxIPAcceptableDefects.IsEnabled = false;
                TxtBoxIPFAIQty.IsEnabled = true;
                TxtBoxIPCodeLetter.IsEnabled = false;
                TxtBoxIPSampleSize.IsEnabled = false;
                TxtBoxIPSampleSize.Background = (Brush)bc.ConvertFrom("#FFFFFFBE");
            }

        }

        private void ComboBoxAQL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BtnIPCalculate_Click_1(object sender, RoutedEventArgs e)
        {
            string AQLCodeLetter ="";
            string AQLAccept;
            string AQLReject;
            int AQLSampleSize;
            string AQLLevelValue = ((ComboBoxIpLvl.SelectedItem ?? "") as ComboBoxItem).Content.ToString();
            int LotSizeInt = Convert.ToInt32(m_workOrder.QuantityRequired);
            //MessageBox.Show(AQLLevelValue.ToString());
            //MessageBox.Show(m_workOrder.QuantityRequired.ToString());
            string AQLValue = ((ComboBoxAQL.SelectedItem ?? "") as ComboBoxItem).Content.ToString();
            //MessageBox.Show(AQLValue.ToString());
            //
            // Start Letter decoder
            //
            if (LotSizeInt >= 2 && LotSizeInt <= 8)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "A";
                }
            }
            if (LotSizeInt >= 9 && LotSizeInt <= 15)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "A";
                }
            }
            if (LotSizeInt >= 16 && LotSizeInt <= 25)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "D";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "B";
                }
            }
            if (LotSizeInt >= 26 && LotSizeInt <= 50)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "D";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "E";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "A";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "C";
                }
            }
            if (LotSizeInt >= 51 && LotSizeInt <= 90)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "E";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "F";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "C";
                }
            }
            if (LotSizeInt >= 91 && LotSizeInt <= 150)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "D";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "F";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "G";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "D";
                }
            }
            if (LotSizeInt >= 151 && LotSizeInt <= 280)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "E";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "G";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "H";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "D";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "E";
                }
            }
            if (LotSizeInt >= 281 && LotSizeInt <= 500)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "F";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "H";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "J";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "B";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "D";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "E";
                }
            }
            if (LotSizeInt >= 501 && LotSizeInt <= 1200)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "G";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "J";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "K";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "E";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "F";
                }
            }
            if (LotSizeInt >= 1201 && LotSizeInt <= 3200)
            {
                if (AQLLevelValue == "I")
                {
                    AQLCodeLetter = "H";
                }
                if (AQLLevelValue == "II")
                {
                    AQLCodeLetter = "K";
                }
                if (AQLLevelValue == "III")
                {
                    AQLCodeLetter = "L";
                }
                if (AQLLevelValue == "S-1")
                {
                    AQLCodeLetter = "C";
                }
                if (AQLLevelValue == "S-2")
                {
                    AQLCodeLetter = "D";
                }
                if (AQLLevelValue == "S-3")
                {
                    AQLCodeLetter = "E";
                }
                if (AQLLevelValue == "S-4")
                {
                    AQLCodeLetter = "G";
                }
            }
            //
            // A
            //
            if (AQLCodeLetter == "A")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 2;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "B")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 3;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "C" && Convert.ToDouble(AQLValue) < 6.50)
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 5;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "C" && Convert.ToDouble(AQLValue) >= 6.50)
            {
                AQLAccept = "1";
                AQLReject = "2";
                AQLSampleSize = 5;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "D")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 8;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "E")
            {
                AQLAccept = "0";
                AQLReject = "13";
                AQLSampleSize = 5;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "F")
            {
                AQLAccept = "0";
                AQLReject = "20";
                AQLSampleSize = 5;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "G")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 32;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "H")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 50;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "J")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 80;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "K")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 125;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "L")
            {
                AQLAccept = "0";
                AQLReject = "200";
                AQLSampleSize = 5;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "M")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 315;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "N")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 500;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "P")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 800;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "Q")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 1250;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
            if (AQLCodeLetter == "R")
            {
                AQLAccept = "0";
                AQLReject = "1";
                AQLSampleSize = 2000;
                TxtBoxIPSampleSize.Text = AQLSampleSize.ToString();
                TxtBoxIPAcceptableDefects.Text = AQLAccept;
                //TxtBoxIPRejectNumber.Text = AQLReject;
                TxtBoxIPCodeLetter.Text = AQLCodeLetter;
            }
        }
    }
}
