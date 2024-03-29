﻿/*
 **********************************
 * Author: Roko Ražov
 * Project Task: Homework 3 - Port
 **********************************
 * Description:
 *  
 *  This file contains model which defines Port class and it's properties.
 *
 **********************************
 */





namespace Port.Models
{
    public class Ship
    {
        public int ID { get; set; }

        public string ShipName { get; set; }

        public string PortName { get; set; }

        public string DestinationName { get; set; }

        public int TicketPrice { get; set; }

        public int DepartureTime { get; set; }

        public int ArrivalTime { get; set; }

        public string? DepartureStatus { get; set; }
        public DateTime TimeStamp { get; set; }



    }
}
