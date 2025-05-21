using System;

namespace ClothingShopApp.Presentation.Menus
{
    public class AccountantMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\n--- Accountant Menu ---");
            Console.WriteLine("1. Search Customers");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Edit Customer");
            Console.WriteLine("4. Search Orders");
            Console.WriteLine("5. Add Order");
            Console.WriteLine("6. Edit Order");
            Console.WriteLine("7. View Order Reports");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");
        }

        public void HandleMenuSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    SearchCustomers();
                    break;
                case "2":
                    AddCustomer();
                    break;
                case "3":
                    EditCustomer();
                    break;
                case "4":
                    SearchOrders();
                    break;
                case "5":
                    AddOrder();
                    break;
                case "6":
                    EditOrder();
                    break;
                case "7":
                    ViewOrderReports();
                    break;
                case "8":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void SearchCustomers()
        {
            // Logic to search customers
        }

        private void AddCustomer()
        {
            // Logic to add a new customer
        }

        private void EditCustomer()
        {
            // Logic to edit an existing customer
        }

        private void SearchOrders()
        {
            // Logic to search orders
        }

        private void AddOrder()
        {
            // Logic to add a new order
        }

        private void EditOrder()
        {
            // Logic to edit an existing order
        }

        private void ViewOrderReports()
        {
            // Logic to view order reports by time period
        }

        private void Exit()
        {
            Console.WriteLine("Exiting Accountant Menu...");
        }
    }
}