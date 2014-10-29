using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIInspection.Models;

namespace ISIInspection
{
    public class ISIInspectionEngine
    {
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
        public User CurrentUser { get; set; }

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
        public WorkOrder CurrentWorkOrder { get; set; }
        public event EventHandler WorkOrderChanged;
        protected virtual void OnWorkOrderChanged(EventArgs e)
        {
            if (WorkOrderChanged != null)
                WorkOrderChanged(this, e);
        }

        public void LogIn(User User)
        {
            CurrentUser = User;
        }

        public void LogOut()
        {
            CurrentUser = null;
        }

        public void OpenWorkOrder(WorkOrder workOrder)
        {
            CurrentWorkOrder = workOrder;
            OnWorkOrderChanged(new EventArgs());
        }

        public void CloseWorkOrder()
        {
            CurrentWorkOrder = null;
            OnWorkOrderChanged(new EventArgs());
        }
    }
}
