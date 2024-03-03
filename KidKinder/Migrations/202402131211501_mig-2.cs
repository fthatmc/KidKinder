namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AddressDetail = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        OpeningHours = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
