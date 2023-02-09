using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DA;
//import the namespace DA

namespace BL
{
    public class ProductRepository
    {
        //retrieve one product

        //retrieve all products
        public List<Product> Retrieve(int id = 0)
        {
            //code that retrieves all of the products
            //temporary hard coded values to return a set of products
            DA.ProductDataAccess productRepository = new DA.ProductDataAccess();
            string json= productRepository.Retrieve(id);
            
            
            //deserialize the json string   
            return JsonSerializer.Deserialize<List<Product>>(json);
            
        }
        //saves the current product
        public bool Save(Product product)
        {
            bool success = true;
            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    ProductDataAccess productDataAccess = new ProductDataAccess();
                    DA.Product daProduct = new DA.Product
                    {
                        CurrentPrice = product.CurrentPrice,
                        ProductName = product.ProductName,
                        ProductId = product.ProductId,
                        Description = product.Description,
                        QuantityInStock = product.QuantityInStock
                    };
                    
                    if (product.IsNeW)
                    {
                        //call an insert stored procedure
                    }
                    else
                    {
                        //call an update stored procedure
                        Console.WriteLine("Works");
                        productDataAccess.Update(daProduct);
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
        
    }
}
