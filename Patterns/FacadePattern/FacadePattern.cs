using System;
using System.Collections.Generic;
using System.Text;

namespace DESIGN_PATTERN.Patterns.FacadePattern
{
    /*
     Facade pattern is basically used when in controller there is multiple service
    and we need to use that services in controller without facade it become messi and diffcult to maintain
     
     */


    // consider there is multiple services

    public class ServiceabilityService
    {
        public bool IsServiceable(string pincode)
        {
            Console.WriteLine("Checking serviceability...");
            return true;
        }
    }

    public class WarehouseService
    {
        public bool HasCapacity(string pincode)
        {
            Console.WriteLine("Checking warehouse capacity...");
            return true;
        }
    }

    public class FreightService
    {
        public decimal Calculate(decimal weight)
        {
            Console.WriteLine("Calculating freight...");
            return weight * 10;
        }
    }

    public class PaymentService
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Payment processed: Rs. {amount}");
        }
    }

    public class Shipment
    {
        public string ShipmentNumber { get; set; } = "";
    }

    public class ShipmentService
    {
        public Shipment Create(BookingRequest request)
        {
            Console.WriteLine("Creating shipment...");

            return new Shipment
            {
                ShipmentNumber = "XPCN1001"
            };
        }
    }

    public class NotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Notification sent: {message}");
        }
    }

    public class BookingRequest
    {
        public string Pincode { get; set; } = "";
        public decimal Weight { get; set; }
    }


    // then create facade class

    public class BookingFacade
    {
        private readonly ServiceabilityService _serviceability;
        private readonly WarehouseService _warehouse;
        private readonly FreightService _freight;
        private readonly PaymentService _payment;
        private readonly ShipmentService _shipment;
        private readonly NotificationService _notification;

        public BookingFacade(
            ServiceabilityService serviceability,
            WarehouseService warehouse,
            FreightService freight,
            PaymentService payment,
            ShipmentService shipment,
            NotificationService notification)
        {
            _serviceability = serviceability;
            _warehouse = warehouse;
            _freight = freight;
            _payment = payment;
            _shipment = shipment;
            _notification = notification;
        }

        public Shipment BookShipment(BookingRequest request)
        {
            // 1. Check serviceability
            if (!_serviceability.IsServiceable(request.Pincode))
                throw new Exception("Location not serviceable");

            // 2. Check warehouse capacity
            if (!_warehouse.HasCapacity(request.Pincode))
                throw new Exception("Warehouse capacity unavailable");

            // 3. Calculate freight
            decimal amount = _freight.Calculate(request.Weight);

            // 4. Process payment
            _payment.Pay(amount);

            // 5. Create shipment
            var shipment = _shipment.Create(request);

            // 6. Send notification
            _notification.Send(
                $"Shipment {shipment.ShipmentNumber} booked");

            return shipment;
        }
    }


    //use above BookingFacade directly in controller
}
