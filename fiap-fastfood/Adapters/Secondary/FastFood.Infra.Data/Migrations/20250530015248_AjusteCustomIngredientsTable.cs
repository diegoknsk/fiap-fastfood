using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCustomIngredientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddedIngredients");

            migrationBuilder.DropTable(
                name: "RemovedIngredients");

            migrationBuilder.CreateTable(
                name: "OrderedProductIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderedProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProductIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedProductIngredients_OrderedProducts_OrderedProductId",
                        column: x => x.OrderedProductId,
                        principalTable: "OrderedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductIngredients_OrderedProductId",
                table: "OrderedProductIngredients",
                column: "OrderedProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedProductIngredients");

            migrationBuilder.CreateTable(
                name: "AddedIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderedProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddedIngredients_OrderedProducts_OrderedProductId",
                        column: x => x.OrderedProductId,
                        principalTable: "OrderedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemovedIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderedProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemovedIngredients_OrderedProducts_OrderedProductId",
                        column: x => x.OrderedProductId,
                        principalTable: "OrderedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddedIngredients_OrderedProductId",
                table: "AddedIngredients",
                column: "OrderedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedIngredients_OrderedProductId",
                table: "RemovedIngredients",
                column: "OrderedProductId");
        }
    }
}