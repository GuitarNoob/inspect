using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class Calibration
    {
        public Guid CalibrationId { get; set; }
        public string SerialNumber { get; set; }
        public string ModelNumber { get; set; }
        public string Description { get; set; }
        public string Range { get; set; }
        public string Manufacturer { get; set; }
        public string Location { get; set; }
        public string Interval { get; set; }
        public string StandardNumber { get; set; }
        public string StandardName { get; set; }
        public string LastCalibrated { get; set; }
        public string NextCalibration { get; set; }
        public string CalibrationDate { get; set; }
        public string CalibratedBy { get; set; }
    }
}
