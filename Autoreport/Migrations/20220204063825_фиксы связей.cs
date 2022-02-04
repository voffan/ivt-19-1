using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class фиксысвязей : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disks_Orders_OrderId",
                table: "Disks");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Disks_DiskId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_DiskId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Disks_OrderId",
                table: "Disks");

            migrationBuilder.DropColumn(
                name: "DiskId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Disks");

            migrationBuilder.CreateTable(
                name: "DiskFilm",
                columns: table => new
                {
                    DisksId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskFilm", x => new { x.DisksId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_DiskFilm_Disks_DisksId",
                        column: x => x.DisksId,
                        principalTable: "Disks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiskFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiskOrder",
                columns: table => new
                {
                    DisksId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskOrder", x => new { x.DisksId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DiskOrder_Disks_DisksId",
                        column: x => x.DisksId,
                        principalTable: "Disks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiskOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiskFilm_FilmsId",
                table: "DiskFilm",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_DiskOrder_OrdersId",
                table: "DiskOrder",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskFilm");

            migrationBuilder.DropTable(
                name: "DiskOrder");

            migrationBuilder.AddColumn<int>(
                name: "DiskId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Disks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_DiskId",
                table: "Films",
                column: "DiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Disks_OrderId",
                table: "Disks",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disks_Orders_OrderId",
                table: "Disks",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Disks_DiskId",
                table: "Films",
                column: "DiskId",
                principalTable: "Disks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
