namespace Port.Configuration
{
    public class ValidationConfiguration
    {
        public int ShipNameMaxCharacters { get; set; }
        public int PorNameMaxCharacters { get; set; }
        public int DestinationNameMaxCharacters { get; set; }
        public int DepartureStatusMaxCharacters { get; set; }
        public int TicketPriceIsInt { get; set; }
        public int DepartureTimeIsInt { get; set; }
        public int ArrivaleTimeIsInt { get; set; }


    }
}
