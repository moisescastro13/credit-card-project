using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_minimumfee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumFee",
                table: "CreditCardDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MinimumFee",
                table: "CreditCardDetails",
                type: "Money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
