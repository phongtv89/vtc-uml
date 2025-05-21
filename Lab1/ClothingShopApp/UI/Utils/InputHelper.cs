using System;

namespace ClothingShopApp.Presentation.Utils
{
    public static class InputHelper
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public static decimal ReadDecimal(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }
        }

        public static bool ReadYesNo(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt + " (y/n): ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        }
    }
}