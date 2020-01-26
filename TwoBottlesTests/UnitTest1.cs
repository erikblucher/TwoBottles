using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

        [TestMethod]
        [DataRow(2, 5, 2)]
        [DataRow(5, 2, 2)]
        public void TestShortestMoves(int firstNumber, int secondNumber, int smallestNumber)
        {
            Assert.AreEqual(smallestNumber, TwoBottles.Program.ShortestMoves(new List<int>() { firstNumber, secondNumber }));
        }

        [TestMethod]
        [DataRow(3, 5, 1, 4)]
        [DataRow(3, 5, 2, 2)]
        [DataRow(3, 5, 3, 1)]
        [DataRow(3, 5, 4, 6)]
        [DataRow(3, 5, 5, 1)]
        public void TestShortestWayTwoDirections(int smallBottle, int bigBottle, int soughtLitres, int shortestWay)
        {
            var shortestWayToSoughtLitresPourFromSmallToBig = TwoBottles.Program.Pour(smallBottle, bigBottle, soughtLitres);
            var shortestWayToSoughtLitresPourFromBigToSmall = TwoBottles.Program.Pour(bigBottle, smallBottle, soughtLitres);
            var shortestWayToSoughtLitres = TwoBottles.Program.ShortestMoves(new List<int>() { shortestWayToSoughtLitresPourFromSmallToBig, shortestWayToSoughtLitresPourFromBigToSmall });

            Assert.AreEqual(shortestWay, shortestWayToSoughtLitres);
        }
    }
}
