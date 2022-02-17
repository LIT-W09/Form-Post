using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{

    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class FurnitureDb
    {
        private string _connectionString;

        public FurnitureDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Furniture furniture)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Furniture (Name, Color, Price, QuantityInStock) " +
                "VALUES (@name, @color, @price, @qty)";
            cmd.Parameters.AddWithValue("@name", furniture.Name);
            cmd.Parameters.AddWithValue("@color", furniture.Color);
            cmd.Parameters.AddWithValue("@price", furniture.Price);
            cmd.Parameters.AddWithValue("@qty", furniture.QuantityInStock);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Furniture WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Furniture> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Furniture";
            connection.Open();
            List<Furniture> furnitureItems = new List<Furniture>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                furnitureItems.Add(new Furniture
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Color = (string)reader["Color"],
                    Price = (decimal)reader["Price"],
                    QuantityInStock = (int)reader["QuantityInStock"]
                });
            }

            return furnitureItems;
        }
    }
}