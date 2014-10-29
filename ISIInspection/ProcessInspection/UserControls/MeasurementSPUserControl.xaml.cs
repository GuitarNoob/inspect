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
    /// Interaction logic for MeasurementSPUserControl.xaml
    /// </summary>
    public partial class MeasurementSPUserControl : UserControl
    {
        Part PartOwner;
        bool SaveChanges = false;

        public MeasurementSPUserControl(Part partOwner, bool saveChanges = false)
        {
            InitializeComponent();
            PartOwner = partOwner;
            SaveChanges = saveChanges;
            MainGrid.DataContext = this;
        }

        void Refresh(string search = "")
        {
            App.Engine.db.Customers.ToList();
            if (search == "")
                contentDataGrid.ItemsSource = App.Engine.db.MeasurementSetpoints.Local;
            else
                contentDataGrid.ItemsSource = App.Engine.db.MeasurementSetpoints.Local.Where(x => x.Number.Contains(search));
            contentDataGrid.Items.Refresh();
        }

        void Edit()
        {
            if (contentDataGrid.SelectedItem == null)
                return;

            AddEditPartSetPoint win = new AddEditPartSetPoint(contentDataGrid.SelectedItem as PartMeasurementSP, SaveChanges);
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
            AddEditPartSetPoint win = new AddEditPartSetPoint(PartOwner, SaveChanges);
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
            App.Engine.db.Customers.Remove(contentDataGrid.SelectedItem as Customer);
            App.Engine.db.SaveChanges();
            Refresh(TextboxSearch.Text);
        }

        private void contentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

    }
}
