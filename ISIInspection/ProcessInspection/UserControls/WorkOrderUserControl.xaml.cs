using ISIInspection.Models;
using ProcessInspection.Windows;
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

namespace ProcessInspection.UserControls
{
    /// <summary>
    /// Interaction logic for WorkOrderUserControl.xaml
    /// </summary>
    public partial class WorkOrderUserControl : UserControl
    {
        public WorkOrderUserControl()
        {
            InitializeComponent();
            MainGrid.DataContext = this;
        }

        void Refresh(string search = "")
        {
            App.Engine.db.WorkOrders.ToList();
            if (search == "")
                contentDataGrid.ItemsSource = App.Engine.db.WorkOrders.Local;
            else
                contentDataGrid.ItemsSource = App.Engine.db.WorkOrders.Local.Where(x => x.OrderNumber.Contains(search));
            contentDataGrid.Items.Refresh();
        }

        void Edit()
        {
            AddEditWorkOrder win = new AddEditWorkOrder(contentDataGrid.SelectedItem as WorkOrder);
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
            Refresh(TextboxSearch.Text);
        }

        void OpenWorkOrder(WorkOrder workOrder)
        {
            App.Engine.OpenWorkOrder(workOrder);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh(TextboxSearch.Text);
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWorkOrder win = new AddEditWorkOrder();
            win.Owner = App.Current.MainWindow;
            if (win.ShowDialog() == true)
            {
                OpenWorkOrder(win.WorkOrder);
            }
            else
                Refresh(TextboxSearch.Text);
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            App.Engine.db.WorkOrders.Remove(contentDataGrid.SelectedItem as WorkOrder);
            App.Engine.db.SaveChanges();
            Refresh(TextboxSearch.Text);
        }

        private void contentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenWorkOrder(contentDataGrid.SelectedItem as WorkOrder);
        }
    }
}
