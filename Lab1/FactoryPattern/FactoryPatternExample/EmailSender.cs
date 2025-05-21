namespace FactoryPatternExample;

public class EmailSender : INotificationSender
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Sending email to: {recipient} with message: {message}");
        // In a real application, you'd have email sending logic here
    }
}