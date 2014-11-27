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
      }

      void LoadRows(WorkOrder wo, InspectionPlan iplan)
      {
         string code = AQLSamplingHelper.GetSampleSizeCode((int)(wo.QuantityRequired ?? 0), (InspectionLevel)Enum.Parse(typeof(InspectionLevel), iplan.Level));
         int samplingSize = -1;
         int samplingError = -1;
         AQLSamplingHelper.GetSampleSize(code, iplan.AQLPercentage, out samplingSize, out samplingError);

         foreach (PartMeasurementSP sp in iplan.MeasurementCriteria)
         {
            for (int i = 0; i < samplingSize; i++)
               measurementCollectors.Add(new MeasurementCollector(sp));
         }
         DataGridMeasurements.ItemsSource = measurementCollectors;
      }      

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {

      }
   }

   public class MeasurementCollector
   {
      public PartMeasurementSP SetPoint { get; set; }
      public decimal Measured { get; set; }
      public bool IsReadOnly = false;

      public MeasurementCollector(PartMeasurementSP sp)
      {
         SetPoint = sp;
      }
   }   
}
