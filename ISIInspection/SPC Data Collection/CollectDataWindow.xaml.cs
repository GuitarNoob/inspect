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
    /// Interaction logic for CollectDataWindow.xaml
    /// </summary>
    public partial class CollectDataWindow : Window
    {
        ObservableCollection<MeasurementCollector> measurementCollectors = new ObservableCollection<MeasurementCollector>();

        public CollectDataWindow(WorkOrder workOrder, InspectionPlan inspectionPlan)
        {
            InitializeComponent();
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
            foreach (PartMeasurementSP sp in iplan.MeasurementCriteria.OrderBy(x => x.CharNumber))
            {
                foreach (PartMeasurementActual measurement in sp.Measurements)
                    measurementCollectors.Add(new MeasurementCollector(measurement));
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
                    var spOriginal = App.isiEngine.InspectionDb.MeasurementActual.Find(collector.ActualMeasurement.PartMeasurementActualId);
                    if (spOriginal != null)
                    {
                        spOriginal.CompletedTime = DateTime.Now;
                        spOriginal.MeasuredValue = collector.Measured;
                        spOriginal.UserId = App.CurrentUser.UserPK;
                    }
                }
            }
            App.isiEngine.InspectionDb.SaveChanges();
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
                if (((MeasurementCollector)e.Row.DataContext).IsReadOnly)
                {
                    e.Row.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFBE"));
                }
            }
            catch
            {
            }
        }
    }

    public class MeasurementCollector
    {
        public PartMeasurementSP SetPoint { get; set; }
        public PartMeasurementActual ActualMeasurement { get; set; }
        public bool IsReadOnly = false;
        public bool IsUpdated = false;

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

        public string CompletedTime
        {
            get;
            set;
        }

        public MeasurementCollector(PartMeasurementActual actual)
        {
            SetPoint = actual.PartMeasurementSP;
            ActualMeasurement = actual;
            m_Measured = actual.MeasuredValue;

            if (actual.CompletedTime > new DateTime(1975, 1, 1))
            {
                this.CompletedTime = actual.CompletedTime.ToString();
                IsReadOnly = true;
                GetUser(actual.UserId);
            }
        }

        private void GetUser(int userPk)
        {
            List<User> usersMatch = App.mietrakConn.mietrakDb.Users.Where(x => x.UserPK == userPk).ToList();
            if (usersMatch != null && usersMatch.Count > 0)
            {
                m_user = usersMatch[0];
                m_userDisplayName = App.GetUserDisplayName(m_user);
            }
            else
                m_userDisplayName = "Unknown";
        }
    }
}
