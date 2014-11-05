using MieTrakWrapper.MieTrak;
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

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow(List<WorkOrder> test)
        {
            InitializeComponent();
            MainGrid.DataContext = this;
            DataGridTest.ItemsSource = test;
        }

        public TestWindow(List<Router> test)
        {
            InitializeComponent();
            MainGrid.DataContext = this;
            DataGridTest.ItemsSource = test;
        }
    }
}
