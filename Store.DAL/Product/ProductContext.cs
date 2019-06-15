using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Store.DAL.Product
{
    public class ProductContext
    {
        string connectionString = @"Data Source=DESKTOP-VJMA770;Initial Catalog=Market;Integrated Security=True";

        public List<ProductModel> GetProducts(int id)
        {
            string sqlExpression = $"Select * from Products where CategoryId={id}";
            ProductModel product = new ProductModel();
            List<ProductModel> products = new List<ProductModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.CategoryId = reader.GetInt32(1);
                        product.ProductName = reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        product.ProductInfo = reader.GetString(4);
                        products.Add(product);
                    }
                }
                reader.Close();
            }
            return products;
        }

        public ProductModel Detail(int id)
        {
            string sqlExpression = $"Select * from Products where Id={id}";
            ProductModel product = new ProductModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    product.Id = reader.GetInt32(0);
                    product.CategoryId = reader.GetInt32(1);
                    product.ProductName = reader.GetString(2);
                    product.Price = reader.GetDecimal(3);
                    product.ProductInfo = reader.GetString(4);
                }
                reader.Close();
            }
            return product;
        }

        public List<ProductModel> GetAll()
        {
            string sqlExpression = $"Select * from Products";
            ProductModel product = new ProductModel();
            List<ProductModel> products = new List<ProductModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.CategoryId = reader.GetInt32(1);
                        product.ProductName = reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        product.ProductInfo = reader.GetString(4);
                        products.Add(product);
                    }
                }
                reader.Close();
            }
            return products;
        }

        public decimal CreateProduct(ProductModel product)
        {
            string sqlExpression = $"sp_CreateProduct";
            decimal result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.CommandType = CommandType.StoredProcedure;

                //@productName, @price, @productInfo, @categoryId

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@productName",
                    Value = product.ProductName
                };
                command.Parameters.Add(nameParam);

                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = product.Price
                };
                command.Parameters.Add(priceParam);

                SqlParameter infoParam = new SqlParameter
                {
                    ParameterName = "@productInfo",
                    Value = product.ProductInfo
                };
                command.Parameters.Add(infoParam);

                SqlParameter categoryIdParam = new SqlParameter
                {
                    ParameterName = "@categoryId",
                    Value = product.CategoryId
                };
                command.Parameters.Add(categoryIdParam);

                result = (decimal)command.ExecuteScalar();

                Console.WriteLine("Id of the new product: {0}", result);
            }
            return result;
        }

        public int UpdateProduct(ProductModel product)
        {
            string sqlExpression = $"Update Products Set CategoryId={product.CategoryId}, ProductName='{product.ProductName}', Price = {product.Price}, ProductInfo='{product.ProductInfo}' where Id={product.Id}";
            int result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                result = (int)command.ExecuteScalar();

                Console.WriteLine("Id of updated product: {0}", result);
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            string sqlExpression = $"Delete From Products Where Id=={id}";
            int result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                result = (int)command.ExecuteScalar();

                Console.WriteLine("Id of deleted product: {0}", result);
            }
            return result;
        }

        public ProductModel Find(int id)
        {
            string sqlExpression = $"Select * from Products where Id={id}";

            ProductModel product = new ProductModel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.CategoryId = reader.GetInt32(1);
                        product.ProductName = reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        product.ProductInfo = reader.GetString(4);
                    }
                }
                reader.Close();
            }
            return product;
        }
    }
}
