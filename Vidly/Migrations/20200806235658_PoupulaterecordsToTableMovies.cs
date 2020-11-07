using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class PoupulaterecordsToTableMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Movies ON");
            migrationBuilder.Sql("INSERT INTO Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES (1,'Hangover',5,'2009/06/09','2020/01/01',5)");
            migrationBuilder.Sql("INSERT INTO Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES (2,'Die Hard',1,'1988/11/30','2020/01/01',5)");
            migrationBuilder.Sql("INSERT INTO Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES (3,'The Terminator',1,'1985/02/08','2020/01/01',5)");
            migrationBuilder.Sql("INSERT INTO Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES (4,'Toy Story',3,'1996/03/08','2020/01/01',5)");
            migrationBuilder.Sql("INSERT INTO Movies (Id,Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES (5,'Titanic',4,'1998/01/16','2020/01/01',5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Movies OFF");
            migrationBuilder.Sql("DELETE FROM Movies");

        }
    }
}