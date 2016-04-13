using ModelLibrary;
using ModelLibrary.Bruger;
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
            Bruger testBruger = new Bruger();
            // Act
            testBruger.Navn = "Bente";
            // Assert
            Assert.AreEqual("Bente", testBruger.Navn);
        }

        [Test]
        public void opretAliasTest()
        {
            // Arrange
            Bruger testBruger = new Bruger();
            // Act
            testBruger.Alias = "Bentemusen";
            // Assert
            Assert.AreEqual("Bentemusen", testBruger.Alias);
        }
        [Test]
        public void opretBrugerNavnTest()
        {
            // Arrange
            Bruger testBruger = new Bruger();
            // Act
            testBruger.BrugerNavn = "Bentemuzzen";
            // Assert
            Assert.AreEqual("Bentemuzzen", testBruger.BrugerNavn);
        }
        [Test]
        public void opretEmailTest()
        {
            // Arrange
            Bruger testBruger = new Bruger();
            // Act
            testBruger.Email = "Bentemuzzen@pølsemail.nu";
            // Assert
            Assert.AreEqual("Bentemuzzen@pølsemail.nu", testBruger.Email);
        }
    }
}
