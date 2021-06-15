namespace VidlyAppWithLatestAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNotNull : DbMigration
    {
        public override void Up()
        {                                  
            AlterColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false));
        }
    }
}
