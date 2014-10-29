using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIInspection.Models;
using ISIInspection.MieTrak;

namespace ISIInspection
{
    public class ISIInspectionEngine
    {
        public MieTrakConnectionManager dbMieTrak = new MieTrakConnectionManager("");
        public InspectionContext db = new InspectionContext();

        public bool IsUserLoggedIn { get { return !(CurrentUser == null); } }
        public string CurrentUserName 
        { 
            get 
            {
                if (IsUserLoggedIn)
                    return CurrentUser.Name;
                return "";
            } 
        }
        public Guid CurrentUser { get; set; }

        public bool IsWorkOrderOpened { get { return !(CurrentWorkOrder== null); } }
        public string CurrentWorkOrderName
        {
            get
            {
                if (IsWorkOrderOpened)
                    return CurrentWorkOrder.OrderNumber;
                return "";
            }
        }        
        public Guid CurrentWorkOrder { get; set; }
        public event EventHandler WorkOrderChanged;
        protected virtual void OnWorkOrderChanged(EventArgs e)
        {
            if (WorkOrderChanged != null)
                WorkOrderChanged(this, e);
        }

        public void LogIn(Guid User)
        {
            CurrentUser = User;
        }

        public void LogOut()
        {
            CurrentUser = new Guid();
        }

        public void OpenWorkOrder(Guid workOrder)
        {
            CurrentWorkOrder = workOrder;
            OnWorkOrderChanged(new EventArgs());
        }

        public void CloseWorkOrder()
        {
            CurrentWorkOrder = new Guid();
            OnWorkOrderChanged(new EventArgs());
        }

        public List<PartMeasurementActual> GetMeasurementsForPart(Guid part)
        {
            return db.MeasurementActual.ToList().Where(x => x.PartRanId == part).ToList();
        }

        public List<PartMeasurementSP> GetSetPointsForPart(Guid part)
        {
            return db.MeasurementSetpoints.ToList().Where(x => x.RouterId == part).ToList();
        }

        public List<object> GetUsers()
        {
            return null;
        }

        public List<object> GetWorkOrders()
        {
            return null;
        }

        public List<object> GetPartys()
        {
            return null;
        }

        public bool AddMeasurement(PartMeasurementActual measurement)
        {
            db.MeasurementActual.Add(measurement);
            db.SaveChanges();
            return true;
        }

        public bool AddSetPoint(PartMeasurementSP measurement)
        {
            db.MeasurementSetpoints.Add(measurement);
            db.SaveChanges();
            return true;
        }

        public bool UpdateMeasurement(PartMeasurementActual measurement)
        {
            //db.MeasurementActual.Add(measurement);
            //db.SaveChanges();
            return true;
        }

        public bool UpdateSetPoint(PartMeasurementSP measurement)
        {
            //db.MeasurementSetpoints.Add(measurement);
            //db.SaveChanges();
            return true;
        }
    }
}
