using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAL
    {
        private string _connectionString;

        public ProductSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }


        public Product GetProduct(int id)
        {
            Product product = new Product();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM products WHERE product_id = {id}" , conn);

                    var reader = cmd.ExecuteReader();
                    cmd.Parameters.AddWithValue("@id", id);
                    while (reader.Read())
                    {
                        product = new Product()
                        {
                            ProductId = Convert.ToInt32(reader["product_id"]),
                            Name = Convert.ToString(reader["name"]),
                            Description = Convert.ToString(reader["description"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            ImageName = Convert.ToString(reader["image_name"])
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return product;
        }

        public List<Product> GetProducts()
        {

            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM products ORDER BY product_id", conn);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            ProductId = Convert.ToInt32(reader["product_id"]),
                            Name = Convert.ToString(reader["name"]),
                            Description = Convert.ToString(reader["description"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            ImageName = Convert.ToString(reader["image_name"])
                        };

                        products.Add(product);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return products;
        }

        
    }

}
