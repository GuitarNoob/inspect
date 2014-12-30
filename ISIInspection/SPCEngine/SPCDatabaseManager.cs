using ISIInspection.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCEngine
{
    public class SPCDatabaseManager
    {
        public ISIInspection.ISIInspectionEngine isiEngine = new ISIInspection.ISIInspectionEngine();
        public MieTrakWrapper.MieTrak.MieTrakConnectionManager mietrakConn = new MieTrakWrapper.MieTrak.MieTrakConnectionManager();

        private SPCEngine m_parent;

        public SPCDatabaseManager(SPCEngine parent)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InspectionContext, ISIInspection.Migrations.Configuration>());
            m_parent = parent;
        }
    }
}
