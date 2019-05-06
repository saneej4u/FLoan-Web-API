using Microsoft.EntityFrameworkCore.Migrations;

namespace FLoan.System.Web.API.Migrations
{
    public partial class LeftToPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LeftToPay",
                table: "Agreements",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftToPay",
                table: "Agreements");
        }
    }
}
