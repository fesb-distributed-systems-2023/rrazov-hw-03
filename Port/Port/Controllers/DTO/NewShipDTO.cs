using Port.Models;

namespace Port.Controllers.DTO
{
    public class NewShipDTO
    {

        public string ShipName { get; set; }

        public string PortName { get; set; }

        public string DestinationName { get; set; }

        public int TicketPrice { get; set; }

        public int DepartureTime { get; set; }

        public int ArrivalTime { get; set; }

        public string? DepartureStatus { get; set; }



        public Ship ToModel()
        {
            return new Ship
            {
                ID = -1,
                ShipName = ShipName,
                PortName = PortName,
                DestinationName = DestinationName,
                TicketPrice = TicketPrice,
                DepartureTime = DepartureTime,
                ArrivalTime = ArrivalTime,
                DepartureStatus = DepartureStatus,
                Timestamp = DateTime.MinValue
            };
        }
    }
}
