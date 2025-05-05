using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BookManagement
{
    public class FileHandler
    {
        private static FileHandler? instance;
        private readonly string filePath = "books.dat";

        /// <summary>
        /// Private constructor to prevent instantiation from outside the class.
        /// </summary>
        private FileHandler() { }

        /// <summary>
        /// Gets the singleton instance of the FileHandler class.
        /// </summary>
        public static FileHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileHandler();
                }
                return instance;
            }
        }

        /// <summary>
        /// Reads the list of books from the file.
        /// </summary>
        /// <returns>A list of books read from the file. Returns an empty list if the file does not exist.</returns>
        public List<Book> ReadBooks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
            return new List<Book>();
        }

        /// <summary>
        /// Saves the list of books to the file.
        /// </summary>
        /// <param name="books">The list of books to save.</param>
        public void SaveBooks(List<Book> books)
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}