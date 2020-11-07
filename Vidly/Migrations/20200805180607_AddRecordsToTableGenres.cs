using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class AddRecordsToTableGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Genres ON");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            migrationBuilder.Sql("SET IDENTITY_INSERT Genres OFF");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Genres OFF");
            migrationBuilder.Sql("DELETE FROM Genres");
       
        }
    }
}
