using System;
using System.Collections.Generic;
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
            m_parent = parent;
        }
    }
}
