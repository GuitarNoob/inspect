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
    /// Interaction logic for RunPartStart.xaml
    /// </summary>
    public partial class RunPartStart : UserControl
    {
        public RunPartStart()
        {
            InitializeComponent();
            MainGrid.DataContext = this;
        }

        void Refresh(string search = "")
        {
            App.Engine.db.Customers.ToList();
            if (search == "")
                contentDataGrid.ItemsSource = App.Engine.db.PartInformation.Local;
            else
                contentDataGrid.ItemsSource = App.Engine.db.PartInformation.Local.Where(x => x.PartNumber.Contains(search));
            contentDataGrid.Items.Refresh();
        }

        void Edit()
        {
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
            throw new Exception();
            //AddEditPartInformation win = new AddEditPartInformation();
            //win.Owner = App.Current.MainWindow;
            //win.ShowDialog();
            //Refresh(TextboxSearch.Text);
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            App.Engine.db.Customers.Remove(contentDataGrid.SelectedItem as Customer);
            App.Engine.db.SaveChanges();
            Refresh(TextboxSearch.Text);
        }

        private void contentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        public bool GetResult(out object result)
        {
            result = null;
            return false;
        }
    }
}