using BetBudTest.ServiceReference1;
using ModelLibrary.Models.Kupon;
using NUnit.Core;
using NUnit.Framework;

namespace BetBudTest {
    /// <summary>
    ///     Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class KuponServiceTest {
        private readonly ServicesClient BSR = new ServicesClient();

        [Test]
        public void testFjernKamp() {
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
            NUnitFramework.Assert.AreEqual(OddsAssertion, kupon.OddsUdregning());
        }

        [Test]
        public void testOddsGevinst() {
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
            NUnitFramework.Assert.AreEqual(gevinst, kupon.MuligGevist());
        }

        [Test]
        public void testTilføjKamp() {
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
            NUnitFramework.Assert.AreEqual(OddsAssertion, kupon.OddsUdregning());
        }
    }
}