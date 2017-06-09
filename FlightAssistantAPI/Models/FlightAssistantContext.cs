using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlightAssistantAPI.Models
{
    public class FlightAssistantContext: DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public FlightAssistantContext(): base("DefaultConnection")
        {

        }
    }
}