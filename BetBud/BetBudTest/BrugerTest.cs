using ModelLibrary;
using ModelLibrary.Interface_Bruger;
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
            BrugerInterfaceTest b = new BrugerInterfaceTest();
            
            // Act
            
            //Assert
            Assert.AreEqual("Bente", b.Navn);
           
    
        }
    }
}
