namespace FastFood.Application.Services.OrderManagement
{
    public class RemoveAddedIngredientModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderedProductId { get; set; }
        public Guid IngredientId { get; set; }
    }
}
