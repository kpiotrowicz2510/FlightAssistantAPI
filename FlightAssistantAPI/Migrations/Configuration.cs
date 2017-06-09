namespace FlightAssistantAPI.Migrations
{
    using System;
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
                new Models.Airport() { ID = 1, ShortName = "GDA", FullName = "Gdansk Airport", HelpNumber = "0048567843231"},
new Models.Airport() { ID = 2, ShortName = "WAW", FullName = "Warsaw Airport", HelpNumber = "0048567843231" },
new Models.Airport() { ID = 3, ShortName = "BER", FullName = "Berlin Airport", HelpNumber = "0048567843231" }
                );

            context.Flights.AddOrUpdate(
                a=>a.ID,
                new Models.Flight() {  ID = 1, FlightNumber="ABC123", StartAirport = context.Airports.First(o=>o.ID==1), EndAirport = context.Airports.First(o => o.ID == 2)},
                new Models.Flight() { ID = 2, FlightNumber = "DEF456", StartAirport = context.Airports.First(o => o.ID == 1), EndAirport = context.Airports.First(o => o.ID == 3) },
                new Models.Flight() { ID = 3, FlightNumber = "GHI789", StartAirport = context.Airports.First(o => o.ID == 2), EndAirport = context.Airports.First(o => o.ID == 1) }
                );


        }
    }
}
