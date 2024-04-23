using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changes_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardTransactions_CreditCards_CreditCardID",
                table: "CreditCardTransactions");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardTransactions_CreditCards_CreditCardID",
                table: "CreditCardTransactions",
                column: "CreditCardID",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardTransactions_CreditCards_CreditCardID",
                table: "CreditCardTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardTransactions_CreditCards_CreditCardId",
                table: "CreditCardTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CreditCardTransactions_CreditCardID",
                table: "CreditCardTransactions");

            migrationBuilder.DropColumn(
                name: "CreditCardID",
                table: "CreditCardTransactions");

            migrationBuilder.RenameColumn(
                name: "CreditCardId",
                table: "CreditCardTransactions",
                newName: "CreditCardID");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCardTransactions_CreditCardId",
                table: "CreditCardTransactions",
                newName: "IX_CreditCardTransactions_CreditCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardTransactions_CreditCards_CreditCardID",
                table: "CreditCardTransactions",
                column: "CreditCardID",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
