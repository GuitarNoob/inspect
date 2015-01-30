using ISIInspection.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SPCEngine.ImportExport
{
    public class InspectionPlanExporter
    {
        public static void ExportIP(InspectionPlan ip, string outputPath)
        {            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, ip);
            stream.Close();
        }
    }
}
