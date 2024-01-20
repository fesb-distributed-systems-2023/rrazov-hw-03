using Port.Models;

namespace Port.Controllers.DTO
{
    public class ShipInfoDTO
    {

        public int ID { get; set; }

        public string ShipName { get; set; }

        public string PortName { get; set; }

        public string DestinationName { get; set; }

        public int TicketPrice { get; set; }

        public int DepartureTime { get; set; }

        public int ArrivalTime { get; set; }

        public string? DepartureStatus { get; set; }

        public String? TimeStamp { get; set; }


        public static ShipInfoDTO FromModel(Ship model)
        {
            return new ShipInfoDTO
            {
                ID = model.ID,
                ShipName = model.ShipName,
                PortName = model.PortName,
                DestinationName = model.DestinationName,
                TicketPrice = model.TicketPrice,
                DepartureTime = model.DepartureTime,
                ArrivalTime = model.ArrivalTime,
                DepartureStatus = model.DepartureStatus,
                TimeStamp = model.TimeStamp.ToLongTimeString()
            };
        }
    }
}
