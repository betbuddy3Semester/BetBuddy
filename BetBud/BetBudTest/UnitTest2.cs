using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetBudTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void opretBruger()
        {
            // Arrange
            Bruger b = new Bruger();
            String navn = "Jens";
            // Act
            b.Navn = navn;
            //Assert
            Assert.AreEqual("Jens", b.Navn);
        }
    }
}
