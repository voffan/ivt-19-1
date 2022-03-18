using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class filmtablefilmcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Countries_FilmCountyId",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "FilmCountyId",
                table: "Films",
                newName: "FilmCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Films_FilmCountyId",
                table: "Films",
                newName: "IX_Films_FilmCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Countries_FilmCountryId",
                table: "Films",
                column: "FilmCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Countries_FilmCountryId",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "FilmCountryId",
                table: "Films",
                newName: "FilmCountyId");

            migrationBuilder.RenameIndex(
                name: "IX_Films_FilmCountryId",
                table: "Films",
                newName: "IX_Films_FilmCountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Countries_FilmCountyId",
                table: "Films",
                column: "FilmCountyId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
