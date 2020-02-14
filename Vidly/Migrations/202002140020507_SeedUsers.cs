namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'13005ce3-cd5c-4b0d-80b9-127700c63c1d', N'admin@vidly.com', 0, N'AEA6V8J7SmkQ13ZZiOJOcwT3Lu7ldzt/z/qKdIvuKl1roJ9kGiBojJMCCsBzyqVItQ==', N'a22c8737-468f-4f93-ab37-becab0923a56', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ddd7cfcf-dffa-4c80-8a36-35acd94088f7', N'guest@vidly.com', 0, N'AGwr56qTJq2RHJCJnF67D5zqTTsLwlMcS9CROvk1jqYywdcNBhEb2MwtBvnjWcIsaQ==', N'9814fd53-4b34-4145-af66-1c051e447855', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e04c58d-ffcd-4f89-8805-3d7142cb16e2', N'CanManageMovies')                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'13005ce3-cd5c-4b0d-80b9-127700c63c1d', N'1e04c58d-ffcd-4f89-8805-3d7142cb16e2')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
