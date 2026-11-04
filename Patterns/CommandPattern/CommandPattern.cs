using System;
using System.Collections.Generic;
using System.Text;

namespace DESIGN_PATTERN.Patterns.CommandPattern
{
    /*
     
     Here on Command Pattern instead of directly calling a method, we create an object that represents the action we want to perform.

     */

    /*
     NOTES - Error CS0051: "Inconsistent accessibility: parameter type 'ShipmentService'
             is less accessible than method 'DispatchShipmentHandler(...)'"

     WHY IT HAPPENS:
       - DispatchShipmentHandler is PUBLIC, so its public constructor can be called from ANY assembly.
       - But ShipmentService, VehicleService, ManifestService, NotificationService were INTERNAL
         (visible only inside this project/assembly).
       - An outside caller could "see" the constructor but could not create/see its parameter types.
         C# does not allow that, so it raises a compile error.

     RULE:
       A public member's signature (parameters, return type, base class, property type)
       must only use types that are AT LEAST as accessible as the member itself.

     ACCESS LEVELS (most -> least open):
       public > protected internal > internal / protected > private protected > private

     FIX OPTIONS:
       1. Make the dependencies public            (done here)
       2. Make the handler internal too           -> internal class DispatchShipmentHandler
       3. Best practice: depend on public INTERFACES (IShipmentService etc.) and keep
          the concrete classes internal. Works well with Dependency Injection.

     NOTE: A class with no access modifier at namespace level is INTERNAL by default.
     */


    //Create command

    public class DispatchShipmentCommand
    {
        public int ShipmentId { get; set; }

        public DispatchShipmentCommand(int shipmentId)
        {
            ShipmentId = shipmentId;
        }
    }


    //Create handler
    public class DispatchShipmentHandler
    {
        private readonly ShipmentService _shipmentService;
        private readonly VehicleService _vehicleService;
        private readonly ManifestService _manifestService;
        private readonly NotificationService _notificationService;

        public DispatchShipmentHandler(
            ShipmentService shipmentService,
            VehicleService vehicleService,
            ManifestService manifestService,
            NotificationService notificationService)
        {
            _shipmentService = shipmentService;
            _vehicleService = vehicleService;
            _manifestService = manifestService;
            _notificationService = notificationService;
        }

        public void Handle(DispatchShipmentCommand command)
        {
            int shipmentId = command.ShipmentId;

            _shipmentService.Validate(shipmentId);

            _vehicleService.AssignVehicle(shipmentId);

            _manifestService.Generate(shipmentId);

            _shipmentService.UpdateStatus(shipmentId, "DISPATCHED");

            _notificationService.Send(shipmentId);
        }
    }

    public class ManifestService
    {
        public void Generate(int id)
        {
            Console.WriteLine($"Generate: {id}");
        }
    }

    public class VehicleService
    {
        public void AssignVehicle(int id)
        {

            Console.WriteLine($"AssignVehicle: {id}");

        }
    }

    public class ShipmentService
    {
        public void Validate(int id)
        {

            Console.WriteLine($"Validate: {id}");

        }

        public void UpdateStatus(int id, string status)
        {

            Console.WriteLine($"UpdateStatus: {id} and status: {status}");

        }
    }

    public class NotificationService
    {
        public void Send(int id)
        {

            Console.WriteLine($"Send: {id}");

        }
    }


    //You can add multiple commands EX:
    //public interface ICommandHandler<TCommand>
    //{
    //    void Handle(TCommand command);
    //}


    // NOW ADD CONTROLLER 

    //[HttpPost("dispatch/{shipmentId}")]
    //    public IActionResult Dispatch(int shipmentId)
    //    {
    //        var command = new DispatchShipmentCommand(shipmentId);

    //        _dispatchHandler.Handle(command);

    //        return Ok("Shipment dispatched");
    //    }



}
