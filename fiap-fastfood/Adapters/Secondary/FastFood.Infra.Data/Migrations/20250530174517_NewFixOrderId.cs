using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFixOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId1",
                table: "OrderedProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderedProducts_OrderId1",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderedProducts");
            */

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId1",
                table: "OrderedProducts",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_OrderId1",
                table: "OrderedProducts",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId1",
                table: "OrderedProducts",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
