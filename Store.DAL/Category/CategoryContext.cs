using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Store.DAL.Category
{
    public class CategoryContext
    {
        public List<CategoryModel> GetCategories()
        {
            string connectionString = @"Data Source=DESKTOP-VJMA770;Initial Catalog=Market;Integrated Security=True";
            string sqlExpression = "Select * from Categories";
            CategoryModel category = new CategoryModel();
            List<CategoryModel> categories = new List<CategoryModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            category.Id = reader.GetInt32(0);
                            category.CategoryName = reader.GetString(1);
                            categories.Add(category);
                        }
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message); 
            }
            
            return categories;
        }
    }
}
