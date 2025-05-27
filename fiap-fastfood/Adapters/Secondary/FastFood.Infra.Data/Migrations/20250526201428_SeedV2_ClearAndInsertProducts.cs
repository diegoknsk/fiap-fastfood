using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedV2_ClearAndInsertProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deletar dados antigos
            migrationBuilder.Sql("DELETE FROM ProductBaseIngredients;");
            migrationBuilder.Sql("DELETE FROM Products;");

            // Produtos e ingredientes base
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('de904cba-a00b-48f1-a362-6cf9d196ec5f', 'Hambúrguer Artesanal', 0, 24.0, 'Hambúrguer Artesanal', 'https://images.pexels.com/photos/1639562/pexels-photo-1639562.jpeg');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('e2d3724b-9cca-49e0-82e5-96109f3442db', 'Pão de Brioche', 2.0, 'de904cba-a00b-48f1-a362-6cf9d196ec5f');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('a23ab374-d82d-4025-a116-25ef6cd25c63', 'Carne 180g', 6.0, 'de904cba-a00b-48f1-a362-6cf9d196ec5f');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('1a4409e0-3307-4419-92d5-485e3e302493', 'Queijo Cheddar', 3.0, 'de904cba-a00b-48f1-a362-6cf9d196ec5f');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('fbafa1c2-62b3-40c4-9084-2509af6a263a', 'Alface', 1.0, 'de904cba-a00b-48f1-a362-6cf9d196ec5f');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('924aefd6-0d50-4018-8299-52d23760467f', 'Tomate', 1.0, 'de904cba-a00b-48f1-a362-6cf9d196ec5f');");

            // Pizza Margherita
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('758621ad-3807-4a84-af7d-ce8c64245c48', 'Pizza Margherita', 0, 30.0, 'Pizza Margherita', 'https://images.pexels.com/photos/10068752/pexels-photo-10068752.jpeg');");

            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('e05445ae-0ea3-4bb3-a0c7-bf6ee7b40538', 'Massa', 4.0, '758621ad-3807-4a84-af7d-ce8c64245c48');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('276bfc29-7c0a-4ed1-8e08-df579f4427cc', 'Molho', 2.0, '758621ad-3807-4a84-af7d-ce8c64245c48');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('25826a5e-8be5-47ff-8548-95a2d1cba3de', 'Mussarela', 5.0, '758621ad-3807-4a84-af7d-ce8c64245c48');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('6222dc26-45ff-47de-b3e7-9a99e933c3e1', 'Manjericão', 1.0, '758621ad-3807-4a84-af7d-ce8c64245c48');");
           
            // Sanduíche Natural
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('ac4a5888-354d-466b-801f-0dfb00a89452', 'Sanduíche Natural', 0, 15.0, 'Sanduíche Natural', 'https://images.pexels.com/photos/5292918/pexels-photo-5292918.jpeg');");

            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('0c1204a1-8966-4c0d-bb5b-7a7a5418b7e6', 'Pão Integral', 2.0, 'ac4a5888-354d-466b-801f-0dfb00a89452');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('91b718b8-1973-463c-b3c0-13e409a8cd80', 'Peito de Peru', 3.0, 'ac4a5888-354d-466b-801f-0dfb00a89452');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('df7bb8aa-8b4f-4e91-85e3-45a7b39e7bb3', 'Alface', 1.0, 'ac4a5888-354d-466b-801f-0dfb00a89452');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('fa0e5a25-d33e-498a-b33e-7a10c1b2b871', 'Tomate', 1.0, 'ac4a5888-354d-466b-801f-0dfb00a89452');");
            migrationBuilder.Sql("INSERT INTO ProductBaseIngredients (Id, Name, Price, ProductId) VALUES ('456e9a3a-e70b-4682-8892-c3340b69fc46', 'Queijo Branco', 2.0, 'ac4a5888-354d-466b-801f-0dfb00a89452');");

            // coca
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('9a8a232b-d238-429a-9d89-820373ad5f50', 'Refrigerante Cola 350ml', 1, 6.0, 'Refrigerante', 'https://images.pexels.com/photos/2983100/pexels-photo-2983100.jpeg');");

            // cerveja
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('d5deea7b-85f0-4068-ac52-8681715daa2e', 'Cerveja Artesanal 600ml', 1, 14.0, 'Cerveja', 'https://images.pexels.com/photos/1267700/pexels-photo-1267700.jpeg');");

            //batata frita
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('3667e0c8-151a-4dc2-9dd7-a42dde596f34', 'Batata Frita', 2, 12.0, 'Batata Frita', 'https://images.pexels.com/photos/1586942/pexels-photo-1586942.jpeg');");

            //cebola
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('4c872fd2-f284-4949-9c3b-1c658c66c222', 'Anéis de Cebola', 2, 10.0, 'Anéis de Cebola', 'https://images.pexels.com/photos/6941050/pexels-photo-6941050.jpeg');");

            //sorvete
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('9373cccd-c573-422f-baf0-6986e5ea4f5b', 'Sorvete de Baunilha', 3, 8.0, 'Sorvete', 'https://images.pexels.com/photos/1294943/pexels-photo-1294943.jpeg');");

            //brownie chocolate
            migrationBuilder.Sql("INSERT INTO Products (Id, Name, Category, Price, ImageName, ImageUrl) VALUES ('60d17e4d-2496-410a-8598-a7d11579dceb', 'Brownie de Chocolate', 3, 9.0, 'Brownie', 'https://images.pexels.com/photos/2067396/pexels-photo-2067396.jpeg');");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
