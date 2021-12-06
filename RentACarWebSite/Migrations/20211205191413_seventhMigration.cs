using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACarWebSite.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarMarka",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "MarkaId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.MarkaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MarkaId",
                table: "Cars",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Marka_MarkaId",
                table: "Cars",
                column: "MarkaId",
                principalTable: "Marka",
                principalColumn: "MarkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Marka_MarkaId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MarkaId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MarkaId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarMarka",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
