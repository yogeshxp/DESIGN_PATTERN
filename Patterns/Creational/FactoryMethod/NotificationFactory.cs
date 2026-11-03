namespace DESIGN_PATTERN.Patterns.Creational.FactoryMethod;

public abstract class NotificationFactory
{
    // Factory Method
    protected abstract INotification CreateNotification();

    public void Notify(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
    }
}


public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email Sent: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS Sent: {message}");
    }
}


public class EmailNotificationFactory : NotificationFactory
{
    protected override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SMSNotificationFactory : NotificationFactory
{
    protected override INotification CreateNotification()
    {
        return new SMSNotification();
    }
}

