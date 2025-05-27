namespace FastFood.Domain.Entities.OrderManagement.Ingredients
{
    public class RemovedIngredient : CustomIngredient
    {
        public Guid OrderedProductId { get; private set; }

        protected RemovedIngredient() { }

        public RemovedIngredient(Guid id, string? name, decimal price, Guid orderedProductId)
            : base(id, name, price)
        {
            OrderedProductId = orderedProductId;
        }
    }
}
