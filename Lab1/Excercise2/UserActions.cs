namespace BookManagement;

public class UserActions
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Book InitializeBook()
    {
        Console.Write("Enter book title: ");
        var title = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter book author: ");
        var author = Console.ReadLine() ?? string.Empty;

        return new Book(title, author);
    }


    /// <summary>
    /// Prompts the user to enter a title to search for in the book list.
    /// </summary>
    /// <returns></returns>
    public string InputSearchTitle()
    {
        Console.Write("Enter title to search: ");
        var title = Console.ReadLine() ?? string.Empty;

        return title;
    }

    /// <summary>
    /// Prompts the user to enter an author to search for in the book list.
    /// </summary>
    /// <returns></returns>
    public string InputSearchAuthor()
    {
        Console.Write("Enter author to search: ");
        var author = Console.ReadLine() ?? string.Empty;

        return author;
    }
}
