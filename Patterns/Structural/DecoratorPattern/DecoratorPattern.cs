using System;
using System.Collections.Generic;
using System.Text;

namespace DESIGN_PATTERN.Patterns.Structural.DecoratorPattern
{



    /*
     The decorator pattern is structural pattern that add addition responsiblity to a object dynamically
    by wrapping it with another object the implemented the same interface


    Purpose: Add functionality
     
     */
    public interface INotificationService
    {
        void Send(string msg);
    }

    public class EmailNotificationService : INotificationService
    {
        public void Send(string msg)
        {
            Console.WriteLine($"Email send {msg}");
        }
    }


    // Now above code is concreate componenent it perform only email send responsiblity


    // create decorator

    public abstract class NotificationDecoator : INotificationService
    {
        protected readonly INotificationService _notificationService;

        protected NotificationDecoator(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        public virtual void Send(string msg) {

            _notificationService.Send(msg);  
        }
    }

    public class LoggingDecorator : NotificationDecoator
    {
        public LoggingDecorator(INotificationService service)
            : base(service)
        {
        }

        public override void Send(string message)
        {
            Console.WriteLine("LOG: Sending notification started");

            base.Send(message);

            Console.WriteLine("LOG: Sending notification completed");
        }
    }


    // now if we want to add extra behavior:

    public class MetricsDecorator : NotificationDecoator
    {
        public MetricsDecorator(INotificationService service)
            : base(service)
        {
        }

        public override void Send(string message)
        {
            var startTime = DateTime.UtcNow;

            base.Send(message);

            var duration = DateTime.UtcNow - startTime;

            Console.WriteLine(
                $"Metrics: Execution took {duration.TotalMilliseconds} ms"
            );
        }
    }

    public class ValidationDecorator : NotificationDecoator
    {
        public ValidationDecorator(INotificationService service)
            : base(service)
        {
        }

        public override void Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message cannot be empty");
            }

            Console.WriteLine("Validation successful");

            base.Send(message);
        }
    }




}
