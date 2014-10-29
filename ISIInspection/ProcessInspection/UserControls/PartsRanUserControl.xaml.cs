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
    /// Interaction logic for PartsRanUserControl.xaml
    /// </summary>
    public partial class PartsRanUserControl : UserControl
    {
        WorkOrder WorkOrder;
        WorkOrderMainControl m_parent;

        public PartsRanUserControl(WorkOrderMainControl parent, WorkOrder currentWorkOrder)
        {
            InitializeComponent();
            m_parent = parent;
            WorkOrder = currentWorkOrder;
            MainGrid.DataContext = this;
        }

        void Refresh()
        {
            App.Engine.db.Customers.ToList();
            contentDataGrid.ItemsSource = App.Engine.db.PartsCreated.Local.Where(x => x.WorkOrder == WorkOrder);
            contentDataGrid.Items.Refresh();
        }

        void Edit()
        {
            RunPart(contentDataGrid.SelectedItem as RanPart);
            Refresh();
        }

        void Add()
        {
            RunPart();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(MainGrid);
            Refresh();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            App.Engine.db.PartsCreated.Remove(contentDataGrid.SelectedItem as RanPart);
            App.Engine.db.SaveChanges();
            Refresh();
        }

        private void contentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        public void RunPart(RanPart part = null)
        {
            if (part == null)
                part = new RanPart() { RanPartId = Guid.NewGuid() };

            GridContent.Children.Clear();
            GridContent.Children.Add(new RunPartUserControl(GridContent, MainGrid, part));
        }
    }
}
