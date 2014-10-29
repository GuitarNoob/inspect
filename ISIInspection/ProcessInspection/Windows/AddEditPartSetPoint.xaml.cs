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
using System.Windows.Shapes;

namespace ProcessInspection.Windows
{
    /// <summary>
    /// Interaction logic for AddEditPartSetPoint.xaml
    /// </summary>
    public partial class AddEditPartSetPoint : Window
    {
        public PartMeasurementSP PartMeasurementSP { get; set; }
        public PartMeasurementSP EditPartMeasurementSP;
        Part PartOwner;
        bool isEdit = false;
        bool SaveChanges = false;

        public AddEditPartSetPoint(Part partOwner, bool saveChanges)
        {
            InitializeComponent();
            SaveChanges = saveChanges;
            PartOwner = partOwner;
            PartMeasurementSP = new ISIInspection.Models.PartMeasurementSP();
            MainGrid.DataContext = this;
        }

        public AddEditPartSetPoint(PartMeasurementSP editPartMeasurementSP, bool saveChanges)
        {
            InitializeComponent();
            SaveChanges = saveChanges;
            isEdit = true;
            PartMeasurementSP = new ISIInspection.Models.PartMeasurementSP();
            MainGrid.DataContext = this;
            EditPartMeasurementSP = editPartMeasurementSP;
            EditPartMeasurementSP.CopyInfo(PartMeasurementSP);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                PartMeasurementSP.CopyInfo(EditPartMeasurementSP);
            }
            else
            {
                PartMeasurementSP.PartMeasurementSPId = Guid.NewGuid();
                PartMeasurementSP.PartType = PartOwner;
                PartMeasurementSP.PartTypeId = PartOwner.PartId;
                App.Engine.db.MeasurementSetpoints.Add(PartMeasurementSP);
            }

            if (SaveChanges)
                App.Engine.db.SaveChanges();
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
