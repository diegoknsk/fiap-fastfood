using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.OrderManagement.Ingredients;

namespace FastFood.Domain.Entities.OrderManagement
{
    public class OrderedProduct
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public Product? Product { get; private set; }
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; } = null;
        public ICollection<OrderedProductIngredient> CustomIngredients { get; private set; } = new List<OrderedProductIngredient>();

        public string? Observation { get; private set; }
        public decimal FinalPrice { get; private set; }
        public int Quantity { get; private set; }

        protected OrderedProduct() { }

        // Constructor with default quantity = 1
        public OrderedProduct(Guid id, Product product, string? observation,
            ICollection<OrderedProductIngredient>? customIngredients = null)
            : this(id, product, observation, 1, customIngredients)
        {
        }

        // Main constructor with quantity
        public OrderedProduct(Guid id, Product product, string? observation, int quantity,
            ICollection<OrderedProductIngredient>? customIngredients = null)
        {
            SetProperties(product, observation, quantity, customIngredients);
            Id = id;
        }

        private void SetProperties(Product product, string? observation, int quantity,
            ICollection<OrderedProductIngredient>? customIngredients)
        {
            DomainValidation.ThrowIfNull(product, "Produto é obrigatório.");
            DomainValidation.ThrowIf(product.Price <= 0, "O produto deve possuir um preço válido.");
            DomainValidation.ThrowIf(quantity < 1, "A quantidade mínima deve ser 1.");

            Product = product;
            ProductId = product.Id;
            Observation = observation;
            Quantity = quantity;

            if (customIngredients is not null)
            {
                CustomIngredients = customIngredients.ToList();
            }
            else
            {
                InitializeDefaultIngredients();
            }

            CalculateFinalPrice();
        }

        private void InitializeDefaultIngredients()
        {
            if (Product?.Ingredients is null) return;

            CustomIngredients = Product.Ingredients.Select(i =>
                new OrderedProductIngredient(Guid.NewGuid(), i.Name, i.Price, 1, i.Id)).ToList();
        }

        public void SetIngredientQuantity(Guid productBaseIngredientId, int quantity)
        {
            var ingredient = CustomIngredients.FirstOrDefault(i => i.ProductBaseIngredientId == productBaseIngredientId);

            if (ingredient is null)
                throw new DomainException("Ingrediente não encontrado.");

            ingredient.SetQuantity(quantity);
            CalculateFinalPrice();
        }

        public void SetObservation(string? observation)
        {
            Observation = observation;
        }

        public void SetQuantity(int quantity)
        {
            DomainValidation.ThrowIf(quantity < 1, "A quantidade mínima deve ser 1.");
            Quantity = quantity;
            CalculateFinalPrice();
        }

        public void CalculateFinalPrice()
        {
            var basePrice = Product?.Price ?? 0;

            foreach (var ingredient in CustomIngredients)
            {
                if (ingredient.Quantity > 1)
                {
                    basePrice += ingredient.Price * (ingredient.Quantity - 1);
                }
                else if (ingredient.Quantity == 0)
                {
                    basePrice -= ingredient.Price;
                }
            }

            FinalPrice = basePrice * Quantity;
        }
    }
}