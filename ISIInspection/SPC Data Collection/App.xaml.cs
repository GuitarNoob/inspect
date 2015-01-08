using ISIInspection.Models;
using MieTrakWrapper.MieTrak;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SPCEngine.SPCEngine Engine = new SPCEngine.SPCEngine();

        public static App Current { get { return (App)Application.Current; } }

        public void CreateEditPlan()
        {
            if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
            {
                MessageBox.Show("No Work Order is currently selected.",
                    "No Work Order selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CreatePlan createPlan = null;

            if (App.Engine.InspectionPlanMgr.SelectedIP == null)
                createPlan = new CreatePlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder);
            else
                createPlan = new CreatePlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder, App.Engine.InspectionPlanMgr.SelectedIP);

            createPlan.Owner = App.Current.MainWindow;
            createPlan.ShowDialog();
            (App.Current.MainWindow as MainWindow).ReloadUI();
        }

        public void CollectDataFromCurrentIP()
        {
            CheckInspectionPlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder, App.Engine.InspectionPlanMgr.SelectedIP);
            App.Engine.InspectionPlanMgr.ReloadInspectionPlan();
            CollectDataWindow win = new CollectDataWindow(App.Engine.InspectionPlanMgr.SelectedWorkOrder, App.Engine.InspectionPlanMgr.SelectedIP);
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
        }

        public void EditCalibration()
        {
            Calibration win = new Calibration();
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
        }

        public void EditDefaultTolerances()
        {
            Tolerances win = new Tolerances();
            win.Owner = App.Current.MainWindow;
            win.ShowDialog();
        }

        public List<WorkOrder> SearchForWorkOrder(string search)
        {
            return App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.Where(x => x.WorkOrderNumber.Contains(search)).ToList();
        }

        public List<WorkOrder> SearchForPartNumber(string search)
        {
            return App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.Where(x => x.PartNumber.Contains(search)).ToList();
        }

        public List<WorkOrder> GetAllWorkOrders()
        {
            return App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.ToList();
        }

        private void CheckInspectionPlan(WorkOrder wo, InspectionPlan iplan)
        {
            if (iplan == null)
                return;

            int sampleSize = 0;

            if (iplan.Type == "FAI")
                sampleSize = iplan.FAIQuantity;
            else
                sampleSize = iplan.SampleSize;

            if (sampleSize == 0)
            {
                if (MessageBox.Show("The sample size is 0! The Inspection Plan may have an error. Do you want to continue?", "Error",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                    return;
            }

            foreach (PartMeasurementSP sp in iplan.MeasurementCriteria)
            {
                if (sp.Measurements != null)
                {
                    if (sp.Measurements.Count != (sampleSize) && sp.Measurements.Count != 0)
                    {
                        if (MessageBox.Show("Error sample size does not match! The Inspection Plan has been mofied and the results no longer match!" +
                         " Would you like to attempt a merge? (Warning: a merge may result in a loss of saved data)", "Error Inspection Plan has been modified!",
                         MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            if (sp.Measurements.Count > (sampleSize))
                            {
                                int numToRemove = sp.Measurements.Count - sampleSize;
                                RemoveMeasurementSP(sp, numToRemove);
                            }
                            else
                            {
                                int numToAdd = sampleSize - sp.Measurements.Count;
                                AddMeasurementForSP(sp, numToAdd);
                            }
                        }
                    }
                }

                if (sp.Measurements == null || sp.Measurements.Count == 0)
                {
                    AddMeasurementForSP(sp, sampleSize);
                }
            }

            App.Engine.Database.isiEngine.InspectionDb.SaveChanges();
        }

        private void RemoveMeasurementSP(PartMeasurementSP sp, int measurementsToRemove)
        {
            List<PartMeasurementActual> measurements = new List<PartMeasurementActual>();
            for (int i = 0; i < measurementsToRemove; i++)
            {
                measurements.Add(sp.Measurements[((sp.Measurements.Count - 1) - i)]);
            }

            foreach (PartMeasurementActual measurement in measurements)
            {
                App.Engine.Database.isiEngine.InspectionDb.MeasurementActual.Remove(measurement);
            }
        }

        private void AddMeasurementForSP(PartMeasurementSP sp, int measurementsToAdd)
        {
            for (int i = 0; i < measurementsToAdd; i++)
            {
                PartMeasurementActual measurement = new PartMeasurementActual();
                measurement.PartMeasurementActualId = Guid.NewGuid();
                measurement.PartMeasurementSPId = sp.PartMeasurementSPId;
                measurement.CompletedTime = new DateTime(1975, 1, 1);
                App.Engine.Database.isiEngine.InspectionDb.MeasurementActual.Add(measurement);
            }
        }
    }
}
