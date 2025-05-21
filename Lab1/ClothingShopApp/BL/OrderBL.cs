using System;
using System.Collections.Generic;
using ClothingShopApp.DataAccess.Models;
using ClothingShopApp.DAL;
using ClothingShopApp.BusinessLogic.Interfaces;

namespace ClothingShopApp.BL
{
    public class OrderBL : IOrderService
    {
        private readonly OrderDAL _orderDAL;

        public OrderBL(OrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public Order GetOrderById(int id)
        {
            return _orderDAL.GetOrderById(id);
        }

        public void AddOrder(Order order)
        {
            _orderDAL.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderDAL.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderDAL.DeleteOrder(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderDAL.GetAllOrders();
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return _orderDAL.GetOrdersByCustomerId(customerId);
        }

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _orderDAL.GetOrdersByDateRange(startDate, endDate);
        }
    }
}