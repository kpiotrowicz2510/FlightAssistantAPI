namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donepending : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightEvents", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlightEvents", "IsActive");
        }
    }
}
