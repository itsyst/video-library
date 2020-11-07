using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class AddMappingDtosTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipTypeDto",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypeDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    IsSubscribedToNewsLetter = table.Column<bool>(nullable: false),
                    MembershipTypeId = table.Column<byte>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDto_MembershipTypeDto_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypeDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDto_MembershipTypeId",
                table: "CustomerDto",
                column: "MembershipTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDto");

            migrationBuilder.DropTable(
                name: "MembershipTypeDto");
        }
    }
}
