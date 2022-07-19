using Microsoft.EntityFrameworkCore.Migrations;

namespace tawsel.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Premssions_PermissionGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PermissionGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermissionGroupId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

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
    }
}
