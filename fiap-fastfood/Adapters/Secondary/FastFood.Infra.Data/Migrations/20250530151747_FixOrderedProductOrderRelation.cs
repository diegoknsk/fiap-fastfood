using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderedProductOrderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId2",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId3",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId4",
                table: "OrderedProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderedProducts_OrderId2",
                table: "OrderedProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderedProducts_OrderId3",
                table: "OrderedProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderedProducts_OrderId4",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "OrderId2",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "OrderId3",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "OrderId4",
                table: "OrderedProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId2",
                table: "OrderedProducts",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId3",
                table: "OrderedProducts",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId4",
                table: "OrderedProducts",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_OrderId2",
                table: "OrderedProducts",
                column: "OrderId2");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_OrderId3",
                table: "OrderedProducts",
                column: "OrderId3");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_OrderId4",
                table: "OrderedProducts",
                column: "OrderId4");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId2",
                table: "OrderedProducts",
                column: "OrderId2",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId3",
                table: "OrderedProducts",
                column: "OrderId3",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId4",
                table: "OrderedProducts",
                column: "OrderId4",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
