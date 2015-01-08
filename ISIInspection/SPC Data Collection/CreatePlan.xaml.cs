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
        bool isLoaded = false;
        bool textChanged = false;
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
            TxtBoxIPID.Text = ip.InspectionPlanKey.ToString();
            TxtBoxIPType.Text = ip.Type;
            TxtBoxIPLotSize.Text = m_workOrder.QuantityRequired.ToString();
            ComboBoxAQL.Text = ip.AQLPercentage.ToString();
            ComboBoxIpLvl.Text = ip.Level;
            TxtBoxIPSkipLot.Text = ip.SkipLot.ToString();
            TxtBoxIPAcceptableDefects.Text = ip.AcceptableDefects.ToString();
            TxtBoxIPSampleSize.Text = ip.SampleSize.ToString();
            TxtBoxIPFAIQty.Text = ip.FAIQuantity.ToString();
            TxtBoxIPCodeLetter.Text = ip.CodeLetter;
        }

        InspectionPlan GetInspectionPlan()
        {
            InspectionPlan ip = new InspectionPlan();

            ip.RouterFK = m_inspectionPlan.RouterFK;
            ip.InspectionPlanId = m_inspectionPlan.InspectionPlanId;
            ip.InspectionPlanKey = m_inspectionPlan.InspectionPlanKey;

            ip.Type = TxtBoxIPType.Text;

            if (ComboBoxAQL.Text == "")
                ip.AQLPercentage = 0;
            else
                ip.AQLPercentage = Convert.ToDecimal(ComboBoxAQL.Text);

            ip.Level = ComboBoxIpLvl.Text;

            if (TxtBoxIPSkipLot.Text != "")
                ip.SkipLot = Convert.ToInt32(TxtBoxIPSkipLot.Text);
            else
                ip.SkipLot = 0;

            if (TxtBoxIPAcceptableDefects.Text != "")
                ip.AcceptableDefects = Convert.ToInt32(TxtBoxIPAcceptableDefects.Text);
            else
                ip.AcceptableDefects = 0;

            ip.CodeLetter = TxtBoxIPCodeLetter.Text;

            if (TxtBoxIPSampleSize.Text != "")
                ip.SampleSize = Convert.ToInt32(TxtBoxIPSampleSize.Text);
            else
                ip.SampleSize = 0;

            if (TxtBoxIPFAIQty.Text != "")
                ip.FAIQuantity = Convert.ToInt32(TxtBoxIPFAIQty.Text);
            else
                ip.FAIQuantity = 0;

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
                TextBoxQuantity.Text = "";
                ComboBoxUofM.SelectedIndex = 0;
                ComboBoxCharDesig.SelectedIndex = 0;
                TxtBoxDimNote.Text = "";
                TxtBoxDimComment.Text = "";

                //ComboBoxInspectionDevice.SelectedIndex = 0;
            }
            else
            {
                TxtBoxDimCharNum.Text = measurement.CharNumber.ToString();
                TxtBoxDimRefLoc.Text = measurement.RefLocation;
                TxtBoxDimReq.Text = measurement.Requirement.ToString();
                TextBoxPlusTolerance.Text = measurement.PlusTolerance.ToString();
                TextBoxMinusTolerance.Text = measurement.MinusTolerance.ToString();
                TextBoxQuantity.Text = measurement.Quantity.ToString();
                TxtBoxDimNote.Text = measurement.Note;
                TxtBoxDimComment.Text = measurement.Comment;

                ComboBoxUofM.SelectedItem = measurement.Units;
                ComboBoxCharDesig.SelectedItem = measurement.CharacteristicDesignator;
                //ComboBoxInspectionDevice.SelectedItem = measurement.InspectionDevice;
            }

            textChanged = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            InspectionPlan ip = GetInspectionPlan();

            var ipOriginal = App.Engine.Database.isiEngine.InspectionDb.InspectionPlans.Find(ip.InspectionPlanId);
            if (ipOriginal != null)
                App.Engine.Database.isiEngine.InspectionDb.Entry(ipOriginal).CurrentValues.SetValues(ip);
            else
                App.Engine.Database.isiEngine.InspectionDb.InspectionPlans.Add(ip);

            foreach (PartMeasurementSP newSetpoint in m_measurementCriteria)
            {
                var spOriginal = App.Engine.Database.isiEngine.InspectionDb.MeasurementSetpoints.Find(newSetpoint.PartMeasurementSPId);
                if (spOriginal != null)
                    App.Engine.Database.isiEngine.InspectionDb.Entry(spOriginal).CurrentValues.SetValues(newSetpoint);
                else
                    App.Engine.Database.isiEngine.InspectionDb.MeasurementSetpoints.Add(newSetpoint);
            }

            App.Engine.Database.isiEngine.InspectionDb.SaveChanges();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_measurementCriteria = new ObservableCollection<PartMeasurementSP>();
            LoadInspectionPlanInfo();
            WorkOrderInfo.FillTextBoxes(m_workOrder);
            if (m_inspectionPlan.MeasurementCriteria != null)
                m_inspectionPlan.MeasurementCriteria.ForEach(x => m_measurementCriteria.Add(x));

            DataGridResults.ItemsSource = m_measurementCriteria.OrderBy(x => x.CharNumber);
            isLoaded = true;
            textChanged = false;
            CheckNoteSelection();
        }

        private void ButtonAddMeasurement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PartMeasurementSP measurement = new PartMeasurementSP();

                measurement.PartMeasurementSPId = Guid.NewGuid();
                measurement.CharNumber = Convert.ToInt32(TxtBoxDimCharNum.Text);
                measurement.RefLocation = TxtBoxDimRefLoc.Text;
                measurement.Requirement = Convert.ToDecimal(TxtBoxDimReq.Text);
                measurement.Units = ComboBoxUofM.Text;
                measurement.PlusTolerance = Convert.ToDecimal(TextBoxPlusTolerance.Text);
                measurement.MinusTolerance = Convert.ToDecimal(TextBoxMinusTolerance.Text);
                measurement.CharacteristicDesignator = ComboBoxCharDesig.Text;
                int quantity = 1;
                Int32.TryParse(TextBoxQuantity.Text, out quantity);
                if (quantity < 1)
                    quantity = 1;
                measurement.Quantity = quantity;
                measurement.Note = TxtBoxDimNote.Text;
                measurement.Comment = TxtBoxDimComment.Text;
                //measurement.InspectionDevice = ComboBoxInspectionDevice.Text;

                measurement.InspectionPlanId = m_inspectionPlan.InspectionPlanId;

                m_measurementCriteria.Add(measurement);

                DataGridResults.ItemsSource = m_measurementCriteria.OrderBy(x => x.CharNumber);
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

                measurement.CharNumber = Convert.ToInt32(TxtBoxDimCharNum.Text);
                measurement.RefLocation = TxtBoxDimRefLoc.Text;
                measurement.Requirement = Convert.ToDecimal(TxtBoxDimReq.Text);
                measurement.Units = ComboBoxUofM.Text;
                measurement.PlusTolerance = Convert.ToDecimal(TextBoxPlusTolerance.Text);
                measurement.MinusTolerance = Convert.ToDecimal(TextBoxMinusTolerance.Text);
                measurement.CharacteristicDesignator = ComboBoxCharDesig.Text;
                int quantity = 1;
                Int32.TryParse(TextBoxQuantity.Text, out quantity);
                if (quantity < 1)
                    quantity = 1;
                measurement.Quantity = quantity;
                measurement.Note = TxtBoxDimNote.Text;
                measurement.Comment = TxtBoxDimComment.Text;

                //measurement.InspectionDevice = ComboBoxInspectionDevice.Text;

                measurement.InspectionPlanId = m_inspectionPlan.InspectionPlanId;

                DataGridResults.ItemsSource = null;
                DataGridResults.ItemsSource = m_measurementCriteria.OrderBy(x => x.CharNumber);
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
                TxtBoxIPAcceptableDefects.Text = "";
                TxtBoxIPSampleSize.Text = "";
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
                TxtBoxIPSampleSize.IsEnabled = true;
                TxtBoxIPSampleSize.IsReadOnly = true;
                TxtBoxIPFAIQty.IsEnabled = false;
                TxtBoxIPSampleSize.Background = (Brush)bc.ConvertFrom("#FFFFFFBE");

            }
            if (TxtBoxIPType.SelectedIndex == 1) /// Manual
            {
                TxtBoxIPAcceptableDefects.Text = "";
                TxtBoxIPSampleSize.Text = "";
                TxtBoxIPCodeLetter.Text = "";
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
                TxtBoxIPAcceptableDefects.IsEnabled = false;
                TxtBoxIPSampleSize.IsReadOnly = false;
                TxtBoxIPSampleSize.IsEnabled = true;
                TxtBoxIPSampleSize.Background = Brushes.White;
            }
            if (TxtBoxIPType.SelectedIndex == 2) /// First Article
            {
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
            CalculateAuto();
        }

        void CalculateAuto()
        {
            if (!this.IsLoaded)
                return;

            string AQLCodeLetter = "";
            string AQLAccept;
            string AQLReject;
            int AQLSampleSize;
            if (ComboBoxIpLvl.SelectedItem == null)
                return;

            string AQLLevelValue = ((ComboBoxIpLvl.SelectedItem ?? "") as ComboBoxItem).Content.ToString();
            int LotSizeInt = Convert.ToInt32(m_workOrder.QuantityRequired);
            //MessageBox.Show(AQLLevelValue.ToString());
            //MessageBox.Show(m_workOrder.QuantityRequired.ToString());
            if (ComboBoxAQL.SelectedItem == null)
                return;

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

        private void ComboBoxIpLvl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateAuto();
        }

        void CheckDefaults()
        {
            if (!this.textChanged)
                return;
            textChanged = false;
            string desig = (ComboBoxCharDesig.SelectedItem as ComboBoxItem).Content.ToString();
            string units = (ComboBoxUofM.SelectedItem as ComboBoxItem).Content.ToString();
            if (desig == "Linear" || desig == "Angularity")
            {
                decimal result;
                if (Decimal.TryParse(TxtBoxDimReq.Text, out result))
                {
                    if (MessageBox.Show("Would you like to apply the default tolerances?",
                        "Apply Default Tolerances?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (desig == "Linear")
                        {
                            SPCEngine.ToleranceType toleranceType = GetToleranceType(TxtBoxDimReq.Text);
                            if (units == "In")
                            {
                                decimal defaults = App.Engine.DefaultTolerances.GetDefaultTolerance(toleranceType, SPCEngine.ToleranceUnits.Inch);
                                ApplyDefaults(defaults);
                            }
                            else if (units == "mm")
                            {
                                decimal defaults = App.Engine.DefaultTolerances.GetDefaultTolerance(toleranceType, SPCEngine.ToleranceUnits.Metric);
                                ApplyDefaults(defaults);
                            }
                        }
                        else if (desig == "Angularity")
                        {
                            if (units == "In")
                            {
                                decimal defaults = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Inch);
                                ApplyDefaults(defaults);
                            }
                            else if (units == "mm")
                            {
                                decimal defaults = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Metric);
                                ApplyDefaults(defaults);
                            }
                        }
                    }
                }
            }
        }

        SPCEngine.ToleranceType GetToleranceType(string value)
        {
            SPCEngine.ToleranceType returnType = SPCEngine.ToleranceType.Unknown;
            decimal val;
            if (Decimal.TryParse(value, out val))
            {
                if (value.Contains("."))
                {
                    string substring = value.Substring(value.IndexOf(".") + 1);
                    switch (substring.Length)
                    {
                        case 1:
                            returnType = SPCEngine.ToleranceType.X_X;
                            break;
                        case 2:
                            returnType = SPCEngine.ToleranceType.X_XX;
                            break;
                        case 3:
                            returnType = SPCEngine.ToleranceType.X_XXX;
                            break;
                        case 4:
                        default:
                            returnType = SPCEngine.ToleranceType.X_XXXX;
                            break;
                    }
                }
                else
                    returnType = SPCEngine.ToleranceType.X;
            }
            return returnType;
        }

        void ApplyDefaults(decimal defaultVal)
        {
            TextBoxMinusTolerance.Text = TextBoxPlusTolerance.Text = defaultVal.ToString();
        }

        private void TextBoxMinusTolerance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal req = Convert.ToDecimal(TxtBoxDimReq.Text);
                //decimal plusTolerance = Convert.ToDecimal(TextBoxPlusTolerance.Text);
                decimal minusTolerance = Convert.ToDecimal(TextBoxMinusTolerance.Text);
                TxtBoxDimLowerLimit.Text = (req - minusTolerance).ToString();
            }
            catch { }
        }

        private void TextBoxPlusTolerance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal req = Convert.ToDecimal(TxtBoxDimReq.Text);
                decimal plusTolerance = Convert.ToDecimal(TextBoxPlusTolerance.Text);
                //decimal minusTolerance = Convert.ToDecimal(TextBoxMinusTolerance.Text);
                TxtBoxDimUpperLimit.Text = (req + plusTolerance).ToString();
            }
            catch { }
        }

        void CheckNoteSelection()
        {
            try
            {
                if (ComboBoxCharDesig.SelectedItem == null ||
                    (ComboBoxCharDesig.SelectedItem as ComboBoxItem).Content.ToString() != "Note")
                {
                    TxtBoxDimNote.IsEnabled = false;
                    TxtBoxDimReq.IsEnabled = true;
                    ComboBoxUofM.IsEnabled = true;
                    TextBoxPlusTolerance.IsEnabled = true;
                    TextBoxMinusTolerance.IsEnabled = true;
                    TextBoxQuantity.IsEnabled = true;

                }
                else
                {
                    TxtBoxDimNote.IsEnabled = true;
                    TxtBoxDimReq.IsEnabled = false;
                    ComboBoxUofM.IsEnabled = false;
                    TextBoxPlusTolerance.IsEnabled = false;
                    TextBoxMinusTolerance.IsEnabled = false;
                    TextBoxQuantity.IsEnabled = false;

                    TxtBoxDimReq.Text = "0";
                    ComboBoxUofM.Text = "0";
                    TextBoxPlusTolerance.Text = "0";
                    TextBoxMinusTolerance.Text = "0";
                    TextBoxQuantity.Text = "0";
                }
            }
            catch { }
        }

        private void TxtBoxDimReq_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckDefaults();
        }

        private void TxtBoxDimReq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CheckDefaults();
        }

        private void TxtBoxDimReq_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void ComboBoxCharDesig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckNoteSelection();
        }
    }
}
