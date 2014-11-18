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
    }
}
