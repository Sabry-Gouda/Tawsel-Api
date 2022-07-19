using Microsoft.EntityFrameworkCore.Migrations;

namespace tawsel.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermissionGroupId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PermissionGroupId",
                table: "AspNetUsers",
                column: "PermissionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Premssions_PermissionGroupId",
                table: "AspNetUsers",
                column: "PermissionGroupId",
                principalTable: "Premssions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Premssions_PermissionGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PermissionGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermissionGroupId",
                table: "AspNetUsers");
        }
    }
}
