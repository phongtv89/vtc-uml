using System.Collections.Generic;
using ClothingShopApp.DataAccess.Models;
using ClothingShopApp.DAL;
using ClothingShopApp.BusinessLogic.Interfaces;

namespace ClothingShopApp.BL
{
    public class CustomerBL : ICustomerService
    {
        private readonly CustomerDAL _customerDAL;

        public CustomerBL(CustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerDAL.GetCustomerById(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerDAL.GetAllCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            // validate custom existence

            // add customer to database
            _customerDAL.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerDAL.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerDAL.DeleteCustomer(id);
        }
    }
}