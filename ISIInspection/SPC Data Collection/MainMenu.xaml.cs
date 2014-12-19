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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            App.Engine.LogonUser(null);
        }

        private void PlanNew_Click(object sender, RoutedEventArgs e)
        {
            App.Current.CreateEditPlan();
        }

        private void PlanEdit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.CreateEditPlan();
        }

        private void PlanCollect_Click(object sender, RoutedEventArgs e)
        {
            App.Current.CollectDataFromCurrentIP();
        }        
    }
}
