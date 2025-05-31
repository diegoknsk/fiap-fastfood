using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.OrderManagement.Ingredients
{
    public class OrderedProductIngredient : CustomIngredient
    {
        public Guid? OrderedProductId { get; private set; }
        public OrderedProduct? OrderedProduct { get; private set; }
        public Guid? ProductBaseIngredientId { get; private set; }


        public int Quantity { get; private set; }

        protected OrderedProductIngredient() { }

        public OrderedProductIngredient(Guid id, string? name, decimal price, Guid orderedProductId, int quantity, Guid? productBaseIngredientId = null)
            : base(id, name, price)
        {
            OrderedProductId = orderedProductId;
            SetAttributes(quantity, productBaseIngredientId);
        }
        public OrderedProductIngredient(Guid id, string? name, decimal price, int quantity, Guid? productBaseIngredientId = null)
            : base(id, name, price)
        {
            SetAttributes(quantity, productBaseIngredientId);
        }


        public OrderedProductIngredient(string? name, decimal price, int quantity, Guid? productBaseIngredientId = null)
            : base(name, price)
        {
            SetAttributes(quantity, productBaseIngredientId);
        }
        
        private void SetAttributes(int quantity, Guid? productBaseIngredientId)
        {
            ProductBaseIngredientId = productBaseIngredientId;
            SetQuantity(quantity);
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0 || quantity > 10)
                throw new DomainException("A quantidade deve estar entre 0 e 10.");

            Quantity = quantity;
        }
        public void SetOrderedProductId(Guid orderedProductId)
        {
            OrderedProductId = orderedProductId;
        }
    }

}
