using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tawsel.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Branches",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Branches",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Branches",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdDate",
                table: "Branches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Branches",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Branches",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Branches",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerPhone",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
