// 1. Define an interface for our products (Notification Senders)
namespace FactoryPatternExample;

    // INotificationSender.cs
    // This interface defines the contract for notification senders.
    // It includes a method to send notifications with a message and recipient.
    // Implementing classes will provide specific notification sending logic.
    
public interface INotificationSender
{
    void Send(string message, string recipient);
}