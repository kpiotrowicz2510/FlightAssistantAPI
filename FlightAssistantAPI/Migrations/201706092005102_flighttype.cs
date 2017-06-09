namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flighttype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FlightEvents", "BoardingGate", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FlightEvents", "BoardingGate", c => c.Int(nullable: false));
        }
    }
}
