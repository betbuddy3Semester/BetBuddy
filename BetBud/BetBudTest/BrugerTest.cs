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
        public void opretNavnTest(BrugerInterfaceTest testBruger)
        {
            // Assert
            Assert.AreEqual("Bente", testBruger.Navn);
        }
        [Test]
        public void opretAliasTest(BrugerInterfaceTest testBruger)
        {
            // Assert
            Assert.AreEqual("Bentemusen", testBruger.Alias);
        }
        [Test]
        public void opretBrugerNavnTest(BrugerInterfaceTest testBruger)
        {
            // Assert
            Assert.AreEqual("Bentemuzzen", testBruger.BrugerNavn);
        }
        [Test]
        public void opretEmailTest(BrugerInterfaceTest testBruger)
        {
            // Assert
            Assert.AreEqual("Bentemuzzen@pølsemail.nu", testBruger.Email);
        }
    }
}
