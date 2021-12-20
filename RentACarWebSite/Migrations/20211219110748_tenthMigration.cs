using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACarWebSite.Migrations
{
    public partial class tenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentModel",
                table: "PaymentModel");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PaymentModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentModel",
                table: "PaymentModel",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentModel",
                table: "PaymentModel");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PaymentModel");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentModel",
                table: "PaymentModel",
                column: "Name");
        }
    }
}
