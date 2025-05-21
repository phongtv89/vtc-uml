using System;

namespace ClothingShopApp.Presentation.Menus
{
    public class MainMenu
    {
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Clothing Shop Management System");
            Console.WriteLine("1. Login as Staff");
            Console.WriteLine("2. Login as Accountant");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option: ");
        }

        public int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.Write("Invalid choice. Please select a valid option (1-3): ");
            }
            return choice;
        }
    }
}