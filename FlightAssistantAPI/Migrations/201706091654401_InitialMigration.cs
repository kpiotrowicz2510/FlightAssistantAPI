namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Shortcut = c.String(),
                        FullName = c.String(),
                        ShortName = c.String(),
                        HelpNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FlightEvents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Planned = c.DateTime(nullable: false),
                        DelayTime = c.DateTime(nullable: false),
                        MapImage = c.Binary(),
                        BoardingGate = c.Int(nullable: false),
                        Flight_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flights", t => t.Flight_ID)
                .Index(t => t.Flight_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightEvents", "Flight_ID", "dbo.Flights");
            DropIndex("dbo.FlightEvents", new[] { "Flight_ID" });
            DropTable("dbo.FlightEvents");
            DropTable("dbo.Flights");
            DropTable("dbo.Airports");
        }
    }
}
