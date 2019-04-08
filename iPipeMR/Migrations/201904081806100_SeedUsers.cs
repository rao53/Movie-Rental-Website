namespace iPipeMR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27a925ac-06f1-4e3b-b6e2-10756fa8c71e', N'admin@vidly.com', 0, N'AGagWMDzMaOfEZK2wFcwLkjC5e5Epa6KgmGVjN8lMmMttfg6Es98mhSv48CWzZOccg==', N'c7b46c6f-a06f-43b9-add8-dddb0fdf08d8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'39b07da0-5026-440e-a26d-7cda2b6679d1', N'guest@ipipeMR.com', 0, N'AKgQ2UkXL6AueO3oT7Py3hE9BCSHqfmFtps3SR2p24//g34nYqp2wliQLdQjfH+KCw==', N'b6b9992a-a0b8-493c-8e67-bf963f463e5e', NULL, 0, 0, NULL, 1, 0, N'guest@ipipeMR.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'919d371f-6e1d-4c36-baa5-4cd94276d035', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27a925ac-06f1-4e3b-b6e2-10756fa8c71e', N'919d371f-6e1d-4c36-baa5-4cd94276d035')
");
        }
        
        public override void Down()
        {
        }
    }
}
