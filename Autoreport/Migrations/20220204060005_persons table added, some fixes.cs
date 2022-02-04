using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Autoreport.Migrations
{
    public partial class personstableaddedsomefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Director_FilmDirectorId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_OrderClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employeers_OrderEmployeerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employeers",
                table: "Employeers");

            migrationBuilder.RenameTable(
                name: "Employeers",
                newName: "Persons");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Orders",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Disks",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Passport_serial",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Passport_number",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Debt_count",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Order_count",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_number1",
                table: "Persons",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_number2",
                table: "Persons",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Persons_FilmDirectorId",
                table: "Films",
                column: "FilmDirectorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_OrderClientId",
                table: "Orders",
                column: "OrderClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_OrderEmployeerId",
                table: "Orders",
                column: "OrderEmployeerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Persons_FilmDirectorId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_OrderClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_OrderEmployeerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Debt_count",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Order_count",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Phone_number1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Phone_number2",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Employeers");

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "Disks",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "Passport_serial",
                table: "Employeers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Passport_number",
                table: "Employeers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employeers",
                table: "Employeers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Debt_count = table.Column<int>(type: "int", nullable: false),
                    First_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Order_count = table.Column<int>(type: "int", nullable: false),
                    Phone_number1 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Phone_number2 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Second_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    First_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Second_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Director_FilmDirectorId",
                table: "Films",
                column: "FilmDirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_OrderClientId",
                table: "Orders",
                column: "OrderClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employeers_OrderEmployeerId",
                table: "Orders",
                column: "OrderEmployeerId",
                principalTable: "Employeers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
