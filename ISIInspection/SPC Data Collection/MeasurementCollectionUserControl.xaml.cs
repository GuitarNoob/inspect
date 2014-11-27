using ISIInspection.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPC_Data_Collection
{
   /// <summary>
   /// Interaction logic for MeasurementCollectionUserControl.xaml
   /// </summary>
   public partial class MeasurementCollectionUserControl : UserControl
   {
      public MeasurementCollectionUserControl(PartMeasurementSP setPoint)
      {
         InitializeComponent();
      }

      public MeasurementCollectionUserControl(PartMeasurementSP setPoint, PartMeasurementActual actualValue)
      {
         InitializeComponent();
      }
   }
}
