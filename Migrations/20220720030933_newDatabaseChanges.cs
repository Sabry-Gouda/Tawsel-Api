using Microsoft.EntityFrameworkCore.Migrations;

namespace tawsel.Migrations
{
    public partial class newDatabaseChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Orders",
                newName: "totalWeight");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Orders",
                newName: "totalCost");

            migrationBuilder.AlterColumn<string>(
                name: "serialNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "branchId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isShippableToVillage",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "traderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_branchId",
                table: "Orders",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_traderId",
                table: "Orders",
                column: "traderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Branches_branchId",
                table: "Orders",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Traders_traderId",
                table: "Orders",
                column: "traderId",
                principalTable: "Traders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Branches_branchId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Traders_traderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Traders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_branchId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_traderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "branchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "isShippableToVillage",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "street",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "traderId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "totalWeight",
                table: "Orders",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "totalCost",
                table: "Orders",
                newName: "Cost");

            migrationBuilder.AlterColumn<string>(
                name: "serialNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
