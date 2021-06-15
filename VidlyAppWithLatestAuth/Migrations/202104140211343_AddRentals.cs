namespace VidlyAppWithLatestAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        customer_Id = c.Int(nullable: false),
                        Movies_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_Id, cascadeDelete: true)
                .Index(t => t.customer_Id)
                .Index(t => t.Movies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
