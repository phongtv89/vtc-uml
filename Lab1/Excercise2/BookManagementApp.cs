namespace BookManagement;

public class BookManagementApp
{
    private BookManager bookManager;
    private UserActions userActions;
    private bool isRunning = true;

    public BookManagementApp()
    {
        bookManager = new BookManager();
        userActions = new UserActions();
    }

    public void Run()
    {
        DisplayWelcomeMessage();

        while (isRunning)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            ProcessMenuChoice(choice);
        }

        // Save to file on exit
        bookManager.SaveBooks();
    }

    private void DisplayWelcomeMessage()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("    BOOK MANAGEMENT SYSTEM");
        Console.WriteLine("====================================");
        Console.WriteLine("Books will be loaded from books.dat");
        Console.WriteLine("Changes will be saved to books.dat when exiting");
        Console.WriteLine();
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nBook Management Application");
        Console.WriteLine("1. Add New Book");
        Console.WriteLine("2. Search Books by Title");
        Console.WriteLine("3. Search Books by Author");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1-4): ");
    }

    private void ProcessMenuChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                AddNewBook();
                break;
            case "2":
                SearchBooksByTitle();
                break;
            case "3":
                SearchBooksByAuthor();
                break;
            case "4":
                Exit();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private void AddNewBook()
    {
        Console.WriteLine("\n--- Add New Book ---");
        
        var newBook = userActions.InitializeBook();

        // inputdatetime
        //

        
        if (!string.IsNullOrWhiteSpace(newBook.Title) && !string.IsNullOrWhiteSpace(newBook.Author))
        {
            bool bookExists = bookManager.DoesBookExist(newBook.Title, newBook.Author);

            if (bookExists)
            {
                Console.WriteLine("A book with the same title and author already exists. Book not added.");

                Console.WriteLine("Do you want to add this book? (Y/N): ");
                string confirmation = Console.ReadLine()?.Trim().ToLower();

                if (confirmation == "Y")
                {
                    bookManager.AddNewBook(newBook);
                    Console.WriteLine("Book added successfully!");
                }
                else
                {
                    Console.WriteLine("Book not added.");
                }
            }
            else
            {
                bookManager.AddNewBook(newBook);
                Console.WriteLine("Book added successfully!");
            }

            bookManager.AddNewBook(newBook);
            Console.WriteLine("Book added successfully!");
        }
        else
        {
            Console.WriteLine("Book title and author cannot be empty. Book not added.");
        }
    }

    private void SearchBooksByTitle()
    {
        Console.WriteLine("\n--- Search Books by Title ---");
        
        Console.Write("Enter title to search for: ");
        string searchTitle = userActions.InputSearchTitle();
        
        List<Book> results = bookManager.SearchBooksByTitle(searchTitle);
        DisplaySearchResults(results, "title", searchTitle);
    }

    private void SearchBooksByAuthor()
    {
        Console.WriteLine("\n--- Search Books by Author ---");
        
        Console.Write("Enter author to search for: ");
        string searchAuthor = userActions.InputSearchAuthor();
        
        List<Book> results = bookManager.SearchBooksByAuthor(searchAuthor);
        DisplaySearchResults(results, "author", searchAuthor);
    }

    private void DisplaySearchResults(List<Book> results, string searchType, string searchTerm)
    {
        if (results.Count > 0)
        {
            Console.WriteLine($"\nFound {results.Count} book(s) with {searchType} containing '{searchTerm}':");
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {results[i]}");
            }
        }
        else
        {
            Console.WriteLine($"No books found with {searchType} containing '{searchTerm}'.");
        }
    }

    // private void DisplayAllBooks()
    // {
    //     List<Book> allBooks = bookManager();
        
    //     if (allBooks.Count > 0)
    //     {
    //         Console.WriteLine("\n--- All Books ---");
    //         for (int i = 0; i < allBooks.Count; i++)
    //         {
    //             Console.WriteLine($"{i + 1}. {allBooks[i]}");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("\nNo books in the system yet.");
    //     }
    // }

    private void Exit()
    {
        Console.WriteLine("\nSaving books to file and exiting...");
        isRunning = false;
    }
}
