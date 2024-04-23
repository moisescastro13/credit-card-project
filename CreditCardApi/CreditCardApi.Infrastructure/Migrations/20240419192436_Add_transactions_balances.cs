using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_transactions_balances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NewBalance",
                table: "CreditCardTransactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldBalance",
                table: "CreditCardTransactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinimumFee",
                table: "CreditCardDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinimumFeePercent",
                table: "CreditCardDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewBalance",
                table: "CreditCardTransactions");

            migrationBuilder.DropColumn(
                name: "OldBalance",
                table: "CreditCardTransactions");

            migrationBuilder.DropColumn(
                name: "MinimumFee",
                table: "CreditCardDetails");

            migrationBuilder.DropColumn(
                name: "MinimumFeePercent",
                table: "CreditCardDetails");
        }
    }
}
