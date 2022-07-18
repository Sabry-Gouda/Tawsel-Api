using Microsoft.EntityFrameworkCore.Migrations;

namespace tawsel.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_AspNetRoles_CustomRoleId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_Controllers_controllerId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_Premssions_Premission",
                table: "PremissionRoleControllers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PremissionRoleControllers",
                table: "PremissionRoleControllers");

            migrationBuilder.DropIndex(
                name: "IX_PremissionRoleControllers_CustomRoleId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PremissionRoleControllers");

            migrationBuilder.DropColumn(
                name: "CustomRoleId",
                table: "PremissionRoleControllers");

            migrationBuilder.RenameColumn(
                name: "controllerId",
                table: "PremissionRoleControllers",
                newName: "permissionId");

            migrationBuilder.RenameColumn(
                name: "Premission",
                table: "PremissionRoleControllers",
                newName: "PageId");

            migrationBuilder.RenameIndex(
                name: "IX_PremissionRoleControllers_Premission",
                table: "PremissionRoleControllers",
                newName: "IX_PremissionRoleControllers_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_PremissionRoleControllers_controllerId",
                table: "PremissionRoleControllers",
                newName: "IX_PremissionRoleControllers_permissionId");

            migrationBuilder.AddColumn<string>(
                name: "RoleID",
                table: "PremissionRoleControllers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "controllersId",
                table: "PremissionRoleControllers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PremissionRoleControllers",
                table: "PremissionRoleControllers",
                columns: new[] { "RoleID", "PageId", "permissionId" });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PremissionRoleControllers_controllersId",
                table: "PremissionRoleControllers",
                column: "controllersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_AspNetRoles_RoleID",
                table: "PremissionRoleControllers",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_Controllers_controllersId",
                table: "PremissionRoleControllers",
                column: "controllersId",
                principalTable: "Controllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_pages_PageId",
                table: "PremissionRoleControllers",
                column: "PageId",
                principalTable: "pages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_Premssions_permissionId",
                table: "PremissionRoleControllers",
                column: "permissionId",
                principalTable: "Premssions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_AspNetRoles_RoleID",
                table: "PremissionRoleControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_Controllers_controllersId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_pages_PageId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_Premssions_permissionId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PremissionRoleControllers",
                table: "PremissionRoleControllers");

            migrationBuilder.DropIndex(
                name: "IX_PremissionRoleControllers_controllersId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "PremissionRoleControllers");

            migrationBuilder.DropColumn(
                name: "controllersId",
                table: "PremissionRoleControllers");

            migrationBuilder.RenameColumn(
                name: "permissionId",
                table: "PremissionRoleControllers",
                newName: "controllerId");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "PremissionRoleControllers",
                newName: "Premission");

            migrationBuilder.RenameIndex(
                name: "IX_PremissionRoleControllers_permissionId",
                table: "PremissionRoleControllers",
                newName: "IX_PremissionRoleControllers_controllerId");

            migrationBuilder.RenameIndex(
                name: "IX_PremissionRoleControllers_PageId",
                table: "PremissionRoleControllers",
                newName: "IX_PremissionRoleControllers_Premission");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PremissionRoleControllers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CustomRoleId",
                table: "PremissionRoleControllers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PremissionRoleControllers",
                table: "PremissionRoleControllers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PremissionRoleControllers_CustomRoleId",
                table: "PremissionRoleControllers",
                column: "CustomRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_AspNetRoles_CustomRoleId",
                table: "PremissionRoleControllers",
                column: "CustomRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_Controllers_controllerId",
                table: "PremissionRoleControllers",
                column: "controllerId",
                principalTable: "Controllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_Premssions_Premission",
                table: "PremissionRoleControllers",
                column: "Premission",
                principalTable: "Premssions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
