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
            b.Navn = "Bente";
            // Assert
            Assert.AreEqual("Bente", b.Navn);
        }

        [Test]
        public void opretAliasTest()
        {
            // Arrange
            BrugerInterfaceTest b = new BrugerInterfaceTest();
            // Act
            b.Alias = "Bentemusen";
            // Assert
            Assert.AreEqual("Bentemusen", b.Alias);
        }
        [Test]
        public void opretBrugerNavnTest()
        {
            // Arrange
            BrugerInterfaceTest b = new BrugerInterfaceTest();
            // Act
            b.BrugerNavn = "Bentemuzzen";
            // Assert
            Assert.AreEqual("Bentemuzzen", b.BrugerNavn);
        }
        [Test]
        public void opretEmailTest()
        {
            // Arrange
            BrugerInterfaceTest b = new BrugerInterfaceTest();
            // Act
            b.Email = "Bentemuzzen@pølsemail.nu";
            // Assert
            Assert.AreEqual("Bentemuzzen@pølsemail.nu", b.Email);
        }
    }
}
