using FastFood.Domain.Entities.OrderManagement;

namespace FastFood.Application.Models.OrderManagement
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public EnumProductCategory Category { get; set; }
        public decimal Price { get; set; }
        public List<CustomIngredientModel> Ingredients { get; set; } = new();
        public ImageProductModel? Image { get; set; }
    }
}
