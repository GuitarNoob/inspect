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
    /// Interaction logic for CollectDataWindow.xaml
    /// </summary>
    public partial class CollectDataWindow : Window
    {
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
        }
    }
}
