using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityAndBaseIngredientReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductBaseIngredientId",
                table: "OrderedProductIngredients",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "ProductBaseIngredientId",
                table: "OrderedProductIngredients");
        }
    }
}
