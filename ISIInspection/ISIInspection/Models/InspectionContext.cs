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
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Part> PartInformation { get; set; }
        public DbSet<PartMeasurementSP> MeasurementSetpoints { get; set; }
        public DbSet<PartMeasurementActual> MeasurementActual { get; set; }
        //public DbSet<RanPart> PartsCreated { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<WorkOrder> WorkOrders { get; set; } 
    }
}
