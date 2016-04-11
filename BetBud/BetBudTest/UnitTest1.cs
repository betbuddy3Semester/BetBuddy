using NUnit.Framework;

namespace BetBudTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //Arrange
            var one = 1;
            var two = 2;

            //Act
            var resul = one + two;

            //Assure
            Assert.AreEqual(resul, 3);
        }
    }
}
