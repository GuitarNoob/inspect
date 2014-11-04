﻿using System;
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
        public MieTrakConnectionManager MieTrakInspectionDb = new MieTrakConnectionManager(s);
        public InspectionContext InspectionDb = new InspectionContext();     

        public List<PartMeasurementActual> GetMeasurements()
        {
            return InspectionDb.MeasurementActual.ToList();
        }

        public List<PartMeasurementSP> GetSetPoints()
        {
            return InspectionDb.MeasurementSetpoints.ToList();
        }    

        public bool AddMeasurement(PartMeasurementActual measurement)
        {
            InspectionDb.MeasurementActual.Add(measurement);
            InspectionDb.SaveChanges();
            return true;
        }

        public bool AddSetPoint(PartMeasurementSP measurement)
        {
            InspectionDb.MeasurementSetpoints.Add(measurement);
            InspectionDb.SaveChanges();
            return true;
        }

        public bool UpdateMeasurement(PartMeasurementActual measurement)
        {
            PartMeasurementActual item = GetMeasurements().Find(x => x.PartMeasurementActualId == measurement.PartMeasurementActualId);
            if (item == null)
                return false;

            item.CompletedTime = measurement.CompletedTime;
            item.MeasuredValue = measurement.MeasuredValue;
            item.PartNumber = measurement.PartNumber;
            item.RouterId = measurement.RouterId;
            item.UserId = measurement.UserId;
            item.WorkOrderId = measurement.WorkOrderId;

            InspectionDb.SaveChanges();
            return true;
        }

        public bool UpdateSetPoint(PartMeasurementSP measurement)
        {
            PartMeasurementSP item = GetSetPoints().Find(x => x.PartMeasurementSPId == measurement.PartMeasurementSPId);
            if (item == null)
                return false;

            item.CharNumber = measurement.CharNumber;
            item.RefLocation = measurement.RefLocation;
            item.Requirement = measurement.Requirement;
            item.RouterId = measurement.RouterId;
            item.SetPoint = measurement.SetPoint;
            item.Tolerance = measurement.Tolerance;
            item.Units = measurement.Units;

            InspectionDb.SaveChanges();
            return true;
        }
    }
}
