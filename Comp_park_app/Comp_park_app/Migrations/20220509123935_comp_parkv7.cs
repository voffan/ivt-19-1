using Microsoft.EntityFrameworkCore.Migrations;

namespace Comp_park_app.Migrations
{
    public partial class comp_parkv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Peripherals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Computers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Peripherals");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Computers");
        }
    }
}
