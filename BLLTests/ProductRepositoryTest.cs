using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BL;

namespace BLTests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //arrange
            var productRepository = new ProductRepository();
            var expected = new Product(1)
            {
                ProductName = "Sunflowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                CurrentPrice = 15.96M
            };

            //act
            var actual = productRepository.Retrieve(1);

            //assert
            Assert.AreEqual(expected.ProductID, actual.ProductID);
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
        }
        [TestMethod]
        //test save method
        public void SaveTestValid()
        {
            //arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(1)
            {
                CurrentPrice = 18M,
                ProductName = "Sunflowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                HasChanges = true
            };
            
            //act
            var actual = productRepository.Save(updatedProduct);

            //assert
            Assert.AreEqual(true, actual);
        }
        [TestMethod]
        //test save method on invalid data
        public void SaveTestMissingPrice()
        {
            //arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(1)
            {
                CurrentPrice = null,
                ProductName = "Sunflowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                HasChanges = true
            };

            //act
            var actual = productRepository.Save(updatedProduct);

            //assert
            Assert.AreEqual(false, actual);
        }

    }
}
