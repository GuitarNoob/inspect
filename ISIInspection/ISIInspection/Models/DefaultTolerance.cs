using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Models
{
    public class DefaultTolerance
    {
        public Guid DefaultToleranceId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int UnitType { get; set; }
    }
}
