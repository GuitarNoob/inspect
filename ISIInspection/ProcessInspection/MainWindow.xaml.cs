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
using ISIInspection.Models;
using ProcessInspection.UserControls;
using MahApps.Metro.Controls;

namespace ProcessInspection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DbManagement orderSelect = new DbManagement();
        WorkOrderMainControl orderMain = new WorkOrderMainControl();

        public MainWindow()
        {
            InitializeComponent();
            App.Engine.LogIn(new User() { Name = "test user" });
            MainGrid.DataContext = App.Engine;
            App.Engine.WorkOrderChanged += Engine_WorkOrderChanged;
            ShowPage(orderSelect);
        }

        void Engine_WorkOrderChanged(object sender, EventArgs e)
        {
            if (App.Engine.IsWorkOrderOpened)
            {
                ShowPage(orderMain);
                Home.IsChecked = false;
                Dashboard.IsChecked = false;
                Settings.IsChecked = false;
            }
            else
                ShowPage(orderSelect);
        }

        public void ShowPage(UserControl control)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(control);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (sender == Home)
            {
                App.Engine.CloseWorkOrder();
                Home.IsChecked = true;
                Dashboard.IsChecked = false;
                Settings.IsChecked = false;
            }
            else if (sender == Dashboard)
            {
                Home.IsChecked = false;
                Dashboard.IsChecked = true;
                Settings.IsChecked = false;
            }
            else if (sender == Settings)
            {
                Home.IsChecked = false;
                Dashboard.IsChecked = false;
                Settings.IsChecked = true;
            }
        }        
    }
}
