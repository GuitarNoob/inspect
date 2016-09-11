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

        string queryString = @"SELECT TOP 1000
          workorder.WorkOrderPK as 'Work Order'
         ,cust.Name as 'Customer'
              ,workorder.QuantityRequired as 'Qty To Fab'
         ,workorder.PartNumber as 'Part Number'
         ,workorder.ItemDescription 'Description'
         ,op.Name as 'Operation'
              ,wc.Description AS 'Work Center'
         ,assem.OutsideProcessingDescription as 'Finish'
              ,assem.SetupTime as 'Setup Time'
              ,assem.MinutesPerPart as 'Run Time'
         ,assem.TargetDueDate as 'Op Complete Date'
         ,workorder.CustomerOnDockDate 'Due Date'
         ,assem.DaysOut as 'Days Out'
         ,assem.WorkOrderAssemblyPK as 'AssemblyPK'
         ,woJob.SalesOrderFK as 'Sales Order'
,assem.WorkOrderAssemblyLaborStatusFK as 'WorkOrderStatus'
                --,assem.WorkOrderAssemblyLaborStatusFK
                --,workorder.WorkOrderStatusFK
 
  FROM [MIETRAK].[dbo].[WorkOrder] workorder
   
  inner join [MIETRAK].[dbo].[WorkOrderAssembly] assem
  on assem.WorkOrderFK = workorder.WorkOrderPK 
 
  inner join [MIETRAK].[dbo].[Operation] op
  on assem.OperationFK = op.OperationPK  
 
  inner join [MIETRAK].[dbo].[Party] cust
  on workorder.CustomerFK = cust.PartyPK
 
  inner join [MIETRAK].[dbo].[WorkCenter] wc
  on assem.WorkCenterFK = wc.WorkCenterPK
 
  inner join [MIETRAK].[dbo].[WorkOrderJob] woJob
  on woJob.WorkOrderFK = workorder.WorkOrderPK

  WHERE
  workorder.WorkOrderStatusFK = 2
  --AND
  --assem.WorkOrderAssemblyLaborStatusFK = 1
 
  ORDER BY workorder.CustomerOnDockDate, workorder.PartNumber";

        public void ShowWorkOrderReport()
        {
            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(queryString);

            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }

        public void ShowWorkOrderReportDetailed()
        {            

            Reports.WorkOrderReport workOrderReport = null;
            workOrderReport = new Reports.WorkOrderReport(queryString, true);

            workOrderReport.Owner = App.Current.MainWindow;
            workOrderReport.ShowDialog();
        }
    }
}
