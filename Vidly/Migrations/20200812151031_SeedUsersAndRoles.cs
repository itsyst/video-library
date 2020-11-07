using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class SeedUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2ad6e404-90bd-462c-8d3f-e87fb6cc981b', N'guest@vidly.com', N'GUEST@VIDLY.COM', N'guest@vidly.com', N'GUEST@VIDLY.COM', 0, N'AQAAAAEAACcQAAAAEO9TuFpYHdIxAWZKDYdUIfGFkxfMQ+bliZZK0P/mo/XBkiI+RuU6/+g5g8S9oEmoXA==', N'XR5J346QPX4IOWDQESY656MWB37YO5YK', N'a93d034a-f4af-4fac-a595-ef622241174d', NULL, 0, 0, NULL, 1, 0)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6c4e5b5a-47cc-478f-99cb-2209ecd1f23d', N'admin@vidly.com', N'ADMIN@VIDLY.COM', N'admin@vidly.com', N'ADMIN@VIDLY.COM', 0, N'AQAAAAEAACcQAAAAEEaAL0yMawDJ4V0dvcp7/6ErcEf/mGGCZXCT0lTneBRnuiJAWVcjXzDQVGinKdNcEw==', N'IPUF23VMC55ZFQZUBAMPP7QZF2EUKFWL', N'471df4f8-cdcc-474d-a1cd-04c62101b592', NULL, 0, 0, NULL, 1, 0)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'aa4538a5-7d97-489a-b855-821e2075cc25', N'user@vidly.com', N'USER@VIDLY.COM', N'user@vidly.com', N'USER@VIDLY.COM', 0, N'AQAAAAEAACcQAAAAEMl6WMaHseazSYmkuSdwXCbjUCM3jafTLTYzvUSTTXkCFZoz/Xgmm2mk9xFoVLQ00g==', N'JWU3CY75VTDSHMZUYAYE6UYZPK3OYUWB', N'd3dce4b6-a2e8-4591-9346-a854619a8392', NULL, 0, 0, NULL, 1, 0)

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'19f1b87f-9a36-4873-89f4-e7bf9607f8b8', N'admin', N'ADMIN', N'7bd61236-8bc5-4133-a8f8-37a8b86236e1')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'614c86be-4431-4484-99c4-fa93d02058b6', N'user', N'USER', N'd947bd0e-c456-4012-ab10-47d4e91f22ca')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f774fe0f-7047-4447-814d-b4978731bd67', N'guest', N'GUEST', N'bd72ef05-8c63-4acd-a2c1-ce0a899bb6f3')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6c4e5b5a-47cc-478f-99cb-2209ecd1f23d', N'19f1b87f-9a36-4873-89f4-e7bf9607f8b8')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ad6e404-90bd-462c-8d3f-e87fb6cc981b', N'f774fe0f-7047-4447-814d-b4978731bd67')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aa4538a5-7d97-489a-b855-821e2075cc25', N'614c86be-4431-4484-99c4-fa93d02058b6')

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
