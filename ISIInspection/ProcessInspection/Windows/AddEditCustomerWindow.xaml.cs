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
    /// Interaction logic for AddEditCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {
        public Customer Customer { get; set; }
        public Customer EditCustomer;
        bool isEdit = false;

        public AddEditCustomerWindow()
        {
            InitializeComponent();
            Customer = new ISIInspection.Models.Customer();
            MainGrid.DataContext = this;
        }

        public AddEditCustomerWindow(Customer editCustomer)
        {
            InitializeComponent();
            isEdit = true;
            Customer = new ISIInspection.Models.Customer();
            MainGrid.DataContext = this;
            EditCustomer = editCustomer;
            EditCustomer.CopyInfo(Customer);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            { 
                Customer.CopyInfo(EditCustomer);
            } 
            else
            {
                Customer.CustomerId = Guid.NewGuid();
                App.Engine.db.Customers.Add(Customer);
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
