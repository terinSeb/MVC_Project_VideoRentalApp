namespace VidlyAppWithLatestAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePhoneNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
        }
    }
}
