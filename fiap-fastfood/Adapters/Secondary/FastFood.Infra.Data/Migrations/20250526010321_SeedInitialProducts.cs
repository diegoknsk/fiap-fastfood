using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Produtos
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Category", "Price" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Hambúrguer Clássico", 0, 19.90m },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Cheeseburger", 0, 21.90m },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Batata Média", 1, 8.50m },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Coca-Cola Lata", 2, 6.00m },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Brownie com Sorvete", 3, 12.00m }
                }
            );

            // Ingredientes
            migrationBuilder.InsertData(
                table: "CustomIngredients",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("aaaaaaa1-0000-0000-0000-000000000001"), "Pão", 0m },
                    { new Guid("aaaaaaa2-0000-0000-0000-000000000002"), "Carne", 0m },
                    { new Guid("aaaaaaa3-0000-0000-0000-000000000003"), "Alface", 0m },
                    { new Guid("aaaaaaa4-0000-0000-0000-000000000004"), "Queijo", 0m },
                    { new Guid("aaaaaaa5-0000-0000-0000-000000000005"), "Batata", 0m },
                    { new Guid("aaaaaaa6-0000-0000-0000-000000000006"), "Refrigerante", 0m },
                    { new Guid("aaaaaaa7-0000-0000-0000-000000000007"), "Brownie", 0m },
                    { new Guid("aaaaaaa8-0000-0000-0000-000000000008"), "Sorvete de Baunilha", 0m }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
