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
        public static ISIInspection.ISIInspectionEngine isiEngine = new ISIInspection.ISIInspectionEngine();
        public static MieTrakWrapper.MieTrak.MieTrakConnectionManager mietrakConn = new MieTrakWrapper.MieTrak.MieTrakConnectionManager();

        private static MieTrakWrapper.MieTrak.User m_CurrentUser;
        public static MieTrakWrapper.MieTrak.User CurrentUser
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

        public static void LogonUser(MieTrakWrapper.MieTrak.User user)
        {
            CurrentUser = user;
        }

        public static string GetUserDisplayName(MieTrakWrapper.MieTrak.User user)
        {
            return user.FirstName + " " + user.LastName;
        }

        public static event EventHandler UserChanged;
    }
}
