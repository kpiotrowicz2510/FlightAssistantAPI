namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class airports1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "EndAirport_ID", c => c.Int());
            AddColumn("dbo.Flights", "StartAirport_ID", c => c.Int());
            CreateIndex("dbo.Flights", "EndAirport_ID");
            CreateIndex("dbo.Flights", "StartAirport_ID");
            AddForeignKey("dbo.Flights", "EndAirport_ID", "dbo.Airports", "ID");
            AddForeignKey("dbo.Flights", "StartAirport_ID", "dbo.Airports", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "StartAirport_ID", "dbo.Airports");
            DropForeignKey("dbo.Flights", "EndAirport_ID", "dbo.Airports");
            DropIndex("dbo.Flights", new[] { "StartAirport_ID" });
            DropIndex("dbo.Flights", new[] { "EndAirport_ID" });
            DropColumn("dbo.Flights", "StartAirport_ID");
            DropColumn("dbo.Flights", "EndAirport_ID");
        }
    }
}
