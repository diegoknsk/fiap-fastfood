using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.CustomerIdentification;
using FastFood.Domain.Entities.PaymentManagement;

namespace FastFood.Domain.Entities.OrderManagement
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string? Code { get; private set; }
        public ICollection<OrderedProduct> OrderedProducts { get; private set; } = new List<OrderedProduct>();

        public EnumPaymentStatus PaymentStatus { get; private set; }
        public EnumOrderStatus OrderStatus { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public Guid? CustomerId { get; private set; }
        public Customer? Customer { get; private set; }

        public decimal TotalPrice { get; private set; }

        protected Order()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Order(
            Guid? id,
            string? code,
            IEnumerable<OrderedProduct>? orderedProducts,
            EnumPaymentStatus paymentStatus,
            EnumOrderStatus orderStatus,
            Guid? customerId = null)
        {
            Id = id ?? Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Code = code;

            OrderedProducts = orderedProducts?.ToList() ?? new List<OrderedProduct>();
            PaymentStatus = paymentStatus;
            OrderStatus = orderStatus;
            CustomerId = customerId;

            CalculateTotalPrice();
        }

        public IEnumerable<OrderedProduct> Meals => OrderedProducts.Where(p => p.Product!.Category == EnumProductCategory.Meal);
        public IEnumerable<OrderedProduct> SideDishes => OrderedProducts.Where(p => p.Product!.Category == EnumProductCategory.SideDish);
        public IEnumerable<OrderedProduct> Drinks => OrderedProducts.Where(p => p.Product!.Category == EnumProductCategory.Drink);
        public IEnumerable<OrderedProduct> Desserts => OrderedProducts.Where(p => p.Product!.Category == EnumProductCategory.Dessert);

        public void SetCode(string code)
        {
            Code = code;
        }

        public void AddProduct(OrderedProduct product)
        {
            DomainValidation.ThrowIfNull(product, "Product is required.");
            OrderedProducts.Add(product);
            CalculateTotalPrice();
        }

        public void RemoveProduct(Guid orderedProductId)
        {
            var product = OrderedProducts.FirstOrDefault(p => p.Id == orderedProductId);
            if (product is null)
                throw new DomainException("Product not found in order.");

            OrderedProducts.Remove(product);
            CalculateTotalPrice();
        }

        public void UpdateStatus(EnumOrderStatus newStatus)
        {
            OrderStatus = newStatus;
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = OrderedProducts.Sum(p => p.FinalPrice);
        }
    }

}
