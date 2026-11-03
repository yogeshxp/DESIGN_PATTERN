using System;
using System.Collections.Generic;
using System.Text;

namespace DESIGN_PATTERN.Patterns.Behavioural.ObserverPattern
{
    public class ShipmentsPublisher
    {
        public string ShipmentNumber { get; set; }

        public event EventHandler<string> statusChanged;



        public void changeStatus(string status)
        {
            Console.WriteLine($"shipment status changes: {status}");


            statusChanged.Invoke(this, status);
        }

    }


    // ShipmentObserver


    public class SmsService
    {
        public void SendSMS(Object sender,string status)
        {
            Console.WriteLine($"SMS sent: {status}");
        }
    }

    public class EmailService
    {
        public void SendEMAIL(Object sender, string status)
        {
            Console.WriteLine($"Email sent: {status}");
        }

    }


}
