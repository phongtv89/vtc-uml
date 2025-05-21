using System;
using System.Collections.Generic;
using System.Data;
using ClothingShopApp.DataAccess.Models;
using MySql.Data.MySqlClient;

namespace ClothingShopApp.DAL
{
    public class CustomerDAL
    {
        private readonly DatabaseContext _context;

        public CustomerDAL(DatabaseContext context)
        {
            _context = context;
        }

        public Customer GetCustomerById(int id)
        {
            _context.OpenConnection();
            var query = "SELECT * FROM Customers WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Customer
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email")
                };
            }
            return null;
        }

        public List<Customer> GetAllCustomers()
        {
            _context.OpenConnection();
            var query = "SELECT * FROM Customers";
            using var command = _context.CreateCommand(query);
            using var reader = command.ExecuteReader();
            var customers = new List<Customer>();
            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email")
                });
            }
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            _context.OpenConnection();
            var query = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.ExecuteNonQuery();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.OpenConnection();
            var query = "UPDATE Customers SET Name = @Name, Email = @Email WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", customer.Id);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.ExecuteNonQuery();
        }

        public void DeleteCustomer(int id)
        {
            _context.OpenConnection();
            var query = "DELETE FROM Customers WHERE Id = @Id";
            using var command = _context.CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}