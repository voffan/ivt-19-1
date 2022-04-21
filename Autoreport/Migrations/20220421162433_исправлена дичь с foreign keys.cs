using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class исправленадичьсforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderClientId",
                table: "Orders",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "OrderDepositId",
                table: "Orders",
                newName: "DepositId");

            migrationBuilder.RenameColumn(
                name: "OrderEmployeerId",
                table: "Orders",
                newName: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Orders",
                newName: "OrderClientId");

            migrationBuilder.RenameColumn(
                name: "DepositId",
                table: "Orders",
                newName: "OrderDepositId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Orders",
                newName: "OrderEmployeerId");
        }
    }
}
