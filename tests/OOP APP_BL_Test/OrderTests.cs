using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BL;

namespace BLTests
{
    /// <summary>
    /// Summary description for OrderTests
    /// </summary>
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
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
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateMissingOrderDate()
        {
            //arrange
            var order = new Order(1);
            var expected = false;

            //act
            var actual = order.Validate();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
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
            Assert.AreEqual(expected, actual);
        }

    }
}
