using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.ValueObjects;
using FastFood.Domain.Ports.OrderManagement;

namespace FastFood.Infra.Data
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> ListAll()
        {
            return new List<Product>
            {
                new Product(null, "X-Burger", EnumProductCategory.Meal, 18.50m,
                    new List<CustomIngredient> {
                        new CustomIngredient(null, "Pão", 200),
                        new CustomIngredient(null, "Carne", 0),
                        new CustomIngredient(null, "Queijo", 0)
                    }, new ImageProduct("xburger.jpg", "https://cdn.exemplo.com/xburger.jpg")),

                new Product(null, "X-Bacon", EnumProductCategory.Meal, 21.00m,
                    new List<CustomIngredient> {
                        new CustomIngredient(null, "Pão", 0),
                        new CustomIngredient(null, "Bacon", 0),
                        new CustomIngredient(null, "Queijo", 0)
                    }, new ImageProduct("xbacon.jpg", "https://cdn.exemplo.com/xbacon.jpg")),

                new Product(null, "Fritas Média", EnumProductCategory.SideDish, 9.90m,
                    new List<CustomIngredient> {
                        new CustomIngredient(null, "Batata", 0)
                    }, null),

                new Product(null, "Coca-Cola Lata", EnumProductCategory.Drink, 6.00m,
                    new List<CustomIngredient> {
                        new CustomIngredient(null, "Refrigerante", 0)
                    }, null),

                new Product(null, "Sorvete", EnumProductCategory.Dessert, 7.50m,
                    new List<CustomIngredient> {
                        new CustomIngredient(null, "Leite", 0),
                        new CustomIngredient(null, "Açúcar", 0)
                    }, new ImageProduct("sorvete.jpg", "https://cdn.exemplo.com/sorvete.jpg")),
            };
        }
    }
}
