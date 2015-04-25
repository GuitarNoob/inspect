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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionPlan>().Property(x => x.AQLPercentage).HasPrecision(16, 5);
            modelBuilder.Entity<DefaultTolerance>().Property(x => x.Value).HasPrecision(16, 5);
            modelBuilder.Entity<PartMeasurementSP>().Property(x => x.Requirement).HasPrecision(16, 5);
            modelBuilder.Entity<PartMeasurementSP>().Property(x => x.PlusTolerance).HasPrecision(16, 5);
            modelBuilder.Entity<PartMeasurementSP>().Property(x => x.MinusTolerance).HasPrecision(16, 5);
            modelBuilder.Entity<PartMeasurementActual>().Property(x => x.MeasuredValue).HasPrecision(16, 5);
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
