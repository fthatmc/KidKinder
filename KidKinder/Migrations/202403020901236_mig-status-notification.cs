namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migstatusnotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Status");
        }
    }
}
