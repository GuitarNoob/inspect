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
using ISIInspection.Models;

namespace ProcessInspection.Windows
{
    /// <summary>
    /// Interaction logic for AddEditWorkOrder.xaml
    /// </summary>
    public partial class AddEditWorkOrder : Window
    {
        public WorkOrder WorkOrder { get; set; }
        public WorkOrder EditWorkOrder;
        bool isEdit = false;

        public AddEditWorkOrder()
        {
            InitializeComponent();
            WorkOrder = new ISIInspection.Models.WorkOrder() { WorkOrderId = Guid.NewGuid() };
            TextBoxCustomer.ItemsSource = App.Engine.db.Customers.Local;
            MainGrid.DataContext = this;
        }

        public AddEditWorkOrder(WorkOrder editCustomer)
        {
            InitializeComponent();
            isEdit = true;
            WorkOrder = new ISIInspection.Models.WorkOrder() { WorkOrderId = Guid.NewGuid() };
            TextBoxCustomer.ItemsSource = App.Engine.db.Customers.Local;
            MainGrid.DataContext = this;
            EditWorkOrder = editCustomer;
            EditWorkOrder.CopyInfo(WorkOrder);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            { 
                WorkOrder.CopyInfo(EditWorkOrder);
            } 
            else
            {
                
                App.Engine.db.WorkOrders.Add(WorkOrder);
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
