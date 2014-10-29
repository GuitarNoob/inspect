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
    /// Interaction logic for RunPartUserControl.xaml
    /// </summary>
    public partial class RunPartUserControl : UserControl
    {
        RanPart currentPart;
        Grid LastGrid;
        FrameworkElement LastWindow; 

        public RunPartUserControl(Grid owner, FrameworkElement lastWindow, RanPart part)
        {
            InitializeComponent();
            LastGrid = owner;
            LastWindow = lastWindow;
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

        void GoBack()
        {
            LastGrid.Children.Clear();
            LastGrid.Children.Add(LastWindow);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}
