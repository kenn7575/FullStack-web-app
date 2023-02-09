using System;
using System.Collections.Generic;
using System.Text;
using BL;

namespace BLTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    
    public class ProductTests
    {
        [Fact]
        public void ValidateValid()
        {
            //arrange
            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Test",
                Description = "Test Description",
                CurrentPrice = 10.0M,
                QuantityInStock = 1
            };
            
            var expected = true;

            //act
            var actual = product.Validate();

            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
    }
}
