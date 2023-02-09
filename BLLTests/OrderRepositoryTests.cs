using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BL;
namespace BLTests
{
    [TestClass]
    public class OrderRepositoryTests
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //arrange
            var orderRepository = new OrderRepository();
            var expected = new Order(1)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0))
            };

            //act
            var actual = orderRepository.Retrieve(1);

            //assert
            Assert.AreEqual(expected.OrderID, actual.OrderID);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
        }
        [TestMethod]
        public void SaveTestValid()
        {
            //arrange
            var orderRepository = new OrderRepository();
            var updatedOrder = new Order(1)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
                HasChanges = true
            };
            var expected = true;
            //act
            var actual = orderRepository.Save(updatedOrder);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SaveTestMissingOrderDate()
        {
            //arrange
            var orderRepository = new OrderRepository();
            var updatedOrder = new Order(1)
            {
                HasChanges = true
            };
            var expected = false;
            //act
            var actual = orderRepository.Save(updatedOrder);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
