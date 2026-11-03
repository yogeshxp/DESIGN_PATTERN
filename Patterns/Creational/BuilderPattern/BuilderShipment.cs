using System;
using System.Collections.Generic;
using System.Text;

namespace DESIGN_PATTERN.Patterns.Creational.BuilderPattern
{

    /*When we use this Builder pattern let assume there is class
    public class Shipment
    {
        public Shipment(
            string shipmentNumber,
            string shipmentType,
            string pickupAddress,
            string deliveryAddress,
            decimal weight,
            decimal length,
            decimal width,
            decimal height,
            string customerName,
            bool insurance,
            bool priority)
        {
            // Assign properties
        }
    }


    Problem : Too many constructor parameter
    This is called the telescoping constructor problem when constructors accumulate many parameters and overloads.


    what builder pattern do?
    -> Create complex oject step by step, instead of passing everything into one constructor, we call method to configure

    */

    public class BuilderShipment
    {
        public string ShipmentNumber { get; set; }
        public string ShipmentType { get; set; }
        public string PickupAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string CustomerName { get; set; }
        public bool Insurance { get; set; }
        public bool Priority { get; set; }

    }


    public class ShipmentBuilder
    {
        private readonly BuilderShipment _shipment;


        public ShipmentBuilder()
        {
            _shipment = new BuilderShipment();
        }


        public ShipmentBuilder SetShipmentNumber(string number)
        {
            _shipment.ShipmentNumber = number;
            return this;
        }

        public ShipmentBuilder SetShipmentType (string shipmentType)
        {
            _shipment.ShipmentType = shipmentType;
            return this;
        }

        public ShipmentBuilder SetPickupAddress(string PickupAddress)
        {
            _shipment.PickupAddress = PickupAddress;
            return this;
        }
        public ShipmentBuilder SetDeliveryAddress(string DeliveryAddress)
        {
            _shipment.DeliveryAddress = DeliveryAddress;
            return this;
        }
        public ShipmentBuilder SetWeight(decimal weight)
        {
            _shipment.Weight = weight;
            return this;
        }

        public ShipmentBuilder SetDimensions(
        decimal length,
        decimal width,
        decimal height)
        {
            _shipment.Length = length;
            _shipment.Width = width;
            _shipment.Height = height;

            return this;
        }
        public ShipmentBuilder SetCustomer(string customerName)
        {
            _shipment.CustomerName = customerName;
            return this;
        }

        public ShipmentBuilder EnableInsurance()
        {
            _shipment.Insurance = true;
            return this;
        }

        public ShipmentBuilder EnablePriority()
        {
            _shipment.Priority = true;
            return this;
        }


        public BuilderShipment Build()
        {
            return _shipment;
        }



    }
}
