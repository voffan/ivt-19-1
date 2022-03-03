using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Films",
                newName: "Year");

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "Disks",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Deposits",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Deposits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disks_Article",
                table: "Disks",
                column: "Article",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_OwnerId",
                table: "Deposits",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Persons_OwnerId",
                table: "Deposits",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Persons_OwnerId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Disks_Article",
                table: "Disks");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_OwnerId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Films",
                newName: "year");

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "Disks",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Deposits",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
