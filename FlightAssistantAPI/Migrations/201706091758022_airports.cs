namespace FlightAssistantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class airports : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Airports", "Shortcut");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Airports", "Shortcut", c => c.String());
        }
    }
}
