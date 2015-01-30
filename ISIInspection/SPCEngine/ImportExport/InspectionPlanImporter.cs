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
    public class InspectionPlanImporter
    {
        public static InspectionPlan ImportIP(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            InspectionPlan obj = (InspectionPlan)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

        public static bool CreateNewGuids(InspectionPlan ip, bool createNewMeasurementIds = true)
        {
            ip.InspectionPlanId = Guid.NewGuid();
            ip.InspectionPlanKey = 0; //this is database generated
            ip.MeasurementCriteria.ForEach(x => x.InspectionPlanId = ip.InspectionPlanId);

            if (createNewMeasurementIds)
                ip.MeasurementCriteria.ForEach(x => x.PartMeasurementSPId = Guid.NewGuid());

            return true;
        }
    }
}
