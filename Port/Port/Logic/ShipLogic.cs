using Microsoft.Extensions.Options;
using Port.Models;
using Port.Repositories;
using System.Text.RegularExpressions;
using System.Reflection;
using Port.Exceptions;
using Port.Configuration;
using System;

namespace Port.Logic
{
    public class ShipLogic : IShipLogic
    {
        private readonly IShipRepository _shipRepository;
        private readonly ValidationConfiguration _validationConfiguration;

        public ShipLogic(IShipRepository shipRepository, IOptions<ValidationConfiguration> configuration)
        {
            _shipRepository = shipRepository;
            _validationConfiguration = configuration.Value;
        }

        private void ValidateShipNameField(string? shipName)
        {
            if (shipName is null)
            {
                throw new UserErrorMessage("Ship name field cannot be empty.");
            }

            if (shipName.Length > _validationConfiguration.ShipNameMaxCharacters)
            {
                throw new UserErrorMessage($"Ship name field too long. Exceeded {_validationConfiguration.ShipNameMaxCharacters} characters");
            }

        }

        private void ValidatePortNameField(string? portName)
        {
            if (string.IsNullOrEmpty(portName))
            {
                throw new UserErrorMessage("Email subject cannot be empty.");
            }

            if (portName.Length > _validationConfiguration.PorNameMaxCharacters)
            {
                throw new UserErrorMessage($"Subject field too long. Exceeded {_validationConfiguration.PorNameMaxCharacters} characters");
            }

        }

        private void ValidateDestinationNameField(string? destinationName)
        {
            if (string.IsNullOrEmpty(destinationName))
            {
                throw new UserErrorMessage("Destination name cannot be empty.");
            }

            if (destinationName.Length > _validationConfiguration.DestinationNameMaxCharacters)
            {
                throw new UserErrorMessage($"Subject field too long. Exceeded {_validationConfiguration.DestinationNameMaxCharacters} characters");
            }
        }

        private void ValidateDepartureStatusField(string? departureStatus)
        {
            if (string.IsNullOrEmpty(departureStatus))
            {
                throw new UserErrorMessage("Departure status field cannot be empty.");
            }

            if (departureStatus.Length > _validationConfiguration.DepartureStatusMaxCharacters)
            {
                throw new UserErrorMessage($"Departure status field too long. Exceeded {_validationConfiguration.DepartureStatusMaxCharacters} characters");
            }

        }

        private void ValidateTicketPriceField(int ticketPrice)
        {
            if (int.Equals==null)
            {
                throw new UserErrorMessage("Departure status field cannot be empty.");
            }

            if (ticketPrice.GetType()==typeof(string))
            {
                throw new UserErrorMessage("Ticket price field must be number.");
            }

        }

        private void ValidateDepartureTimeField(int departureTime)
        {
            if (int.Equals == null)
            {
                throw new UserErrorMessage("Departure time field cannot be empty.");
            }

            if (departureTime.GetType() == typeof(string))
            {
                throw new UserErrorMessage("Departure time field must be number.");
            }

        }

        private void ValidateArrivaleTimeField(int arrivaleTime)
        {
            if (int.Equals == null)
            {
                throw new UserErrorMessage("Arrivale time field cannot be empty.");
            }

            if (arrivaleTime.GetType() == typeof(string))
            {
                throw new UserErrorMessage("Arrivale time field must be number.");
            }

        }

        public void AddNewShip(Ship? ship)
        {
            // Check all arguments
            if (ship is null)
            {
                throw new UserErrorMessage("Cannot create a new ship. No ship specified or the ship is invalid.");
            }

            // Sanitize inputs
            ship.ID = -1;

            /*// Body CAN be empty, just make sure it is not null
            if (email.Body is null)
            {
                email.Body = string.Empty;
            }*/

            ValidateShipNameField(ship.ShipName);
            ValidatePortNameField(ship.PortName);
            ValidateDestinationNameField(ship.DestinationName);
            ValidateDepartureStatusField(ship.DepartureStatus);
            ValidateTicketPriceField(ship.TicketPrice);
            ValidateDepartureTimeField(ship.DepartureTime);
            ValidateArrivaleTimeField(ship.ArrivalTime);



            // All fields validated, continue...

            // Set ship timestamp to current time
            // (use UTC for cross-timezone compatibility)
            ship.Timestamp = DateTime.UtcNow;

            _shipRepository.CreateNewShip(ship);
        }

        public void RemoveShip(int id)
        {
            _shipRepository.DeleteShip(id);
        }

        public Ship? GetShipById(int id)
        {
            return _shipRepository.GetShipById(id);
        }

        public IEnumerable<Ship> GetEmails()
        {
            return _shipRepository.GetAllShips();
        }




    }
}
