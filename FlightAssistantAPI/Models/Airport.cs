using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightAssistantAPI.Models
{
    public class Airport
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public string HelpNumber { get; set; }
    }
}