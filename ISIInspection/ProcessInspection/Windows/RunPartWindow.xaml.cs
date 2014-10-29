using ISIInspection.Models;
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

namespace ProcessInspection.Windows
{
    /// <summary>
    /// Interaction logic for RunPartWindow.xaml
    /// </summary>
    public partial class RunPartWindow : Window
    {
        RanPart currentPart;

        public RunPartWindow(RanPart part)
        {
            InitializeComponent();
            currentPart = part;
            MainGrid.DataContext = this;
            InfoGrid.DataContext = currentPart.PartType;
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            LinkToPartType link = new LinkToPartType();
            link.Owner = App.Current.MainWindow;
            if (link.ShowDialog() == true)
            {
                currentPart.PartType = link.selectedPart;
                currentPart.PartTypeId = link.selectedPart.PartId;
                InfoGrid.DataContext = currentPart.PartType;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
