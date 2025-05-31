using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.OrderManagement.Ingredients
{
    public abstract class CustomIngredient
    {
        public Guid Id { get; protected set; }
        public string? Name { get; protected set; }
        public decimal Price { get; protected set; }
        

        protected CustomIngredient() { }

        protected CustomIngredient(Guid id, string? name, decimal price)
        {
            Id = id;
            SetProperties(name, price);
        }

        protected CustomIngredient(string? name, decimal price)
        {
            SetProperties(name, price);
        }

        protected void SetProperties(string? name, decimal price)
        {
            DomainValidation.ThrowIfNullOrWhiteSpace(name, "Name is required.");

            if (price <= 0)
            {
                throw new DomainException("Price must be greater than zero.");
            }


            Name = name;
            Price = price;
        }

    }
}
