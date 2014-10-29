using ISIInspection.Models;
using ProcessInspection.UserControls;
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
    /// Interaction logic for AddEditPartInformation.xaml
    /// </summary>
    public partial class AddEditPartInformation : Window
    {
        public Part Part { get; set; }
        public Part EditPart;
        bool isEdit = false;

        public AddEditPartInformation(Customer customer)
        {
            InitializeComponent();
            Part = new ISIInspection.Models.Part();
            Part.Customer = customer;
            Part.CustomerId = customer.CustomerId;
            InfoGrid.DataContext = this;
            MeasurementTab.Content = new MeasurementSPUserControl(Part);
        }

        public AddEditPartInformation(Part editPart)
        {
            InitializeComponent();
            isEdit = true;
            Part = new ISIInspection.Models.Part();
            InfoGrid.DataContext = this;
            EditPart = editPart;
            EditPart.CopyInfo(Part);
            MeasurementTab.Content = new MeasurementSPUserControl(EditPart);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            { 
                Part.CopyInfo(EditPart);
            } 
            else
            {
                Part.PartId = Guid.NewGuid();
                App.Engine.db.PartInformation.Add(Part);
            }

            App.Engine.db.SaveChanges();
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
