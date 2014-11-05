using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MieTrakWrapper.MieTrak;

namespace ISIInspection.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase]
        public void AddTest()
        {
            ISIInspectionEngine isiEngine = new ISIInspectionEngine();

            //MieTrakConnectionManager mang = new MieTrakConnectionManager();
            //List<Router> routers = mang.GetRouters();
            
            //isiEngine.GetMeasurements();
            //isiEngine.AddMeasurement(new Models.PartMeasurementActual() { PartMeasurementActualId = new Guid(), FabricatedPartId = new Guid(), CompletedTime = DateTime.Now,PartMeasurementSPId = new Guid() });
            //int result = helper.Add(20, 10);
            //Assert.AreEqual(30, result);
        }
    }
}
