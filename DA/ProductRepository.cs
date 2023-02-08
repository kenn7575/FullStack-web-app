using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.PortableExecutable;

namespace DA
{
    public class ProductRepository : DatabaseAccess
    {
        public string Retrieve()
        {
            var products = new List<Product>();
            // Code that retrieves all products from the database

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "SELECT * FROM Customer;";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product();
                            product.ProductID = reader["product_id"] as int?;
                            product.ProductName = reader["product_name"] as string;
                            product.Description = reader["description"] as string;
                            product.CurrentPrice = reader["current_price"] as decimal?;
                            product.QuantityInStock = reader["quantity"] as int?;
                            products.Add(product);
                        }
                    }
                }
            }
            return JsonSerializer.Serialize(products);
        }
    }
}

