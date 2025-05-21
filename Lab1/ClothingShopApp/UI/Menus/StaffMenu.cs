using System;
using ClothingShopApp.BL;
using ClothingShopApp.DTO;

namespace ClothingShopApp.UI.Menus
{
    public class StaffMenu
    {
        private readonly ProductManager _productManager;

        public StaffMenu(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\n--- Staff Menu ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Search Products");
            Console.WriteLine("5. Search Orders");
            Console.WriteLine("6. Search Customers");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
        }

        public void HandleMenuSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    EditProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    SearchProducts();
                    break;
                case "5":
                    SearchOrders();
                    break;
                case "6":
                    SearchCustomers();
                    break;
                case "7":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void AddProduct()
        {
            Console.WriteLine("Adding a new product...");
            // var product = new Product
            // {
            //     Name = InputHelper.ReadString("Enter product name: "),
            //     Description = InputHelper.ReadString("Enter product description: "),
            //     Price = InputHelper.ReadDecimal("Enter product price: "),
            //     StockQuantity = InputHelper.ReadInt("Enter stock quantity: ")
            // };
            // create StaffAction class for inptting staff information

            _productManager.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        private void EditProduct()
        {
            // Logic to edit a product
            Console.WriteLine("Editing a product...");
        }

        private void DeleteProduct()
        {
            // Logic to delete a product
            Console.WriteLine("Deleting a product...");
        }

        private void SearchProducts()
        {
            // Logic to search for products
            Console.WriteLine("Searching for products...");
        }

        private void SearchOrders()
        {
            // Logic to search for orders
            Console.WriteLine("Searching for orders...");
        }

        private void SearchCustomers()
        {
            // Logic to search for customers
            Console.WriteLine("Searching for customers...");
        }

        private void Exit()
        {
            Console.WriteLine("Exiting the staff menu...");
        }
    }
}