using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ModelLibrary.Kupon;


namespace BetBudTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class KuponServiceTest
    {
        ServiceReference1.ServicesClient BSR = new ServiceReference1.ServicesClient();

        public KuponServiceTest()
        {

        }

        [Test]
        public void testTilføjKamp()
        {
            //Arrange
            double OddsAssertion = 2;
            int id = 1;
            Kamp testKamp = BSR.FindKamp(id);
            Kupon kupon = new Kupon();
            bool et = true;
            bool x = false;
            bool to = false;

            //Act
            kupon = BSR.TilføjKamp(kupon, testKamp, et, x, to);
            // Sikrer imod duplicates.
            kupon = BSR.TilføjKamp(kupon, testKamp, et, x, to);



            //Assert
            NUnit.Core.NUnitFramework.Assert.AreEqual(OddsAssertion, kupon.OddsUdregning());
        }

        [Test]
        public void testFjernKamp()
        {
            //Arrange
            double OddsAssertion = 1;
            int id = 1;
            Kamp testKamp = BSR.FindKamp(id);
            Kupon kupon = new Kupon();
            bool et = true;
            bool x = false;
            bool to = false;

            //Act
            kupon = BSR.TilføjKamp(kupon, testKamp, et, x, to);
            kupon.FjernKamp(testKamp);



            //Assert
            NUnit.Core.NUnitFramework.Assert.AreEqual(OddsAssertion, kupon.OddsUdregning());


        }

        [Test]
        public void testOddsGevinst()

        {
            //Arrange
         
            double gevinst = 2700;

            int id = 1;
            Kamp testKamp1 = BSR.FindKamp(id);
            bool et = true;
            bool x = false;
            bool to = false;

            int id2 = 2;
            Kamp testKamp2 = BSR.FindKamp(id2);
            bool eet = false;
            bool xx = false;
            bool too = true;

            Kupon kupon = new Kupon();
            kupon.Point = 100;
            //Act
            kupon = BSR.TilføjKamp(kupon, testKamp1, et, x, to);
            kupon = BSR.TilføjKamp(kupon, testKamp2, eet, xx, too);
            

            //Assert
            NUnit.Core.NUnitFramework.Assert.AreEqual(gevinst, kupon.MuligGevist());

        }

    }
}