using System;
using System.Collections.Generic;
using ClothingShopApp.DataAccess.Models;
using MySql.Data.MySqlClient;

namespace ClothingShopApp.DAL
{
    public class OrderDAL
    {
        private readonly DatabaseContext _context;

        public OrderDAL(DatabaseContext context)
        {
            _context = context;
        }

        public Order GetOrderById(int id)
        {
            _context.OpenConnection();
            var query = "SELECT * FROM Orders WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Order
                {
                    Id = reader.GetInt32("Id"),
                    CustomerId = reader.GetInt32("CustomerId"),
                    OrderDate = reader.GetDateTime("OrderDate")
                };
            }
            return null;
        }

        public void AddOrder(Order order)
        {
            _context.OpenConnection();
            var query = "INSERT INTO Orders (CustomerId, OrderDate) VALUES (@CustomerId, @OrderDate)";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            command.ExecuteNonQuery();
        }

        public void UpdateOrder(Order order)
        {
            _context.OpenConnection();
            var query = "UPDATE Orders SET CustomerId = @CustomerId, OrderDate = @OrderDate WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", order.Id);
            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            command.ExecuteNonQuery();
        }

        public void DeleteOrder(int id)
        {
            _context.OpenConnection();
            var query = "DELETE FROM Orders WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        public List<Order> GetAllOrders()
        {
            _context.OpenConnection();
            var query = "SELECT * FROM Orders";
            using var command = _context.CreateCommand(query);
            using var reader = command.ExecuteReader();
            var orders = new List<Order>();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    Id = reader.GetInt32("Id"),
                    CustomerId = reader.GetInt32("CustomerId"),
                    OrderDate = reader.GetDateTime("OrderDate")
                });
            }
            return orders;
        }
    }
}