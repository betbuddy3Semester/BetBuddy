using ModelLibrary.Bruger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetBudTest
{
    [TestFixture]
    class BrugerServiceTest

    {
        ServiceReference1.ServicesClient BSR = new ServiceReference1.ServicesClient();

        /// <summary>
        ///  Testen er afhængig af, at servicen manuelt bliver startet, den kan ikke åbne servicen selv 
        /// </summary>
        [Test]
        public void opretBrugerTest()
        {
            //Arrange
            Bruger bruger = new Bruger();


            //Act 
            bruger.BrugerNavn = "Laila";
            bruger.Email = "lailasmaabjerggaard@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            Bruger b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("Laila", b.BrugerNavn);
            BSR.sletBruger(b.BrugerId);
        }

        [Test]
        public void sletBrugerTest()
        {
            //Arrange
            Bruger bruger = new Bruger();


            //Act 
            bruger.BrugerNavn = "Hans Testies";
            bruger.Email = "Testies@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            Bruger b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("Hans Testies", b.BrugerNavn);
            BSR.sletBruger(b.BrugerId);
        }

        [Test]
        public void opdaterBrugerTest()
        {
            //Arrange
            Bruger bruger = new Bruger();


            //Act 
            bruger.BrugerNavn = "LuderLaila";
            bruger.Email = "lailasmås@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            Bruger b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("LuderLaila", b.BrugerNavn);

            b.BrugerNavn = "JULIE HAR IKKE BUKSER I HÅRET";
            b.Email = "BUKSiHÅR@hehe.fu";
            BSR.opdaterBruger(b);

            Bruger b2 = BSR.getBrugerEfterBrugernavn("JULIE HAR IKKE BUKSER I HÅRET");
            Assert.AreEqual("JULIE HAR IKKE BUKSER I HÅRET", b2.BrugerNavn);
            Assert.AreEqual("BUKSiHÅR@hehe.fu", b2.Email);
            BSR.sletBruger(b.BrugerId);
        }
    }
}