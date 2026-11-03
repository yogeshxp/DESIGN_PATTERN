using System;
using System.Collections.Generic;
using System.Text;

namespace DESIGN_PATTERN.Patterns.Behavioural.ObserverPattern
{

    public interface IShipmentObserver
    {
        void OnStatusChanges(string shipmentNumber, string newStatus);
    }


    public class SmsNotificationObserver : IShipmentObserver
    {
        public void OnStatusChanges(string shipmentNumber, string newStatus)
        {
            Console.WriteLine(
           $"SMS: Shipment {shipmentNumber} is now {newStatus}");
        }
    }

    public class EmailNotificationObserver : IShipmentObserver
    {
        public void OnStatusChanges(string shipmentNumber, string newStatus)
        {
            Console.WriteLine(
           $"EMAIL: Shipment {shipmentNumber} is now {newStatus}");
        }
    }

    public class TrackingObserver : IShipmentObserver
    {
        public void OnStatusChanges(string shipmentNumber, string newStatus)
        {
            Console.WriteLine(
           $"Tracking: Shipment {shipmentNumber} is now {newStatus}");
        }
    }



    public class ShipementPublisher
    {
        private readonly List<IShipmentObserver> _observer = new(); // Maintain List of obeservers

        private string _status;
        
        public void Subscribe(IShipmentObserver observer)
        {
            _observer.Add(observer);
        }


        public void Unsubscribe(IShipmentObserver observer)
        {

            _observer.Remove(observer);

        }

        public void ChangeStatus(string shipmentNumber,string newStatus)
        {
            _status = newStatus;

            Console.WriteLine($"\nShipment status changed to: {_status}");

            NotifyObserver(shipmentNumber, newStatus);
        }

        public void NotifyObserver(string shipmentNumber, string newStatus)
        {

            foreach(var obeserver in _observer)
            {
                obeserver.OnStatusChanges(shipmentNumber, newStatus);
            }

        }


    }

}