using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Metrics;
using UFA;
using UfaData;
using UfaService;
using UfaService.Model;
using Microsoft.OpenApi.Writers;
using System.Data.Entity;

namespace UfaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DbContextTest()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var points = db.Points?.ToList();
                var documents = db.Documents?.ToList();
                var primitives = db.Primitives?.ToList();
                
                Assert.IsNotNull(points);
                Assert.IsNotNull(documents);
                Assert.IsNotNull(primitives);

                Assert.IsTrue(points is List<Point>);
                Assert.IsTrue(documents is List<Document>);
                Assert.IsTrue(primitives is List<Primitive>);                
            }
        }
    }
}
