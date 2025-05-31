using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalFix_OrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove FK se ela existir
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId1",
                table: "OrderedProducts");

            // Remove índice (caso tenha sido criado automaticamente pelo EF)
            migrationBuilder.DropIndex(
                name: "IX_OrderedProducts_OrderId1",
                table: "OrderedProducts");

            // Remove a coluna
            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderedProducts");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
