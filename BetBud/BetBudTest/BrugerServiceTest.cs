using BetBudTest.ServiceReference1;
using ModelLibrary.Bruger;
using NUnit.Framework;

namespace BetBudTest
{
    [TestFixture]
    internal class BrugerServiceTest

    {
        private readonly ServicesClient BSR = new ServicesClient();

        [Test]
        public void opdaterBrugerTest()
        {
            //Arrange
            var bruger = new Bruger();


            //Act 
            bruger.BrugerNavn = "LuderLaila";
            bruger.Email = "lailasmås@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            var b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("LuderLaila", b.BrugerNavn);

            b.BrugerNavn = "JULIE HAR IKKE BUKSER I HÅRET";
            b.Email = "BUKSiHÅR@hehe.fu";
            BSR.opdaterBruger(b);

            var b2 = BSR.getBrugerEfterBrugernavn("JULIE HAR IKKE BUKSER I HÅRET");
            Assert.AreEqual("JULIE HAR IKKE BUKSER I HÅRET", b2.BrugerNavn);
            Assert.AreEqual("BUKSiHÅR@hehe.fu", b2.Email);
            BSR.sletBruger(b.BrugerId);
        }

        /// <summary>
        ///     Testen er afhængig af, at servicen manuelt bliver startet, den kan ikke åbne servicen selv
        /// </summary>
        [Test]
        public void opretBrugerTest()
        {
            //Arrange
            var bruger = new Bruger();


            //Act 
            bruger.BrugerNavn = "Laila";
            bruger.Email = "lailasmaabjerggaard@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            var b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("Laila", b.BrugerNavn);
            BSR.sletBruger(b.BrugerId);
        }

        [Test]
        public void sletBrugerTest()
        {
            //Arrange
            var bruger = new Bruger();


            //Act 
            bruger.BrugerNavn = "Hans Testies";
            bruger.Email = "Testies@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            var b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("Hans Testies", b.BrugerNavn);
            BSR.sletBruger(b.BrugerId);
        }
    }
}