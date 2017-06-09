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
        public DateTime FlightDate { get; set; }

        public string Aircraft = "Boeing 737-800";
        public DateTime ServerTime { get { return DateTime.Now; } }

        public virtual Airport StartAirport { get; set; }
        public virtual Airport EndAirport { get; set; }
        public virtual List<FlightEvent> Events { get; set; }
    }
}