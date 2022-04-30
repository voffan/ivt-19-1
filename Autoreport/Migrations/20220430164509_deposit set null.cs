using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class depositsetnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deposits_OrderDepositId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDepositId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DepositId",
                table: "Orders",
                column: "DepositId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deposits_DepositId",
                table: "Orders",
                column: "DepositId",
                principalTable: "Deposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deposits_DepositId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DepositId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DepositId",
                table: "Orders",
                column: "DepositId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deposits_DepositId",
                table: "Orders",
                column: "DepositId",
                principalTable: "Deposits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
