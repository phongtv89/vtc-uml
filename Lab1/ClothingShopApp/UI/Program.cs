using System;

namespace ClothingShopApp.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Clothing Shop Management System");
            Console.WriteLine("Please log in to continue.");

            // User login logic
            string userType = Login();

            // Display appropriate menu based on user type
            if (userType == "Staff")
            {
                StaffMenu staffMenu = new StaffMenu();
                staffMenu.Display();
            }
            else if (userType == "Accountant")
            {
                AccountantMenu accountantMenu = new AccountantMenu();
                accountantMenu.Display();
            }
            else
            {
                Console.WriteLine("Invalid user type. Exiting application.");
            }
        }

        private static string Login()
        {
            // Simulated login logic
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // For simplicity, assume staff and accountant have the same credentials
            if (username == "staff" && password == "password")
            {
                return "Staff";
            }
            else if (username == "accountant" && password == "password")
            {
                return "Accountant";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}