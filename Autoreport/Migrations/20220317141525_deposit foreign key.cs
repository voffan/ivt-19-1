using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class depositforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Persons_OwnerId",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Deposits",
                newName: "TypePosition");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Deposits",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_OwnerId",
                table: "Deposits",
                newName: "IX_Deposits_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Persons_ClientId",
                table: "Deposits",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Persons_ClientId",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "TypePosition",
                table: "Deposits",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Deposits",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_ClientId",
                table: "Deposits",
                newName: "IX_Deposits_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Persons_OwnerId",
                table: "Deposits",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
