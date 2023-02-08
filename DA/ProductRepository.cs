using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DA
{
    internal class ProductRepository : DatabaseAccess
    {
        public string Retrieve()
        {
            // Code that retrieves all products from the database
            
            using (SqlConnection connection = new SqlConnection(DatabaseAccess.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Product";
                var reader = command.ExecuteReader();
                var products = new List<Product>();
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
                reader.Close();
                return JsonSerializer.Serialize(products);
            }
        }
    }
}
