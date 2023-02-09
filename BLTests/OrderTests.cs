using System;
using System.Collections.Generic;
using System.Text;
using BL;

namespace BLTests
{
    /// <summary>
    /// Summary description for OrderTests
    /// </summary>
    
    public class OrderTests
    {
        [Fact]
        public void ValidateValid()
        {
            //arrange
            var order = new Order(1)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 1, 1, 14, 00, 00, new TimeSpan(7, 0, 0))
            };
            var expected = true;

            //act
            var actual = order.Validate();

            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ValidateMissingOrderDate()
        {
            //arrange
            var order = new Order(1);
            var expected = false;

            //act
            var actual = order.Validate();

            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ValidateMissingOrderID()
        {
            //arrange
            var order = new Order()
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 1, 1, 14, 00, 00, new TimeSpan(7, 0, 0))
            };
            var expected = false;

            //act
            var actual = order.Validate();

            //assert
            Assert.Equal(expected, actual);
        }

    }
}
