using ISIInspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCEngine
{
    public class SPCDefaultTolerance
    {
        private SPCEngine m_parent;

        public SPCDefaultTolerance(SPCEngine parent)
        {
            m_parent = parent;
        }

        public decimal GetDefaultTolerance(ToleranceType type, ToleranceUnits units)
        {
            int enumCompare = Convert.ToInt32(units);
            List<DefaultTolerance> tolerances = m_parent.Database.isiEngine.InspectionDb.Tolerances.Where(x => x.Name == type.ToString() && x.UnitType == enumCompare).ToList();    
            if (tolerances == null || tolerances.Count == 0)
            {
                return CreateNewTolerance(type, units).Value;
            }
            else
                return tolerances[0].Value;
        }

        public bool WriteTolerance(ToleranceType type, ToleranceUnits units, decimal value)
        {
            int enumCompare = Convert.ToInt32(units);
            List<DefaultTolerance> tolerances = m_parent.Database.isiEngine.InspectionDb.Tolerances.Where(x => x.Name == type.ToString() && x.UnitType == enumCompare).ToList();
            if (tolerances == null || tolerances.Count == 0)
            {
                return false;
            }
            
            tolerances[0].Value = value;
            m_parent.Database.isiEngine.InspectionDb.SaveChanges();
            return true;
        }

        private DefaultTolerance CreateNewTolerance(ToleranceType type, ToleranceUnits units)
        {
            DefaultTolerance defaultTolerance = new DefaultTolerance();
            defaultTolerance.Name = type.ToString();
            defaultTolerance.UnitType = Convert.ToInt32(units);
            defaultTolerance.Value = 1;
            defaultTolerance.DefaultToleranceId = Guid.NewGuid();
            m_parent.Database.isiEngine.InspectionDb.Tolerances.Add(defaultTolerance);
            m_parent.Database.isiEngine.InspectionDb.SaveChanges();
            return defaultTolerance;
        }
    }

    public enum ToleranceType
    {
        Unknown,
        X,
        X_X,
        X_XX,
        X_XXX,
        X_XXXX,
        Angular
    }

    public enum ToleranceUnits
    {
        Metric,
        Inch
    }
}
