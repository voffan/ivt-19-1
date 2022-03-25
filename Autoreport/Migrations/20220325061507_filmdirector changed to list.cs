using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class filmdirectorchangedtolist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Persons_FilmDirectorId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_FilmDirectorId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "FilmDirectorId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FilmId",
                table: "Persons",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Films_FilmId",
                table: "Persons",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Films_FilmId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_FilmId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "FilmDirectorId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_FilmDirectorId",
                table: "Films",
                column: "FilmDirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Persons_FilmDirectorId",
                table: "Films",
                column: "FilmDirectorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
