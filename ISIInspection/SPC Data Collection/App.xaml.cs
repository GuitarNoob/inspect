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

        public void ImportPlan(InspectionPlan ip, bool useSelectedWorkOrder = true)
        {
            if (useSelectedWorkOrder)
            {
                if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
                {
                    MessageBox.Show("No Work Order is currently selected.",
                        "No Work Order selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                ip.RouterFK = App.Engine.InspectionPlanMgr.SelectedWorkOrder.RouterFK ?? -1;
            }

            var ipOriginal = App.Engine.Database.isiEngine.InspectionDb.InspectionPlans.Find(ip.InspectionPlanId);
            if (ipOriginal != null)
                throw new Exception("Inspection plan id exists!");
            else
                App.Engine.Database.isiEngine.InspectionDb.InspectionPlans.Add(ip);

            //NOTE: these will automatically be added when adding the inspection plan in the code above
            foreach (PartMeasurementSP newSetpoint in ip.MeasurementCriteria)
            {
                //just double check they are there and add them if they are not in the database
                var spOriginal = App.Engine.Database.isiEngine.InspectionDb.MeasurementSetpoints.Find(newSetpoint.PartMeasurementSPId);
                if (spOriginal == null)
                    App.Engine.Database.isiEngine.InspectionDb.MeasurementSetpoints.Add(newSetpoint);
            }

            App.Engine.Database.isiEngine.InspectionDb.SaveChanges();
            (App.Current.MainWindow as MainWindow).ReloadUI();
        }

        public void CreatePlan()
        {
            if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
            {
                MessageBox.Show("No Work Order is currently selected.",
                    "No Work Order selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CreatePlan createPlan = null;
            createPlan = new CreatePlan(App.Engine.InspectionPlanMgr.SelectedWorkOrder);

            createPlan.Owner = App.Current.MainWindow;
            createPlan.ShowDialog();
            (App.Current.MainWindow as MainWindow).ReloadUI();
        }

        public void EditPlan()
        {
            if (App.Engine.InspectionPlanMgr.SelectedWorkOrder == null)
            {
                MessageBox.Show("No Work Order is currently selected.",
                    "No Work Order selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CreatePlan createPlan = null;

            if (App.Engine.InspectionPlanMgr.SelectedIP == null)
            {
                MessageBox.Show("No Inspection Plan is currently selected.",
                    "No Inspection Plan selected!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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

        //public List<WorkOrder> SearchForPlanID(long search)
        //{
        //    //List<InspectionPlan> ip = App.Engine.Database.isiEngine.InspectionDb.InspectionPlans.Where(x => x.InspectionPlanKey == search).ToList();
        //    //ip[0].RouterFK
        //    //return App.Engine.Database.mietrakConn.mietrakDb.WorkOrders.Where(x => x.IP.Contains(search)).ToList();
        //}

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

        public void ShowWorkOrderReport()
        {
            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(false, MieTrakWrapper.Reports.WorkOrderReportSort.WorkOrderSort, MieTrakWrapper.Reports.WorkOrderReportFilter.NoFilter);
            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }

        public void ShowWorkOrderReportDetailed()
        {

            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(true, MieTrakWrapper.Reports.WorkOrderReportSort.WorkOrderSort, MieTrakWrapper.Reports.WorkOrderReportFilter.NoFilter);
            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }

        public void ShowWorkOrderReportSalesOrder()
        {
            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(false, MieTrakWrapper.Reports.WorkOrderReportSort.SalesOrderSort, MieTrakWrapper.Reports.WorkOrderReportFilter.NoFilter);
            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }

        public void ShowWorkOrderReportAssemblyDeburr()
        {
            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(false, MieTrakWrapper.Reports.WorkOrderReportSort.WorkOrderSort, MieTrakWrapper.Reports.WorkOrderReportFilter.AssemblyDeburr);
            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }

        public void ShowWorkOrderReportShippingReceiving()
        {
            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(false, MieTrakWrapper.Reports.WorkOrderReportSort.WorkOrderSort, MieTrakWrapper.Reports.WorkOrderReportFilter.Shipping);
            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }

        public void ShowWorkOrderReportMillLathe()
        {
            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(false, MieTrakWrapper.Reports.WorkOrderReportSort.WorkOrderSort, MieTrakWrapper.Reports.WorkOrderReportFilter.MillLathe);
            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }
    }
}
