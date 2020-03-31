using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace TwoBottlesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(3, 5, 1, 4)]
        [DataRow(3, 5, 2, 10)]
        [DataRow(3, 5, 3, 1)]
        [DataRow(3, 5, 4, 8)]
        [DataRow(3, 5, 5, 4)]
        public void TestPourFromSmallToBigBottle(int startBottle, int destinationBottle, int soughtLitres, int shortestWay)
        {
            var shortestWayToSoughtLitres = TwoBottles.Program.Pour(startBottle, destinationBottle, soughtLitres);

            Assert.AreEqual(shortestWay, shortestWayToSoughtLitres);
        }

        [TestMethod]
        [DataRow(5, 3, 1, 8)]
        [DataRow(5, 3, 2, 2)]
        [DataRow(5, 3, 3, 2)]
        [DataRow(5, 3, 4, 6)]
        [DataRow(5, 3, 5, 1)]
        public void TestPourFromBigToSmallBottle(int startBottle, int destinationBottle, int soughtLitres, int shortestWay)
        {
            var shortestWayToSoughtLitres = TwoBottles.Program.Pour(startBottle, destinationBottle, soughtLitres);

            Assert.AreEqual(shortestWay, shortestWayToSoughtLitres);
        }
    }
}
