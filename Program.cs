using DESIGN_PATTERN.Patterns.Behavioural.ObserverPattern;
using DESIGN_PATTERN.Patterns.Creational.BuilderPattern;
using DESIGN_PATTERN.Patterns.Creational.FactoryMethod;
using DESIGN_PATTERN.Patterns.Creational.Singleton;

#region Singleton Method
//Console.WriteLine("--- Singleton ---");
//var config1 = ConfigurationManager.Instance;
//var config2 = ConfigurationManager.Instance;

//config1.SetEnvironment("Production");

//Console.WriteLine($"config1.Environment = {config1.Environment}");
//Console.WriteLine($"config2.Environment = {config2.Environment}");
//Console.WriteLine($"Same instance? {ReferenceEquals(config1, config2)}");

//Console.WriteLine();

#endregion


#region Factory Pattern

//Console.WriteLine("--- Factory Method ---");
//NotificationFactory factory = new EmailNotificationFactory();
//factory.Notify("Your order has shipped.");

//factory = new SmsNotificationFactory();
//factory.Notify("Your order has shipped.");

/* Method factory Pattern */

//NotificationFactory factory = new EmailNotificationFactory();
//factory.Notify("Hello SMS");

//NotificationFactory factory1 = new SMSNotificationFactory();
//factory1.Notify("Hello SMS");

/*End*/

#endregion


#region Builder Design Pattern

/* What builder pattern solve in case we have multiple parameter to create booking Ex - Shipment Number, shipment type, address etc...*/


//BuilderShipment shipment = new ShipmentBuilder()
//            .SetShipmentNumber("XPCN-1001")
//            .SetShipmentType("LCL")
//            .SetPickupAddress("Delhi")
//            .SetDeliveryAddress("Mumbai")
//            .SetWeight(500)
//            .SetDimensions(10, 5, 4)
//            .SetCustomer("ABC Logistics")
//            .EnableInsurance()
//            .EnablePriority()
//            .Build();

//Console.WriteLine($"Shipment: {shipment.ShipmentNumber}");
//Console.WriteLine($"Type: {shipment.ShipmentType}");
//Console.WriteLine($"Pickup: {shipment.PickupAddress}");
//Console.WriteLine($"Delivery: {shipment.DeliveryAddress}");
//Console.WriteLine($"Weight: {shipment.Weight} KG");
//Console.WriteLine($"Customer: {shipment.CustomerName}");
//Console.WriteLine($"Insurance: {shipment.Insurance}");
//Console.WriteLine($"Priority: {shipment.Priority}");

#endregion


#region Observer Pattern

/* The observer pattern is behavioural design pattern in which one oject (Publish) notifies multiple dependency objects (Observer) whenever
    its state changes.
    Ex- When status is updated we need to send mail, sms, analytics etc


Main components:
Component	                    Responsibility
Publisher / Subject	            Maintains state and notifies observers
Observer	                    Receives notifications
Concrete Observer	            Implements notification behavior
Subscribe	                    Registers an observer
Unsubscribe	                    Removes an observer
Notify	                        Sends updates to observers
 */




//var publisher = new ShipementPublisher();

//var sms = new SmsNotificationObserver();

//var email = new EmailNotificationObserver();

//var tracking = new TrackingObserver();


//publisher.Subscribe(sms);
//publisher.Subscribe(email);
//publisher.Subscribe(tracking);


//publisher.ChangeStatus("XPCN10000", "ORDER_PICKED");


//publisher.Unsubscribe(email);


//publisher.ChangeStatus("XPCN10000", "ORDER_DELIVERED");



/*
 In c# we have Events and Deligates for same obeserver pattern we have
 */


var shipment = new ShipmentsPublisher
{
    ShipmentNumber = "XPCN00001"
};


var SMS = new SmsService();
var EMAIL = new EmailService();


//Subscribed
shipment.statusChanged += SMS.SendSMS;
shipment.statusChanged += EMAIL.SendEMAIL;


shipment.changeStatus("IN-TRANSHIT");


//Unsubscribed
shipment.statusChanged -= EMAIL.SendEMAIL;


shipment.changeStatus("DELIVERED");



#endregion