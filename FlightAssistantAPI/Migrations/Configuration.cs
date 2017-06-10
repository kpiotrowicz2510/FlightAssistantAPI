namespace FlightAssistantAPI.Migrations
{
    using FlightAssistantAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlightAssistantAPI.Models.FlightAssistantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FlightAssistantAPI.Models.FlightAssistantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Airports.AddOrUpdate(
                a => a.ID,
                new Models.Airport() { ID = 1, ShortName = "GDA", FullName = "Gdansk Airport", HelpNumber = "0048567843231" },
new Models.Airport() { ID = 2, ShortName = "WAW", FullName = "Warsaw Airport", HelpNumber = "0048567843231" },
new Models.Airport() { ID = 3, ShortName = "BER", FullName = "Berlin Airport", HelpNumber = "0048567843231" }
                );

            context.Flights.AddOrUpdate(
                a => a.ID,
                new Models.Flight() { ID = 1, FlightNumber = "ABC123", StartAirport = context.Airports.First(o => o.ID == 1), EndAirport = context.Airports.First(o => o.ID == 2), FlightDate = new DateTime(2017, 8, 10, 12, 30, 0) },
                new Models.Flight() { ID = 2, FlightNumber = "DEF456", StartAirport = context.Airports.First(o => o.ID == 1), EndAirport = context.Airports.First(o => o.ID == 3), FlightDate = new DateTime(2017, 7, 9, 22, 34, 0) },
                new Models.Flight() { ID = 3, FlightNumber = "GHI789", StartAirport = context.Airports.First(o => o.ID == 2), EndAirport = context.Airports.First(o => o.ID == 1), FlightDate = new DateTime(2017, 6, 9, 22, 56, 0) }
                );

            context.Flights.Include("Events").Where(flight => flight.FlightNumber == "ABC123").First().Events =
                new List<FlightEvent>() {
                new Models.FlightEvent()
                {
                    Type = Models.FlightEventType.CheckInOnline,
                    Planned = DateTime.Now,
                    DelayTime = DateTime.Now
                },
                new Models.FlightEvent()
                {
                    Type = Models.FlightEventType.SecurityCheck,
                    Planned = DateTime.Now.AddMinutes(30),
                    DelayTime = DateTime.Now.AddMinutes(30)
                },
                new Models.FlightEvent()
                {
                    Type = Models.FlightEventType.Boarding,
                    Planned = DateTime.Now.AddHours(1.5),
                    DelayTime = DateTime.Now.AddHours(1.5),
                    BoardingGate = 10
                },
                new Models.FlightEvent()
                {
                    Type = Models.FlightEventType.FlightStart,
                    Planned = DateTime.Now.AddHours(2.5),
                    DelayTime = DateTime.Now.AddHours(2.5)
                },
                new Models.FlightEvent()
                {
                    Type = Models.FlightEventType.FlightEnd,
                    Planned = DateTime.Now.AddHours(4.5),
                    DelayTime = DateTime.Now.AddHours(4.5)
                },
                new Models.FlightEvent()
                {
                    Type = Models.FlightEventType.LuggageRetrival,
                    Planned = DateTime.Now.AddHours(5),
                    DelayTime = DateTime.Now.AddHours(5)
                }
            };
        }
    }
}
