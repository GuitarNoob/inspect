using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIInspection.Models;
using ISIInspection.MieTrak;

namespace ISIInspection
{
    public class ISIInspectionEngine
    {
        public MieTrakConnectionManager dbMieTrak = new MieTrakConnectionManager("");
        public InspectionContext db = new InspectionContext();     

        public List<PartMeasurementActual> GetMeasurementsForPart()
        {
            return db.MeasurementActual.ToList();
        }

        public List<PartMeasurementSP> GetSetPointsForPart()
        {
            return db.MeasurementSetpoints.ToList();
        }

        public List<object> GetUsers()
        {
            return null;
        }

        public List<object> GetWorkOrders()
        {
            return null;
        }

        public List<object> GetPartys()
        {
            return null;
        }

        public bool AddMeasurement(PartMeasurementActual measurement)
        {
            db.MeasurementActual.Add(measurement);
            db.SaveChanges();
            return true;
        }

        public bool AddSetPoint(PartMeasurementSP measurement)
        {
            db.MeasurementSetpoints.Add(measurement);
            db.SaveChanges();
            return true;
        }

        public bool UpdateMeasurement(PartMeasurementActual measurement)
        {
            //db.MeasurementActual.Add(measurement);
            //db.SaveChanges();
            return true;
        }

        public bool UpdateSetPoint(PartMeasurementSP measurement)
        {
            //db.MeasurementSetpoints.Add(measurement);
            //db.SaveChanges();
            return true;
        }
    }
}
