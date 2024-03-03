namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_class_bookaseat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookASeats", "Class", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookASeats", "Class");
        }
    }
}
