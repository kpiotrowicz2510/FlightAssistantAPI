namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flightdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "FlightDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "FlightDate");
        }
    }
}
