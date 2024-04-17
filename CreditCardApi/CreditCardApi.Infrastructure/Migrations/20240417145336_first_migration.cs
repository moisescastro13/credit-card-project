using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreditCardNumber = table.Column<long>(type: "bigint", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CutOffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreditCarID = table.Column<long>(type: "bigint", nullable: false),
                    CreditCardType = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    Interest = table.Column<double>(type: "float", nullable: false),
                    Currentbalance = table.Column<double>(type: "float", nullable: false),
                    CurrentInterest = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardDetails_CreditCards_CreditCarID",
                        column: x => x.CreditCarID,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreditCardID = table.Column<long>(type: "bigint", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardTransactions_CreditCards_CreditCardID",
                        column: x => x.CreditCardID,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardDetails_CreditCarID",
                table: "CreditCardDetails",
                column: "CreditCarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardTransactions_CreditCardID",
                table: "CreditCardTransactions",
                column: "CreditCardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardDetails");

            migrationBuilder.DropTable(
                name: "CreditCardTransactions");

            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}
