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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISIInspection.ISIInspectionEngine isiEngine;
        MieTrakWrapper.MieTrak.MieTrakConnectionManager mietrakConn;
        public WorkOrder selectedWO { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.DataContext = this;
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

        private void BtnWorkOrderSearch_Click(object sender, RoutedEventArgs e)
        {
            string type = ((ComboBoxType.SelectedItem ?? "") as ComboBoxItem).Content.ToString();
            string search = TextBoxSearchValue.Text;
            if (search == "")
            {
                DataGridResults.ItemsSource = mietrakConn.mietrakDb.WorkOrders.ToList();
                return;
            }
            switch (type)
            {
                case "W.O. Number":
                    DataGridResults.ItemsSource = mietrakConn.mietrakDb.WorkOrders.Where(x => x.WorkOrderNumber.Contains(search)).ToList();
                    break;
                case "Part Number":
                    DataGridResults.ItemsSource = mietrakConn.mietrakDb.WorkOrders.Where(x => x.PartNumber.Contains(search)).ToList();
                    break;
            }
        }

        public void DataGridResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = DataGridResults.SelectedItem;
            if (item != null)
            {
                if (item is WorkOrder)
                {
                    selectedWO = (WorkOrder)item;
                    FillTextBoxes();
                }
            }
        }

        private void FillTextBoxes()
        {
            WorkOrder wo = selectedWO ?? new WorkOrder();
            TxtBoxCustomerId.Text = wo.CustomerFK.ToString();
            TxtBoxDescription.Text = wo.ItemDescription;
            TxtBoxPartNumber.Text = wo.PartNumber;
            TxtBoxPartRevision.Text = wo.Revision;
            TxtBoxQuantityFab.Text = (wo.QuantityFab ?? (decimal)0).ToString("0");
            TxtBoxQuantityReq.Text = (wo.QuantityRequired ?? (decimal)0).ToString("0");
            TxtBoxRouter.Text = wo.RouterFK.ToString();
            TxtBoxWorkOrder.Text = wo.WorkOrderPK.ToString();
            TxtBoxStatus.Text = wo.WorkOrderStatusFK.ToString();

            Party customer = mietrakConn.mietrakDb.Parties.FirstOrDefault(x => x.PartyPK == wo.CustomerFK);
            TxtBoxCustomer.Text = customer.Name;
        }
    }
}
