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
using ProcessInspection.Windows;
using ISIInspection.Models;

namespace ProcessInspection.UserControls
{
    /// <summary>
    /// Interaction logic for WorkOrderMainControl.xaml
    /// </summary>
    public partial class WorkOrderMainControl : UserControl
    {
        public WorkOrderMainControl()
        {
            InitializeComponent();
            App.Engine.WorkOrderChanged += Engine_WorkOrderChanged;
            GridMain.DataContext = App.Engine.CurrentWorkOrder;
        }

        void Engine_WorkOrderChanged(object sender, EventArgs e)
        {
            GridMain.DataContext = App.Engine.CurrentWorkOrder;

            if (App.Engine.CurrentWorkOrder != null)
            {
                TabParts.Content = new PartsRanUserControl(this, App.Engine.CurrentWorkOrder);
                TabPartTypes.Content = new PartTypeUserControl(App.Engine.CurrentWorkOrder.Customer);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditWorkOrder win = new AddEditWorkOrder(App.Engine.CurrentWorkOrder);
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
        }

    }
}
