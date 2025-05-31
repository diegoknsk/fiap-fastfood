using FastFood.Application.Models.OrderManagement.FastFood.Application.Models.OrderManagement;

namespace FastFood.Application.Models.OrderManagement
{
    public class UpdateProductInOrderModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderedProductId { get; set; }
        public string? Observation { get; set; }
        public int Quantity { get; set; }

        public List<CustomIngredientQuantityModel>? CustomIngredients { get; set; }
    }
}
