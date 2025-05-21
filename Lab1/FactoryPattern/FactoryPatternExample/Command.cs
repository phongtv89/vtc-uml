using System;
using System.Collections.Generic;

// 1. The Command Interface
public interface ICommand
{
    void Execute();
    void Undo(); // Optional: For supporting undo functionality
}

// 2. The Receiver: Knows how to perform the operations
public class TextFile
{
    private string _fileName;

    public TextFile(string fileName)
    {
        _fileName = fileName;
    }

    public void Open()
    {
        Console.WriteLine($"Opening file: {_fileName}");
        // Real file opening logic would go here
    }

    public void Save()
    {
        Console.WriteLine($"Saving file: {_fileName}");
        // Real file saving logic would go here
    }

    public void Close()
    {
        Console.WriteLine($"Closing file: {_fileName}");
        // Real file closing logic would go here
    }
}

// 3. Concrete Commands: Encapsulate an action and the receiver
public class OpenCommand : ICommand
{
    private TextFile _textFile;

    public OpenCommand(TextFile textFile)
    {
        _textFile = textFile;
    }

    public void Execute()
    {
        _textFile.Open();
    }

    public void Undo()
    {
        Console.WriteLine($"Cannot undo opening a file.");
        // In a more complex scenario, you might track the previous state
    }
}

public class SaveCommand : ICommand
{
    private TextFile _textFile;

    public SaveCommand(TextFile textFile)
    {
        _textFile = textFile;
    }

    public void Execute()
    {
        _textFile.Save();
    }

    public void Undo()
    {
        Console.WriteLine($"Cannot directly undo a save operation in this simple example.");
        // You might need to implement versioning or backups for a real undo
    }
}

public class CloseCommand : ICommand
{
    private TextFile _textFile;

    public CloseCommand(TextFile textFile)
    {
        _textFile = textFile;
    }

    public void Execute()
    {
        _textFile.Close();
    }

    public void Undo()
    {
        Console.WriteLine($"Cannot directly undo closing a file in this simple example.");
        // You might need to reopen the file in a more complex scenario
    }
}

// 4. The Invoker: Asks the command to carry out the request
public class TextEditorInvoker
{
    private List<ICommand> _history = new List<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Add(command); // Optionally track executed commands for undo
    }

    public void UndoLastCommand()
    {
        if (_history.Count > 0)
        {
            ICommand lastCommand = _history[_history.Count - 1];
            lastCommand.Undo();
            _history.RemoveAt(_history.Count - 1);
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}

// 5. Client: Creates commands and associates them with the invoker
public class Program
{
    public static void Main(string[] args)
    {
        TextFile file = new TextFile("my_document.txt");
        TextEditorInvoker editor = new TextEditorInvoker();

        ICommand openCommand = new OpenCommand(file);
        ICommand saveCommand = new SaveCommand(file);
        ICommand closeCommand = new CloseCommand(file);

        editor.ExecuteCommand(openCommand);
        editor.ExecuteCommand(saveCommand);
        editor.ExecuteCommand(closeCommand);

        Console.WriteLine("\nUndoing last command:");
        editor.UndoLastCommand(); // Undoes the Close command

        Console.WriteLine("\nUndoing previous command:");
        editor.UndoLastCommand(); // Undoes the Save command
    }
}