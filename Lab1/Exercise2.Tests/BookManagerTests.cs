using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BookManagement;
using Xunit;
namespace Exercise2.Tests;

public class BookManagerTests
{

    public BookManagerTests()
    {
        FileHandler.Instance.SaveBooks(new List<Book>());
    }

    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
        // Arrange
        var bookManager = new BookManager();
     
        var book = new Book("Test Title", "Test Author");
      
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        bookManager.AddNewBook(book);

        // Assert
        var output = sw.ToString().Trim();
        Assert.Equal("Book added successfully!", output);
    }

    [Fact]
    public void SearchBooksByTitle_ShouldReturnMatchingBooks()
    {
        // Arrange
        var bookManager = new BookManager();
        
        var book = new Book("Test Title", "Test Author");
        bookManager.AddNewBook(book);
       
        // Act
        var books = bookManager.SearchBooksByTitle(book.Title);

        // Assert
        Assert.True(books.Count > 0);
    }

    [Fact]
    public void SearchBooksByTitle_ShouldReturnNoMatchingBooks()
    {
        // Arrange
        var bookManager = new BookManager();
     
        var book = new Book("Test Title", "Test Author");
        bookManager.AddNewBook(book);

        // Act
        var books = bookManager.SearchBooksByTitle(book.Title + "NotFound");

        // Assert
        Assert.True(books.Count == 0);
    }

    [Fact]
    public void SearchBooksByAuthor_ShouldReturnMatchingBooks()
    {
        // Arrange
        var bookManager = new BookManager();
         
        var book = new Book("Test Title", "Test Author");
        bookManager.AddNewBook(book);

        // Act
        var books = bookManager.SearchBooksByAuthor(book.Author);

        // Assert
        Assert.True(books.Count > 0);
    }

      [Fact]
    public void SearchBooksByAuthor_ShouldReturnNoMatchingBooks()
    {
        // Arrange
        var bookManager = new BookManager();
      
        var book = new Book("Test Title", "Test Author");
        bookManager.AddNewBook(book);

        // Act
        var books = bookManager.SearchBooksByAuthor(book.Author+ "NotFound");

        // Assert
        Assert.True(books.Count == 0);
    }

    [Fact]
    public void SaveBooks_ShouldPersistBooksToFile()
    {
        // Arrange
        var bookManager = new BookManager();
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        bookManager.SaveBooks();

        // Assert
        var output = sw.ToString().Trim();
        Assert.Equal("Books data saved successfully!", output);
    }
}

