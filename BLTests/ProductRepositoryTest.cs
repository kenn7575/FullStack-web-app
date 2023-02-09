using System;
using BL;

namespace BLTests
{
    
    public class ProductRepositoryTest
    {
        [Fact]
        public void RetrieveValid()
        {
            //arrange
            var productRepository = new ProductRepository();
            var expected = new Product()
            {
                ProductId = 1,
                ProductName = "Sunflowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                CurrentPrice = 15.96M
            };

            //act
            var actual = productRepository.Retrieve(1);

            //assert
            Assert.Equal(expected.ProductId, actual.ProductId);
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.CurrentPrice, actual.CurrentPrice);
        }
        [Fact]
        //test save method
        public void SaveTestValid()
        {
            //arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product()
            {
                ProductId = 1,
                QuantityInStock = 1,
                CurrentPrice = 18M,
                ProductName = "Sunflowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                HasChanges = true
            };
            
            //act
            var actual = productRepository.Save(updatedProduct);

            //assert
            Assert.Equal(true, actual);
        }
        [Fact]
        //test save method on invalid data
        public void SaveTestMissingPrice()
        {
            //arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product()
            {
                ProductId = 1,

                CurrentPrice = null,
                ProductName = "Sunflowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                HasChanges = true
            };

            //act
            var actual = productRepository.Save(updatedProduct);

            //assert
            Assert.Equal(false, actual);
        }

    }
}
