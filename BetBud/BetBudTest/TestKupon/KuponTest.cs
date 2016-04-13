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

        private List<Kamp> _kampe = new List<Kamp>();

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

            _kampe.Add(kamp1);
            _kampe.Add(kamp2);

        }
        [Test]

        public void TilføjKampTest()
        {
            //Arrange
            Kupon kupon = new Kupon();

            //Act
            kupon.TilføjKamp(_kampe.First(), true, false, false);

            //Assert
            IDelKamp dk = kupon.DelKampe.First();
            Assert.AreEqual(_kampe.First(), dk.Kampe);
        }
    }





}



