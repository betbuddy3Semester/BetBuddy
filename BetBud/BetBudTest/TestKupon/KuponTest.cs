using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using ModelLibrary.Kupon;
using NUnit.Framework;

namespace BetBudTest.TestKupon
{
    [TestFixture]

    public class KuponTest
    {

        private List<Kamp> kampe = new List<Kamp>();

        public KuponTest()
        {
            Kamp kamp1 = new Kamp()
            {
                HoldVsHold = "Liverpool - Man UTD",
                Odds1 = 1.33,
                OddsX = 3.2,
                Odds2 = 18.0,
                Vundet1 = false,
                VundetX = false,
                Vundet2 = false,
                KampStart = new DateTime(),
                Aflyst = false,
            };

            Kamp kamp2 = new Kamp()
            {
                HoldVsHold = "Chelsea - Norwich",
                Odds1 = 1.8,
                OddsX = 2.8,
                Odds2 = 3.5,
                Vundet1 = false,
                VundetX = false,
                Vundet2 = false,
                KampStart = new DateTime(),
                Aflyst = false,
            };

            kampe.Add(kamp1);
            kampe.Add(kamp2);

        }

        [Test]

        public void TilføjKampTest()
        {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.First(), true, false, false);

            //Assert
            IDelKamp dk = kupon.DelKampe.First();
            Assert.AreEqual(kampe.First(), dk.Kampe);
        }

        [Test]
        public void FjernKamp()
        {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.First(), false, false, true);
            kupon.FjernKamp(kampe.First());

            //Assert
            Assert.AreEqual(kupon.DelKampe.Count(), 0);
        }

        [Test]
        public void OddsUdregning()
        {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.ElementAt(0), false, true, false);
            kupon.TilføjKamp(kampe.ElementAt(1), true, false, false);

            //Assert
            Assert.AreEqual(kupon.OddsUdregning(), 5.76);
        }

        [Test]
        public void MuligGevist()
        {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.ElementAt(0), false, true, false);
            kupon.TilføjKamp(kampe.ElementAt(1), true, false, false);
            kupon.Point = 1000;

            //Assert
            Assert.AreEqual(kupon.MuligGevist(), 5760);

        }

        // AFVENT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [Test]
        public void BekræftKupon()
        {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(kampe.ElementAt(0), false, true, false);
            kupon.TilføjKamp(kampe.ElementAt(1), true, false, false);
            kupon.Point = 1000;

            //Assert
            //?????????????
        }

        [Test]
        public void KontrolAfKupon()
        {
            //Arrange
            //Act
            //Assert
        }

        [Test]
        public void Kontrolleret()
        {
            //Arrange
            //Act
            //Assert
        }

    }
}





}



