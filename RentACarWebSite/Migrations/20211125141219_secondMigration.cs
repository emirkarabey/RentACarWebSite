using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACarWebSite.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Admin_AdminID",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Cars_CarID",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Members_MemberID",
                table: "Buy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buy",
                table: "Buy");

            migrationBuilder.RenameTable(
                name: "Buy",
                newName: "Rent");

            migrationBuilder.RenameIndex(
                name: "IX_Buy_MemberID",
                table: "Rent",
                newName: "IX_Rent_MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Buy_CarID",
                table: "Rent",
                newName: "IX_Rent_CarID");

            migrationBuilder.RenameIndex(
                name: "IX_Buy_AdminID",
                table: "Rent",
                newName: "IX_Rent_AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rent",
                table: "Rent",
                column: "RentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Admin_AdminID",
                table: "Rent",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Cars_CarID",
                table: "Rent",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Members_MemberID",
                table: "Rent",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Admin_AdminID",
                table: "Rent");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Cars_CarID",
                table: "Rent");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Members_MemberID",
                table: "Rent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rent",
                table: "Rent");

            migrationBuilder.RenameTable(
                name: "Rent",
                newName: "Buy");

            migrationBuilder.RenameIndex(
                name: "IX_Rent_MemberID",
                table: "Buy",
                newName: "IX_Buy_MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Rent_CarID",
                table: "Buy",
                newName: "IX_Buy_CarID");

            migrationBuilder.RenameIndex(
                name: "IX_Rent_AdminID",
                table: "Buy",
                newName: "IX_Buy_AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buy",
                table: "Buy",
                column: "RentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Admin_AdminID",
                table: "Buy",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Cars_CarID",
                table: "Buy",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Members_MemberID",
                table: "Buy",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
