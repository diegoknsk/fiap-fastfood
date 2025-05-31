using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorOrderWithOrderedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_Dessert",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_Drink",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_Meal",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_SideDish",
                table: "OrderedProducts");

            migrationBuilder.RenameColumn(
                name: "OrderId_SideDish",
                table: "OrderedProducts",
                newName: "OrderId4");

            migrationBuilder.RenameColumn(
                name: "OrderId_Meal",
                table: "OrderedProducts",
                newName: "OrderId3");

            migrationBuilder.RenameColumn(
                name: "OrderId_Drink",
                table: "OrderedProducts",
                newName: "OrderId2");

            migrationBuilder.RenameColumn(
                name: "OrderId_Dessert",
                table: "OrderedProducts",
                newName: "OrderId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId_SideDish",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId4");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId_Meal",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId3");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId_Drink",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId2");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId_Dessert",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId1");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "OrderedProducts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_OrderId",
                table: "OrderedProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId",
                table: "OrderedProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId1",
                table: "OrderedProducts",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId1",
                table: "OrderedProducts");

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
                name: "IX_OrderedProducts_OrderId",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderedProducts");

            migrationBuilder.RenameColumn(
                name: "OrderId4",
                table: "OrderedProducts",
                newName: "OrderId_SideDish");

            migrationBuilder.RenameColumn(
                name: "OrderId3",
                table: "OrderedProducts",
                newName: "OrderId_Meal");

            migrationBuilder.RenameColumn(
                name: "OrderId2",
                table: "OrderedProducts",
                newName: "OrderId_Drink");

            migrationBuilder.RenameColumn(
                name: "OrderId1",
                table: "OrderedProducts",
                newName: "OrderId_Dessert");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId4",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId_SideDish");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId3",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId_Meal");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId2",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId_Drink");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId1",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId_Dessert");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_Dessert",
                table: "OrderedProducts",
                column: "OrderId_Dessert",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_Drink",
                table: "OrderedProducts",
                column: "OrderId_Drink",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_Meal",
                table: "OrderedProducts",
                column: "OrderId_Meal",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId_SideDish",
                table: "OrderedProducts",
                column: "OrderId_SideDish",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
