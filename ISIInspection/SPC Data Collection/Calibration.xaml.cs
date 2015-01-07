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
    /// Interaction logic for Calibration.xaml
    /// </summary>
    public partial class Calibration : Window
    {
        private ObservableCollection<ISIInspection.Models.Calibration> calibrations { get; set; }
        private List<ISIInspection.Models.Calibration> deletedCalibrations = new List<ISIInspection.Models.Calibration>();
        public Calibration()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            calibrations = new ObservableCollection<ISIInspection.Models.Calibration>();
            List<ISIInspection.Models.Calibration> calList = App.Engine.Database.isiEngine.InspectionDb.DeviceCalibration.ToList();
            calList.ForEach(x => calibrations.Add(x));
            DataGrid_Data.ItemsSource = calibrations;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (ISIInspection.Models.Calibration cali in calibrations)
            {
                if (cali.CalibrationId == Guid.Empty)
                    cali.CalibrationId = Guid.NewGuid();

                var spOriginal = App.Engine.Database.isiEngine.InspectionDb.DeviceCalibration.Find(cali.CalibrationId);
                if (spOriginal != null)
                    App.Engine.Database.isiEngine.InspectionDb.Entry(spOriginal).CurrentValues.SetValues(cali);
                else
                    App.Engine.Database.isiEngine.InspectionDb.DeviceCalibration.Add(cali);
            }

            foreach (ISIInspection.Models.Calibration cali in deletedCalibrations)
            {
                var spOriginal = App.Engine.Database.isiEngine.InspectionDb.DeviceCalibration.Find(cali.CalibrationId);
                if (spOriginal != null)
                    App.Engine.Database.isiEngine.InspectionDb.DeviceCalibration.Remove(spOriginal);
            }

            App.Engine.Database.isiEngine.InspectionDb.SaveChanges();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Data.SelectedItem == null)
                return;
            ISIInspection.Models.Calibration cali = DataGrid_Data.SelectedItem as ISIInspection.Models.Calibration;
            if (cali == null)
                return;
            if (cali.CalibrationId != Guid.Empty)
                deletedCalibrations.Add(cali);
            calibrations.Remove(cali);
        }
    }
}
