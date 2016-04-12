using ModelLibrary;
using NUnit.Framework;
using System;

namespace BetBudTest
{
    [TestFixture]
    public class BrugerTest
    {
        [Test]
        public void opretNavnTest()
        {
            // Arrange
            Bruger b = new Bruger();
            string navn = "Jens";
            // Act
            b.Navn = navn;
            //Assert
            Assert.AreEqual("Jens", b.Navn);
        }
        [Test]
        public void opretNavnTest()
        {
            // Arrange
            Bruger b = new Bruger();
            string navn = "Jens";
            // Act
            b.Navn = navn;
            //Assert
            Assert.AreEqual("Jens", b.Navn);
        }
    }
}
