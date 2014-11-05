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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISIInspection.ISIInspectionEngine isiEngine;
        MieTrakWrapper.MieTrak.MieTrakConnectionManager mietrakConn;

        public MainWindow()
        {
            InitializeComponent();

            isiEngine = new ISIInspection.ISIInspectionEngine();
            mietrakConn = new MieTrakWrapper.MieTrak.MieTrakConnectionManager();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreatePlan Plan1 = new CreatePlan();
            Plan1.Show();
        }

        private void BtnWorkOrder_Click(object sender, RoutedEventArgs e)
        {
            TestWindow win = new TestWindow(mietrakConn.GetWorkOrders());
            win.ShowDialog();
        }

        private void BtnRouter_Click(object sender, RoutedEventArgs e)
        {
            TestWindow win = new TestWindow(mietrakConn.GetRouters());
            win.ShowDialog();
        }
    }
}
