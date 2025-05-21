using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClothingShopApp.DataAccess
{
    public class DatabaseContext : IDisposable
    {
        private readonly string _connectionString;
        private MySqlConnection _connection;

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(_connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlCommand CreateCommand(string query)
        {
            return new MySqlCommand(query, _connection);
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }
    }
}