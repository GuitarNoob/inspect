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
    /// Interaction logic for CreatePlan.xaml
    /// </summary>
    public partial class CreatePlan : Window
    {
        public CreatePlan()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtBoxIPType_DropDownClosed(object sender, EventArgs e)
        {
            if (TxtBoxIPType.SelectedIndex == 0) /// Auto
            {
                CmBoxIPAQL.IsEnabled = true;
                CmBoxIPLevel.IsEnabled = true;
                TxtBoxIPAD.IsEnabled = true;
                TxtBoxIPFreq.IsEnabled = false;
            }
            if (TxtBoxIPType.SelectedIndex == 1) /// Manual
            {
                TxtBoxIPFreq.IsEnabled = true;
                TxtBoxIPSize.IsEnabled = true;
                CmBoxIPAQL.IsEnabled = false;
                CmBoxIPLevel.IsEnabled = false;
                TxtBoxIPAD.IsEnabled = false;
            }
            if (TxtBoxIPType.SelectedIndex == 2) /// First Article
            {
                TxtBoxIPFreq.IsEnabled = false;
                TxtBoxIPSize.IsEnabled = false;
                CmBoxIPAQL.IsEnabled = false;
                CmBoxIPLevel.IsEnabled = false;
                TxtBoxIPAD.IsEnabled = false;
            }
        }

    }
}
