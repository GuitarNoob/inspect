using ISIInspection.Models;
using Microsoft.Win32;
using SPCEngine.ImportExport;
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
            App.Current.CreatePlan();
        }

        private void PlanEdit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.EditPlan();
        }

        private void PlanCollect_Click(object sender, RoutedEventArgs e)
        {
            App.Current.CollectDataFromCurrentIP();
        }

        private void DefaultTolerances_Click(object sender, RoutedEventArgs e)
        {
            App.Current.EditDefaultTolerances();
        }

        private void Calibration_Click(object sender, RoutedEventArgs e)
        {
            App.Current.EditCalibration();
        }

        private void PlanExport_Click(object sender, RoutedEventArgs e)
        {
            if (App.Engine.InspectionPlanMgr.SelectedIP == null)
            {
                MessageBox.Show("No Inspection Plan loaded! Select an Inspection Plan to export.");
                return;
            }

            SaveFileDialog win = new SaveFileDialog();
            win.Filter = "ISI Inspection Files (.isi)|*.isi|All Files (*.*)|*.*";
            if (win.ShowDialog() == true)
            {
                if (win.FileName != String.Empty)
                    InspectionPlanExporter.ExportIP(App.Engine.InspectionPlanMgr.SelectedIP, win.FileName);
            }
        }

        private void PlanImport_Click(object sender, RoutedEventArgs e)
        {
            if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
            {
                MessageBox.Show("No Work Order seleceted! Select a Work Order to import an inspection plan into.");
                return;
            }

            OpenFileDialog win = new OpenFileDialog();
            win.Filter = "ISI Inspection Files (.isi)|*.isi|All Files (*.*)|*.*";
            if (win.ShowDialog() == true)
            {
                if (win.FileName != String.Empty)
                {
                    InspectionPlan importIp = InspectionPlanImporter.ImportIP(win.FileName);
                    InspectionPlanImporter.CreateNewGuids(importIp);
                    App.Current.ImportPlan(importIp);
                }
            }
        }
    }
}
