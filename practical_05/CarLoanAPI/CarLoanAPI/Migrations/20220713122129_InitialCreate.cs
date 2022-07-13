using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLoanAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NRIC = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    LoanAmt = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.LoanApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "LoanRates",
                columns: table => new
                {
                    Term = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRates", x => x.Term);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "LoanRates");
        }
    }
}
