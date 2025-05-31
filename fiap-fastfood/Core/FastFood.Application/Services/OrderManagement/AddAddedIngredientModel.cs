namespace FastFood.Application.Services.OrderManagement
{
    public class AddAddedIngredientModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderedProductId { get; set; }
        public Guid IngredientId { get; set; }
    }
}
