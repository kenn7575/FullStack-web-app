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
    public class ProductDataAccess : DatabaseAccess
    {
        public string Retrieve(int Id = 0)
        {
            var products = new List<Product>();
            // Code that retrieves all products from the database

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "SELECT * FROM Product";
                if (Id > 0)
                {
                    Query += " WHERE product_id = " + Id;
                }
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product();
                            product.ProductId = (int) reader["product_id"];
                            product.ProductName = reader["product_name"] as string;
                            product.Description = reader["description"] as string;
                            product.CurrentPrice = (double) reader["current_price"];
                            product.QuantityInStock = reader["quantity"] as int?;
                            products.Add(product);
                        }
                    }
                }
            }
            return JsonSerializer.Serialize(products);
        }
        //Update product
        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "UPDATE Product SET product_name = @product_name, description = @description, current_price = @current_price, quantity = @quantity WHERE product_id = @product_id";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@product_id",  product.ProductId);
                    command.Parameters.AddWithValue("@product_name", product.ProductName);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@current_price",  product.CurrentPrice);
                    command.Parameters.AddWithValue("@quantity", product.QuantityInStock);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

