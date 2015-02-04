using ISIInspection.Models;
using Microsoft.Win32;
using MieTrakWrapper.MieTrak;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for CollectDataWindow.xaml
    /// </summary>
    public partial class CollectDataWindow : Window
    {
        const string SEPERATOR_CHAR = ",";
        ObservableCollection<MeasurementCollector> measurementCollectors = new ObservableCollection<MeasurementCollector>();
        public ObservableCollection<string> InspectionDeviceOptions = new ObservableCollection<string>();

        public CollectDataWindow(WorkOrder workOrder, InspectionPlan inspectionPlan)
        {
            InitializeComponent();
            this.WorkOrderInfo.FillTextBoxes(workOrder);
            LoadRows(workOrder, inspectionPlan);

            DataGridMeasurements.AddHandler(CommandManager.PreviewExecutedEvent,
                (ExecutedRoutedEventHandler)((sender, args) =>
                {
                    if (args.Command == DataGrid.BeginEditCommand)
                    {
                        DataGrid dataGrid = (DataGrid)sender;
                        DependencyObject focusScope = FocusManager.GetFocusScope(dataGrid);
                        FrameworkElement focusedElement = (FrameworkElement)FocusManager.GetFocusedElement(focusScope);
                        MeasurementCollector model = (MeasurementCollector)focusedElement.DataContext;
                        if (model.IsReadOnly)
                        {
                            args.Handled = true;
                        }
                    }
                }));
        }

        void LoadRows(WorkOrder wo, InspectionPlan iplan)
        {
            if (iplan == null || iplan.MeasurementCriteria == null)
                return;

            List<ISIInspection.Models.Calibration> inspectionDevices = App.Engine.Database.isiEngine.InspectionDb.DeviceCalibration.ToList();
            InspectionDeviceOptions.Clear();
            inspectionDevices.ForEach(x => InspectionDeviceOptions.Add(x.SerialNumber));
            ComboBoxDevice.ItemsSource = InspectionDeviceOptions;
            foreach (PartMeasurementSP sp in iplan.MeasurementCriteria.OrderBy(x => x.CharNumber))
            {
                int index = 1;
                if (sp.Measurements != null)
                    foreach (PartMeasurementActual measurement in sp.Measurements)
                        measurementCollectors.Add(new MeasurementCollector(measurement, index++));
            }
            DataGridMeasurements.ItemsSource = measurementCollectors;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtmSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (MeasurementCollector collector in measurementCollectors)
            {
                if (collector.IsUpdated)
                {
                    var spOriginal = App.Engine.Database.isiEngine.InspectionDb.MeasurementActual.Find(collector.ActualMeasurement.PartMeasurementActualId);
                    if (spOriginal != null)
                    {
                        spOriginal.CompletedTime = DateTime.Now;
                        spOriginal.MeasuredValue = collector.Measured;
                        spOriginal.InspectionComment = collector.InspectionComment;
                        spOriginal.InspectionDevice = collector.InspectionDeviceSelection;
                        spOriginal.UserId = App.Engine.CurrentUser.UserPK;
                    }
                }
            }
            App.Engine.Database.isiEngine.InspectionDb.SaveChanges();
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGridMeasurements_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (((MeasurementCollector)e.Row.DataContext).IsReadOnly == true)
                {                    
                    e.Row.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFBE"));
                }
            }
            catch
            {
            }
        }

        private void BtmExport_Click(object sender, RoutedEventArgs e)
        {
            ExportToCSV();
        }

        private void ExportToCSV()
        {
            try
            {
                //have the user select a save path
                SaveFileDialog diag = new SaveFileDialog();
                diag.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                bool? result = diag.ShowDialog();
                if (diag.FileName == "" || result == false)
                    return;

                //concat the class into csv file
                StringBuilder sb = new StringBuilder();

                //write the headers
                sb.Append("Char");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("Ref");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("Requirement");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("UofM");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("MeasureValue");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("UpperLimit");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("LowerLimit");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("CharDesignator");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("InspectionDevice");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("Comment");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("User");
                sb.Append(SEPERATOR_CHAR);
                sb.Append("MeasuredTime");
                sb.Append(Environment.NewLine);

                //write each row
                for (int i = 0; i < measurementCollectors.Count; i++)
                {
                    sb.Append(measurementCollectors[i].SetPoint.CharNumber);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].SetPoint.RefLocation);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].SetPoint.Requirement);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].SetPoint.Units);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].Measured);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].SetPoint.PlusTolerance);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].SetPoint.MinusTolerance);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].SetPoint.CharacteristicDesignator);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(""); // inspection device
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(""); //need to add comment
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].UserDisplayName);
                    sb.Append(SEPERATOR_CHAR);
                    sb.Append(measurementCollectors[i].CompletedTime);
                    sb.Append(Environment.NewLine);
                }

                //write the string out to disk
                File.WriteAllText(diag.FileName, sb.ToString());

                //open the file in windows
                Process.Start(diag.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridMeasurements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class MeasurementCollector
    {
        public string DisplayCharNumber { get; set; }
        public PartMeasurementSP SetPoint { get; set; }
        public PartMeasurementActual ActualMeasurement { get; set; }
        public bool IsReadOnly = false;
        public bool IsUpdated = false;
        
        public decimal UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }

        public string InspectionDeviceSelection { get; set; }
        public string InspectionComment { get; set; }

        private decimal m_Measured = -1;
        public decimal Measured
        {
            get { return m_Measured; }
            set
            {
                IsUpdated = true;
                m_Measured = value;
            }
        }

        private int m_userPK = -1;
        private User m_user = null;
        private string m_userDisplayName = "";
        public string UserDisplayName
        {
            get { return m_userDisplayName; }
            set { }
        }

        public string CompletedTime { get; set; }

        public MeasurementCollector(PartMeasurementActual actual, int CharNum)
        {
            //inspectionDeviceOptions.Select(x => x.SerialNumber).ToList().ForEach(x => InspectionDeviceOptions.Add(x));
            SetPoint = actual.PartMeasurementSP;
            UpperLimit = SetPoint.Requirement + SetPoint.PlusTolerance;
            LowerLimit = SetPoint.Requirement - SetPoint.MinusTolerance;
            ActualMeasurement = actual;           
            m_Measured = actual.MeasuredValue;
            InspectionComment = actual.InspectionComment;
            InspectionDeviceSelection = actual.InspectionDevice;
            DisplayCharNumber = SetPoint.CharNumber + "." + CharNum;

            if (actual.CompletedTime > new DateTime(1975, 1, 1)) // this is the min time that can be saved into MS SQL
            {
                this.CompletedTime = actual.CompletedTime.ToString();
                IsReadOnly = true;
                GetUser(actual.UserId);
            }
        }

        private void GetUser(int userPk)
        {
            List<User> usersMatch = App.Engine.Database.mietrakConn.mietrakDb.Users.Where(x => x.UserPK == userPk).ToList();
            if (usersMatch != null && usersMatch.Count > 0)
            {
                m_user = usersMatch[0];
                m_userDisplayName = App.Engine.GetUserDisplayName(m_user);
            }
            else
                m_userDisplayName = "Unknown";
        }
    }
}
