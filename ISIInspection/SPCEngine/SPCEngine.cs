using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCEngine
{
    public class SPCEngine
    {
        public SPCDatabaseManager Database { get; set; }
        public SPCInspectionManager InspectionPlanMgr { get; set; }
        public SPCDefaultTolerance DefaultTolerances { get; set; }

        private MieTrakWrapper.MieTrak.User m_CurrentUser;
        public MieTrakWrapper.MieTrak.User CurrentUser
        {
            get { return m_CurrentUser; }
            private set
            {
                if (m_CurrentUser != value)
                {
                    m_CurrentUser = value;
                    UserChanged(null, new EventArgs());
                }
            }
        }

        public void LogonUser(MieTrakWrapper.MieTrak.User user)
        {
            CurrentUser = user;
        }

        public string GetUserDisplayName(MieTrakWrapper.MieTrak.User user)
        {
            return user.FirstName + " " + user.LastName;
        }

        public event EventHandler UserChanged;

        public SPCEngine()
        {
            Database = new SPCDatabaseManager(this);
            InspectionPlanMgr = new SPCInspectionManager(this);
            DefaultTolerances = new SPCDefaultTolerance(this);
        }

    }
}
