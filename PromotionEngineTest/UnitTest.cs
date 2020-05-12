using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using Moq;

namespace PromotionEngineTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void WithDiscount()
        {
            //Arrange
            Mock<IDiscount> mock = new Mock<IDiscount>();
            mock.Setup(x => x.ADiscount).Returns(130);
            mock.Setup(x => x.BDiscount).Returns(45);
            mock.Setup(x => x.CDDiscount).Returns(30);

            //Act
            DiscountCalculator discountCalculator = new DiscountCalculator(mock.Object);
            int Total = discountCalculator.CalculateTotal(5, 5, 1, null);

            //Assert
            Assert.AreEqual(370, Total);
        }

        [TestMethod]
        public void WithOutDiscount()
        {
            //Arrange
            Mock<IDiscount> mock = new Mock<IDiscount>();
            mock.Setup(x => x.ADiscount).Returns(0);
            mock.Setup(x => x.BDiscount).Returns(0);
            mock.Setup(x => x.CDDiscount).Returns(0);

            //Act
            DiscountCalculator discountCalculator = new DiscountCalculator(mock.Object);
            int Total = discountCalculator.CalculateTotal(5, 5, 1, null);

            //Assert
            Assert.AreNotEqual(370, Total);
            Assert.AreEqual(150, Total);
        }
    }
}
