﻿using System;
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_DragLeave(object sender, DragEventArgs e)
        {

        }

        private void TextBox_Initialized(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
