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
            Assert.IsNotNull(b);
            Assert.AreEqual("Jens", b.Navn);
        }

        [Test]
        public void opretBrugerNavnTest()
        {

            // Arrange
            Bruger b = new Bruger();
            string BrugerNavn = "Jens lyn";
            // Act
            b.brugerNavn = BrugerNavn;
            //Assert
            Assert.AreEqual("Jens lyn", b.brugerNavn); 
        
        }

        [Test]
        public void opretEmailTest()
        {
            //Arrange
            Bruger b = new Bruger();
            String Email = "jenslyn@gmail.com";

            //Act
            b.email = Email;

            //Assert
            Assert.AreEqual("jenslyn@gmail.com", b.email);

        }

        [Test]
        public void OpretAliasTest()
        {
            //Arrange
            Bruger b = new Bruger();
            string Alias = "JenziBoy";

            //Act
            b.alias = Alias;

            //Assert
            Assert.AreEqual("JenziBoy", b.alias);
        }
    }
}
