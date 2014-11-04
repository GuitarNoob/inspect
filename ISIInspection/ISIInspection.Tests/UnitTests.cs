using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase]
        public void AddTest()
        {
            ISIInspectionEngine isiEngine = new ISIInspectionEngine();

            isiEngine.GetMeasurements();
            isiEngine.AddMeasurement(new Models.PartMeasurementActual() { });
            //int result = helper.Add(20, 10);
            //Assert.AreEqual(30, result);
        }
    }
}
