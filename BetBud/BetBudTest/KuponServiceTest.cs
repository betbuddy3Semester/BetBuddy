using BetBudTest.ServiceReference1;
using ModelLibrary.Kupon;
using NUnit.Core;
using NUnit.Framework;

namespace BetBudTest
{
    /// <summary>
    ///     Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class KuponServiceTest
    {
        private readonly ServicesClient BSR = new ServicesClient();

        [Test]
        public void testFjernKamp()
        {
            //Arrange
            double OddsAssertion = 1;
            var id = 1;
            var testKamp = BSR.FindKamp(id);
            var kupon = new Kupon();
            var et = true;
            var x = false;
            var to = false;

            //Act
            kupon = BSR.TilføjKamp(kupon, testKamp, et, x, to);
            kupon.FjernKamp(testKamp);


            //Assert
            NUnitFramework.Assert.AreEqual(OddsAssertion, kupon.OddsUdregning());
        }

        [Test]
        public void testOddsGevinst()

        {
            //Arrange

            double gevinst = 2700;

            var id = 1;
            var testKamp1 = BSR.FindKamp(id);
            var et = true;
            var x = false;
            var to = false;

            var id2 = 2;
            var testKamp2 = BSR.FindKamp(id2);
            var eet = false;
            var xx = false;
            var too = true;

            var kupon = new Kupon();
            kupon.Point = 100;
            //Act
            kupon = BSR.TilføjKamp(kupon, testKamp1, et, x, to);
            kupon = BSR.TilføjKamp(kupon, testKamp2, eet, xx, too);


            //Assert
            NUnitFramework.Assert.AreEqual(gevinst, kupon.MuligGevist());
        }

        [Test]
        public void testTilføjKamp()
        {
            //Arrange
            double OddsAssertion = 2;
            var id = 1;
            var testKamp = BSR.FindKamp(id);
            var kupon = new Kupon();
            var et = true;
            var x = false;
            var to = false;

            //Act
            kupon = BSR.TilføjKamp(kupon, testKamp, et, x, to);
            // Sikrer imod duplicates.
            kupon = BSR.TilføjKamp(kupon, testKamp, et, x, to);


            //Assert
            NUnitFramework.Assert.AreEqual(OddsAssertion, kupon.OddsUdregning());
        }
    }
}