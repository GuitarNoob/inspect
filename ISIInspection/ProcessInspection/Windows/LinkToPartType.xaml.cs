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
    /// Interaction logic for LinkToPartType.xaml
    /// </summary>
    public partial class LinkToPartType : Window
    {
        public Part selectedPart;

        public LinkToPartType()
        {
            InitializeComponent();

            App.Engine.db.PartInformation.ToList();
            PartTypes.ItemsSource = App.Engine.db.PartInformation.Local;
        }

        void Save(Part part)
        {
            if (part == null)
            {
                MessageBox.Show("No Part selected!", "No Part selected!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            selectedPart = part;
            this.DialogResult = true;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    AddEditPartInformation win = new AddEditPartInformation();
        //    win.Owner = App.Current.MainWindow;
        //    win.ShowDialog();            
        //}

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Save(PartTypes.SelectedItem as Part);
        }

        private void PartTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Save(PartTypes.SelectedItem as Part);
        }
    }
}
