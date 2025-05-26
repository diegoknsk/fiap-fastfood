using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.PaymentManagement;

namespace FastFood.Domain.Entities.OrderManagement
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string? Code { get; private set; } //todo ver logica de código, talvzs um numero incrental concatenado com zeros a esquerda
        public ICollection<OrderedProduct> OrderedMealProducts { get; private set; } = new List<OrderedProduct>();
        public ICollection<OrderedProduct> OrderedSideDish { get; private set; } = new List<OrderedProduct>();
        public ICollection<OrderedProduct> OrderedDrink { get; private set; } = new List<OrderedProduct>();
        public ICollection<OrderedProduct> OrderedDessert { get; private set; } = new List<OrderedProduct>();

        public EnumPaymentStatus PaymentStatus { get; private set; }
        public EnumOrderStatus OrderStatus { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public Guid? CustomerId { get; private set; }
        public decimal TotalPrice { get; private set; }

        protected Order()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Order(
            Guid? id,
            string? code,
            ICollection<OrderedProduct>? orderedMealProducts,
            ICollection<OrderedProduct>? orderedSideDishes,
            ICollection<OrderedProduct>? orderedDrinks,
            ICollection<OrderedProduct>? orderedDesserts,
            EnumPaymentStatus paymentStatus,
            EnumOrderStatus orderStatus,
            Guid? customerId = null)
        {
            Id = id ?? Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Code = code;

            SetProperties(orderedMealProducts, orderedSideDishes, orderedDrinks, orderedDesserts, paymentStatus, orderStatus, customerId);
        }

        public void AddOrder(
            ICollection<OrderedProduct>? orderedMealProducts,
            ICollection<OrderedProduct>? orderedSideDishes,
            ICollection<OrderedProduct>? orderedDrinks,
            ICollection<OrderedProduct>? orderedDesserts,
            EnumPaymentStatus paymentStatus,
            EnumOrderStatus orderStatus,
            Guid? customerId = null)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Code = string.Empty;

            SetProperties(orderedMealProducts, orderedSideDishes, orderedDrinks, orderedDesserts, paymentStatus, orderStatus, customerId);
        }

        private void SetProperties(
            ICollection<OrderedProduct>? orderedMealProducts,
            ICollection<OrderedProduct>? orderedSideDishes,
            ICollection<OrderedProduct>? orderedDrinks,
            ICollection<OrderedProduct>? orderedDesserts,
            EnumPaymentStatus paymentStatus,
            EnumOrderStatus orderStatus,
            Guid? customerId)
        {
            OrderedMealProducts = orderedMealProducts ?? new List<OrderedProduct>();
            OrderedSideDish = orderedSideDishes ?? new List<OrderedProduct>();
            OrderedDrink = orderedDrinks ?? new List<OrderedProduct>();
            OrderedDessert = orderedDesserts ?? new List<OrderedProduct>();

            PaymentStatus = paymentStatus;
            OrderStatus = orderStatus;
            CustomerId = customerId;

            CalculateTotalPrice();
        }

        public void SetCode(string code)
        {
            Code = code;
        }

        public void CalculateTotalPrice()
        {
            TotalPrice =
                (OrderedMealProducts?.Sum(p => p.FinalPrice) ?? 0) +
                (OrderedSideDish?.Sum(p => p.FinalPrice) ?? 0) +
                (OrderedDrink?.Sum(p => p.FinalPrice) ?? 0) +
                (OrderedDessert?.Sum(p => p.FinalPrice) ?? 0);
        }

        public void AddProduct(OrderedProduct product)
        {
            DomainValidation.ThrowIfNull(product, "Product is required.");

            switch (product.Product!.Category)
            {
                case EnumProductCategory.Meal:
                    OrderedMealProducts.Add(product);
                    break;

                case EnumProductCategory.SideDish:
                    OrderedSideDish.Add(product);
                    break;

                case EnumProductCategory.Drink:
                    OrderedDrink.Add(product);
                    break;

                case EnumProductCategory.Dessert:
                    OrderedDessert.Add(product);
                    break;

                default:
                    throw new DomainException("Unsupported product category.");
            }

            CalculateTotalPrice();
        }

        public void UpdateStatus(EnumOrderStatus newStatus)
        {
            OrderStatus = newStatus;
        }

        public void RemoveProduct(Guid orderedProductId)
        {
            var removed =
                TryRemoveProductFrom(OrderedMealProducts, orderedProductId) ||
                TryRemoveProductFrom(OrderedSideDish, orderedProductId) ||
                TryRemoveProductFrom(OrderedDrink, orderedProductId) ||
                TryRemoveProductFrom(OrderedDessert, orderedProductId);

            if (!removed)
            {
                throw new DomainException("Product not found in order.");
            }

            CalculateTotalPrice();
        }

        private bool TryRemoveProductFrom(ICollection<OrderedProduct> list, Guid productId)
        {
            var item = list.FirstOrDefault(p => p.Id == productId);
            if (item != null)
            {
                return list.Remove(item);
            }

            return false;
        }
    }

}
