using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.PaymentManagement;

namespace FastFood.Application.Models.OrderManagement
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public decimal TotalPrice { get; set; }
        public EnumOrderStatus OrderStatus { get; set; }
        public EnumPaymentStatus PaymentStatus { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderedProductModel> OrderedProducts { get; set; } = new();
    }

    public class OrderedProductModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; }
        public string? Observation { get; set; }
        public ProductImageModel? Image { get; set; }
        public List<CustomIngredientModel> CustomIngredients { get; set; } = new();
    }
    public class ProductImageModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
    }
    public class CustomIngredientModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid? ProductBaseIngredientId { get; set; }
    }
}
