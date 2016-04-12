using NUnit.Framework;

namespace BetBudTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CreateCat()
        {
            //Arrange
            var Name = "Cat";
            var cat = new Cat();

            //Act
            cat.catName = Name;

            //Assert
            Assert.AreEqual(cat.catName, "Cat");
        }

        [Test]
        public void TestMethod1()
        {
            //Arrange
            var one = 1;
            var two = 2;
            var three = 3;

            //Act
            var resul = one + two + three;

            //Assure
            Assert.AreEqual(resul, 6);
        }
    }
}