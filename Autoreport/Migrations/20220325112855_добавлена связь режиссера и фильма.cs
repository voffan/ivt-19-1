using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class добавленасвязьрежиссераифильма : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FilmPerson",
                columns: table => new
                {
                    FilmDirectorsId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPerson", x => new { x.FilmDirectorsId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_FilmPerson_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPerson_Persons_FilmDirectorsId",
                        column: x => x.FilmDirectorsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPerson_FilmsId",
                table: "FilmPerson",
                column: "FilmsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmPerson");

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
    }
}
