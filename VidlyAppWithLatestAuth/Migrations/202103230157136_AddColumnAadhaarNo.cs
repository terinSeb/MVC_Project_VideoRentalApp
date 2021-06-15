namespace VidlyAppWithLatestAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnAadhaarNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AAdhaarNo", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AAdhaarNo");
        }
    }
}
