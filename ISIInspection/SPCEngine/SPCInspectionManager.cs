using ISIInspection.Models;
using MieTrakWrapper.MieTrak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCEngine
{
    public class SPCInspectionManager
    {
        public event EventHandler WorkOrderChanged;

        private WorkOrder selectedWO;
        public WorkOrder SelectedWorkOrder
        {
            get { return selectedWO; }
            private set 
            {
                if (selectedWO != value)
                {
                    selectedWO = value;
                    WorkOrderChanged(this, new EventArgs());
                }
            }
        }
        private InspectionPlan selectedInspectionPlan;
        public InspectionPlan SelectedIP
        {
            get { return selectedInspectionPlan; }
            private set { selectedInspectionPlan = value; }
        }

        private SPCEngine m_parent;

        public SPCInspectionManager(SPCEngine parent)
        {
            m_parent = parent;
        }

        public void LoadWorkOrder(WorkOrder wo)
        {
            GetInspectionPlan(wo);
            SelectedWorkOrder = wo;
        }

        void GetInspectionPlan(WorkOrder wo)
        {
            //find the inspection plans with this router
            List<InspectionPlan> iPlans = m_parent.Database.isiEngine.InspectionDb.InspectionPlans.Where(x => x.RouterFK == wo.RouterFK).ToList();
            if (iPlans.Count > 0)
                selectedInspectionPlan = iPlans[0];
            else
                selectedInspectionPlan = null;
        }

        public void ReloadInspectionPlan()
        {
            GetInspectionPlan(selectedWO);
        }
    }
}
