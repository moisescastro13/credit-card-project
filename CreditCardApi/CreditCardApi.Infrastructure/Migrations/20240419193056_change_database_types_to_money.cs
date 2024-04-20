using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_database_types_to_money : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OldBalance",
                table: "CreditCardTransactions",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "NewBalance",
                table: "CreditCardTransactions",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CreditCardTransactions",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "balance",
                table: "CreditCardDetails",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumFee",
                table: "CreditCardDetails",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Currentbalance",
                table: "CreditCardDetails",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentInterest",
                table: "CreditCardDetails",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "OldBalance",
                table: "CreditCardTransactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "NewBalance",
                table: "CreditCardTransactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "CreditCardTransactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "balance",
                table: "CreditCardDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "MinimumFee",
                table: "CreditCardDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "Currentbalance",
                table: "CreditCardDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "CurrentInterest",
                table: "CreditCardDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
