using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookManagement
{
    public class BookManager
    {
        private List<Book> books = new List<Book>();
        private FileHandler fileHandler;

 
        /// <summary>
        /// Constructor that accepts a file path. Initializes the BookManager and loads books from the specified file path.
        /// </summary>
        /// <param name="filePath">The file path to load and save books.</param>
        public BookManager()
        {
            fileHandler = FileHandler.Instance;

            LoadBooks();
        }

        /// <summary>
        /// Adds a new book to the collection and displays a success message.
        /// </summary>
        /// <param name="newBook">The book to add to the collection.</param>
        public void AddNewBook(Book newBook)
        {
            books.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }

        /// <summary>
        /// Searches for books by title and displays the results.
        /// </summary>
        /// <param name="title">The title or part of the title to search for.</param>
        public List<Book> SearchBooksByTitle(string title)
        {
            return books.Where(b => !string.IsNullOrEmpty(title) && b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Searches for books by author and displays the results.
        /// </summary>
        /// <param name="author">The author or part of the author's name to search for.</param>
        public List<Book> SearchBooksByAuthor(string author)
        {
            return books.Where(b => !string.IsNullOrEmpty(author) && b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Saves the current collection of books to the file specified by the file path.
        /// </summary>
        public void SaveBooks()
        {
            try
            {
                fileHandler.SaveBooks(books);

                Console.WriteLine("Books data saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: File path is not set. Unable to save books.");
            }
        }

        /// <summary>
        /// Loads the collection of books from the file specified by the file path.
        /// </summary>
        private void LoadBooks()
        {
            books = fileHandler.ReadBooks();
        }

        /// <summary>
        /// Checks if a book with the specified title and author already exists in the collection.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public bool DoesBookExist(string title, string author)
        {
            return books.Any(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                                    book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }
    }
}