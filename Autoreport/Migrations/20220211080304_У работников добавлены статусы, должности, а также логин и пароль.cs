using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Autoreport.Migrations
{
    public partial class Уработниковдобавленыстатусыдолжностиатакжелогинипароль : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    General_count = table.Column<int>(type: "int", nullable: false),
                    Current_count = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    First_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Second_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Phone_number1 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Phone_number2 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Order_count = table.Column<int>(type: "int", nullable: true),
                    Debt_count = table.Column<int>(type: "int", nullable: true),
                    Passport_serial = table.Column<int>(type: "int", nullable: true),
                    Passport_number = table.Column<int>(type: "int", nullable: true),
                    Phone_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EmplStatus = table.Column<int>(type: "int", nullable: true),
                    EmplPosition = table.Column<int>(type: "int", nullable: true),
                    Login = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<double>(type: "double", nullable: false),
                    Order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Return_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderClientId = table.Column<int>(type: "int", nullable: true),
                    OrderEmployeerId = table.Column<int>(type: "int", nullable: true),
                    OrderDepositId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Deposits_OrderDepositId",
                        column: x => x.OrderDepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_OrderClientId",
                        column: x => x.OrderClientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_OrderEmployeerId",
                        column: x => x.OrderEmployeerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    FilmCountyId = table.Column<int>(type: "int", nullable: true),
                    FilmStudioId = table.Column<int>(type: "int", nullable: true),
                    FilmDirectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Countries_FilmCountyId",
                        column: x => x.FilmCountyId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Films_Persons_FilmDirectorId",
                        column: x => x.FilmDirectorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Films_Studios_FilmStudioId",
                        column: x => x.FilmStudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "FilmGenre",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
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

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenresId",
                table: "FilmGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_FilmCountyId",
                table: "Films",
                column: "FilmCountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_FilmDirectorId",
                table: "Films",
                column: "FilmDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_FilmStudioId",
                table: "Films",
                column: "FilmStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderClientId",
                table: "Orders",
                column: "OrderClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDepositId",
                table: "Orders",
                column: "OrderDepositId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderEmployeerId",
                table: "Orders",
                column: "OrderEmployeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskFilm");

            migrationBuilder.DropTable(
                name: "DiskOrder");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "Disks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
