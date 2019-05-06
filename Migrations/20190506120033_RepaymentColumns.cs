using Microsoft.EntityFrameworkCore.Migrations;

namespace FLoan.System.Web.API.Migrations
{
    public partial class RepaymentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdminFeePayable",
                table: "Agreements",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestPayable",
                table: "Agreements",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyRepayment",
                table: "Agreements",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRepayable",
                table: "Agreements",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminFeePayable",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "InterestPayable",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "MonthlyRepayment",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "TotalRepayable",
                table: "Agreements");
        }
    }
}
