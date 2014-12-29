using System;
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
            : base("name=INSPECTIONEntities")
        {            
            Database.SetInitializer<InspectionContext>(new CreateDatabaseIfNotExists<InspectionContext>());
        }

        public DbSet<FabricatedPart> FabricatedParts { get; set; }
        public DbSet<InspectionPlan> InspectionPlans { get; set; }        
        public DbSet<MeasurementComment> MeasurementComments { get; set; }
        public DbSet<PartMeasurementSP> MeasurementSetpoints { get; set; }
        public DbSet<PartMeasurementActual> MeasurementActual { get; set; }
        public DbSet<Calibration> DeviceCalibration { get; set; }
        public DbSet<DefaultTolerance> Tolerances { get; set; }
    }
}
