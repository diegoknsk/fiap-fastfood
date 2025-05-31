namespace FastFood.Application.Models.OrderManagement
{
    namespace FastFood.Application.Models.OrderManagement
    {
        public class AddProductToOrderModel
        {
            public Guid OrderId { get; set; }
            public Guid ProductId { get; set; }
            public string? Observation { get; set; }
            public int Quantity { get; set; }

            public List<CustomIngredientQuantityModel>? CustomIngredients { get; set; }
        }

        public class CustomIngredientQuantityModel
        {
            public Guid IngredientId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
