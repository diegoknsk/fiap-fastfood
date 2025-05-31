namespace FastFood.Application.Models.OrderManagement.Ingredients
{
    public class ProductBaseIngredientModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
