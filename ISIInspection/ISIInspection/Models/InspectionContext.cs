﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class InspectionContext : DbContext
    {
        public InspectionContext()
            : base()
        { }

        public InspectionContext(string connectionName)
            : base("name=" + connectionName)
        { }

        public DbSet<MeasurementComment> MeasurementComments { get; set; }
        public DbSet<PartMeasurementSP> MeasurementSetpoints { get; set; }
        public DbSet<PartMeasurementActual> MeasurementActual { get; set; }        
    }
}
