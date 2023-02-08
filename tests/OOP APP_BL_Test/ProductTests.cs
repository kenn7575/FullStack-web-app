using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BL;

namespace BLTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ValidateValid()
        {
            //arrange
            var product = new Product(1)
            {
                CurrentPrice = 10.00M,
                ProductName = "Test",
                Description = "Test Description"
            };
            var expected = true;

            //act
            var actual = product.Validate();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateMissingPrice()
        {
            //arrange
            var product = new Product()
            {
                ProductName = "Test",
                Description = "Test Description"
            };
            var expected = false;

            //act
            var actual = product.Validate();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateInvalidPrice()
        {
            //arrange
            var product = new Product()
            {
                ProductName = "Test",
                Description = "Test Description",
                CurrentPrice = 0.0M

            };
            var expected = false;

            //act
            var actual = product.Validate();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateMissingName()
        {
            //arrange
            var product = new Product()
            {
                Description = "Test Description",
                CurrentPrice = 10.0M

            };
            var expected = false;

            //act
            var actual = product.Validate();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateMissingProductID()
        {
            //arrange
            var product = new Product()
            {
                ProductName = "Test",
                Description = "Test Description",
                CurrentPrice = 10.0M

            };
            var expected = false;

            //act
            var actual = product.Validate();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
