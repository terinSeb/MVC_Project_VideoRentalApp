namespace VidlyAppWithLatestAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'29489a7d-9d6f-41ef-b7a0-aed36dbf2874', NULL, NULL, N'terins@kruxsoft.com', 0, N'ACMP9U1NmGorUaYeGy6UNKsMeIOl0aZVdogpNTmps/Wy9+cZQUU1czTZsbJV4b24xg==', N'4bdf4112-bab8-4c46-8d40-24db6be24a9f', NULL, 0, 0, NULL, 1, 0, N'terins@kruxsoft.com')
INSERT [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7a92dcaf-db8c-49e6-81cf-98631650b439', NULL, NULL, N'admin@vidly.com', 0, N'APc3dHqezvL6p/MmC3UKyAfBXsqid01SKV/VpM4y2iZyAwp38PTf31lOP1jtZozYig==', N'37aa3d77-8d3b-4034-97d0-2f688c0186d6', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0b2097f8-e689-4930-ad32-1e0b810aff5c', N'CanManageMovies')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7a92dcaf-db8c-49e6-81cf-98631650b439', N'0b2097f8-e689-4930-ad32-1e0b810aff5c')
");
        }
        
        public override void Down()
        {
        }
    }
}
