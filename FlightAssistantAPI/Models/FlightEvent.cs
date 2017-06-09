using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightAssistantAPI.Models
{
    public enum FlightEventType
    {
        CheckInOnline, CheckInOffline, SecurityCheck, Boarding, FlightStart, FlightEnd
    }
    public class FlightEvent
    {
        public int ID { get; set; }
        public FlightEventType Type { get; set; }

        public string TypeName { get
            {
                switch (Type)
                {
                    case FlightEventType.Boarding:
                        return "Boarding on " + BoardingGate;
                    case FlightEventType.CheckInOnline:
                        return "Checkin online";
                    case FlightEventType.CheckInOffline:
                        return "Checkin offline";
                    case FlightEventType.SecurityCheck:
                        return "Security Check";
                    case FlightEventType.FlightStart:
                        return "Take off";
                    case FlightEventType.FlightEnd:
                        return "Landing";
                    
                    default:
                        return "Unknown type";

                }
            } }
        public int MinutesLeft { get {
                return (int)Math.Floor((Planned - DateTime.Now).TotalMinutes);
            } }
        public DateTime Planned { get; set; }

        public DateTime DelayTime { get; set; }

        public byte[] MapImage { get; set; }

        public int? BoardingGate { get; set; }
    }
}