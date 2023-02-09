using System;
using BL;
namespace BLTests
{
    public class OrderRepositoryTests
    {
        [Fact]
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
            Assert.Equal(expected.OrderID, actual.OrderID);
            Assert.Equal(expected.OrderDate, actual.OrderDate);
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
    }
}
