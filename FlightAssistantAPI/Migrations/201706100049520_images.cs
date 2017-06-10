namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FlightEvents", "MapImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FlightEvents", "MapImage", c => c.Binary());
        }
    }
}
