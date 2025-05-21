using System;
using System.Collections.Generic;
using ClothingShopApp.DTO;
using MySql.Data.MySqlClient;

namespace ClothingShopApp.DAL
{
    public class ProductDAL
    {
        private readonly DatabaseContext _context;

        public ProductDAL(DatabaseContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            _context.OpenConnection();
            var query = "SELECT * FROM Products";
            using var command = _context.CreateCommand(query);
            using var reader = command.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Price = reader.GetDecimal("Price"),
                    Stock = reader.GetInt32("Stock")
                });
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            _context.OpenConnection();
            var query = "SELECT * FROM Products WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Price = reader.GetDecimal("Price"),
                    Stock = reader.GetInt32("Stock")
                };
            }
            return null;
        }

        public void AddProduct(Product product)
        {
            _context.OpenConnection();
            var query = "INSERT INTO Products (Name, Price, Stock) VALUES (@Name, @Price, @Stock)";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.ExecuteNonQuery();
        }

        public void UpdateProduct(Product product)
        {
            _context.OpenConnection();
            var query = "UPDATE Products SET Name = @Name, Price = @Price, Stock = @Stock WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.ExecuteNonQuery();
        }

        public void DeleteProduct(int id)
        {
            _context.OpenConnection();
            var query = "DELETE FROM Products WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}