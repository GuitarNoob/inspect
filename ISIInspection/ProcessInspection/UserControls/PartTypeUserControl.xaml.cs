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
    /// Interaction logic for PartTypeUserControl.xaml
    /// </summary>
    public partial class PartTypeUserControl : UserControl
    {
        Customer Customer;

        public PartTypeUserControl(Customer customer)
        {
            InitializeComponent();
            MainGrid.DataContext = this;
            Customer = customer;
        }

        void Refresh(string search = "")
        {
            App.Engine.db.PartInformation.ToList();
            if (search == "")
                contentDataGrid.ItemsSource = App.Engine.db.PartInformation.Local.Where(x => x.Customer == Customer);
            else
                contentDataGrid.ItemsSource = App.Engine.db.PartInformation.Local.Where(x => x.PartNumber.Contains(search) && x.Customer == Customer);
            contentDataGrid.Items.Refresh();
        }

        void Edit()
        {
            if (contentDataGrid.SelectedItem == null)
                return;

            AddEditPartInformation win = new AddEditPartInformation(contentDataGrid.SelectedItem as Part);
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
            Refresh(TextboxSearch.Text);
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
            AddEditPartInformation win = new AddEditPartInformation(Customer);
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
            Refresh(TextboxSearch.Text);
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            App.Engine.db.PartInformation.Remove(contentDataGrid.SelectedItem as Part);
            App.Engine.db.SaveChanges();
            Refresh(TextboxSearch.Text);
        }

        private void contentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }
    }
}
