using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class depositvalueandmoneyfieldchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Deposits",
                newName: "DocumentData");

            migrationBuilder.AddColumn<uint>(
                name: "MoneyValue",
                table: "Deposits",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyValue",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "DocumentData",
                table: "Deposits",
                newName: "Data");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Deposits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
