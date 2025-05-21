using System;
using System.Collections.Generic;
using System.Linq;
using ClothingShopApp.DTO;
using ClothingShopApp.DAL;
using ClothingShopApp.DataAccess.Models;
using ClothingShopApp.DataAccess.Repositories;

namespace ClothingShopApp.UI.Utils
{
    public class ReportGenerator
    {
        private readonly OrderRepository _orderRepository;

        public ReportGenerator(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void GenerateOrderReport(DateTime startDate, DateTime endDate)
        {
            var orders = _orderRepository.GetOrdersByDateRange(startDate, endDate);

            if (orders.Any())
            {
                Console.WriteLine($"Order Report from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}");
                Console.WriteLine("--------------------------------------------------");
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Customer ID: {order.CustomerId}, Order Date: {order.OrderDate}, Total Amount: {order.TotalAmount:C}");
                }
            }
            else
            {
                Console.WriteLine("No orders found for the specified date range.");
            }
        }
    }
}