using Microsoft.EntityFrameworkCore.Migrations;

namespace tawsel.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremissionRoleControllers_Controllers_controllersId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropTable(
                name: "Controllers");

            migrationBuilder.DropIndex(
                name: "IX_PremissionRoleControllers_controllersId",
                table: "PremissionRoleControllers");

            migrationBuilder.DropColumn(
                name: "controllersId",
                table: "PremissionRoleControllers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "controllersId",
                table: "PremissionRoleControllers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Controllers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PremissionRoleControllers_controllersId",
                table: "PremissionRoleControllers",
                column: "controllersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PremissionRoleControllers_Controllers_controllersId",
                table: "PremissionRoleControllers",
                column: "controllersId",
                principalTable: "Controllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
