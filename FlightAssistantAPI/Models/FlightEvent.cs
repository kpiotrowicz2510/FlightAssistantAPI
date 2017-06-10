using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightAssistantAPI.Models
{
      public enum FlightEventType
    {
        CheckInOnline, CheckInOffline, SecurityCheck, Boarding, FlightStart, FlightEnd, LuggageRetrival
    }
    public class FlightEvent
    {
        public const string BASE_URL = "http://flightassistant.azurewebsites.net/Content/Images/";

        public int ID { get; set; }
        public FlightEventType Type { get; set; }

        public string TypeName { get
            {
                switch (Type)
                {
                    case FlightEventType.Boarding:
                        return "Boarding at GATE " + BoardingGate;
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
                    case FlightEventType.LuggageRetrival:
                        return "Luggage retrival";
                    default:
                        return "Unknown type";

                }
            } }
        public int MinutesLeft { get {
                return (int)Math.Floor((DelayTime - DateTime.Now).TotalMinutes);
            } }
        public DateTime Planned { get; set; }

        public DateTime DelayTime { get; set; }

        public string MapImage { get {
                switch (Type)
                {
                    case FlightEventType.Boarding:
                        return BASE_URL + "boarding_map.png";
                    case FlightEventType.CheckInOnline:
                        return BASE_URL + "check_in_map.png";
                    case FlightEventType.CheckInOffline:
                        return BASE_URL + "check_in_map.png";
                    case FlightEventType.SecurityCheck:
                        return BASE_URL + "security_check_map.png";
                    case FlightEventType.FlightStart:
                        return "";
                    case FlightEventType.FlightEnd:
                        return "";
                    case FlightEventType.LuggageRetrival:
                        return BASE_URL + "luggage_retrival_map.png";
                    default:
                        return "";

                }
            } }

        public int? BoardingGate { get; set; }

        //IsDone.isactive,ispending

        public bool IsDone { get
            {
                if(DelayTime < DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsActive
        {
            get;set;
        }

        public bool IsPending
        {
            get
            {
                if (DelayTime > DateTime.Now&&!IsActive&&!IsDone)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}