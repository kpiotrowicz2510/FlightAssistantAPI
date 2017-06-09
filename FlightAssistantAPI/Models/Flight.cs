using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightAssistantAPI.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public Airport StartAirport { get; set; }
        public Airport EndAirport { get; set; }
        public virtual List<FlightEvent> Events { get; set; }
    }
}