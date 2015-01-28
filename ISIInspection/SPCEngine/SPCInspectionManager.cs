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

        public void SetSelectedWorkOrder(WorkOrder wo)
        {
            SelectedIP = null;
            SelectedWorkOrder = wo;
        }

        public void LoadWorkOrderAndIp(WorkOrder wo, InspectionPlan ip)
        {
            LoadInspectionPlan(ip);
            SelectedWorkOrder = wo;
        }

        public List<InspectionPlan> GetInspectionPlan(WorkOrder wo)
        {
            if (wo == null)
                return null;
            //find the inspection plans with this router
            return m_parent.Database.isiEngine.InspectionDb.InspectionPlans.Where(x => x.RouterFK == wo.RouterFK).ToList();
        }

        public void LoadInspectionPlan(InspectionPlan ip)
        {
            selectedInspectionPlan = ip;
        }

        public void ReloadInspectionPlan()
        {
            GetInspectionPlan(selectedWO);
        }

    }
}
