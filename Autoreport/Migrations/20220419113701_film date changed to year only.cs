using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoreport.Migrations
{
    public partial class filmdatechangedtoyearonly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Films");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Films",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
