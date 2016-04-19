using ModelLibrary.Bruger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFBetBuddy;

namespace BetBudTest
{
    [TestFixture]
    class BrugerServiceTest

    {

        BrugerServiceRef.BrugerServiceClient BSR = new BrugerServiceRef.BrugerServiceClient();

        /// <summary>
        ///  Testen er afhængig at servicen manuelt bliver startet, den kan ikke åbne servicen selv 
        /// </summary>
        [Test]
        public void opretBrugerTest()
        {
            //Arrange
            Bruger bruger = new Bruger();
            

            //Act 
            bruger.BrugerNavn = "LuderLaila";
            bruger.Email ="lailasmås@hehe.fu";
            BSR.opretBruger(bruger);

            //Assert
            Bruger b = BSR.getBrugerEfterBrugernavn(bruger.BrugerNavn);
            Assert.AreEqual("LuderLaila", b.BrugerNavn);
            BSR.sletBruger(b.BrugerId);
        }
    }
}
