using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightAssistantAPI.Models
{
    public enum FlightEventType
    {
        CheckIn, CheckOut, FlightStart, FlightEnd
    }
    public class FlightEvent
    {
        public int ID { get; set; }
        public FlightEventType Type { get; set; }

        public DateTime Planned { get; set; }

        public DateTime DelayTime { get; set; }

        public byte[] MapImage { get; set; }

        public int BoardingGate { get; set; }
    }
}