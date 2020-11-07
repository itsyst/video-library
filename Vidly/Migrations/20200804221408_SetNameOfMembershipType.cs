using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class SetNameOfMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = NULL");
        }
    }
}