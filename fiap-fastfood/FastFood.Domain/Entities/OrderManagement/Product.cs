using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.OrderManagement.ValueObjects;

namespace FastFood.Domain.Entities.OrderManagement
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public EnumProductCategory Category { get; private set; }
        public ICollection<CustomIngredient>? Ingredients { get; private set; }
        public decimal Price { get; private set; }
        public ImageProduct? Image { get;private set;}

        public Product(Guid? id, string name, EnumProductCategory category, decimal price, ICollection<CustomIngredient>? ingredients = null, ImageProduct? image = null)
        {
            Id = id ?? Guid.NewGuid();
            SetProperties(name, category, price, ingredients, image);
        }

        public void AddProduct(string name, EnumProductCategory category, decimal price,
            ICollection<CustomIngredient>? ingredients = null, ImageProduct? image = null)
        {
            Id = Guid.NewGuid();
            SetProperties(name, category, price, ingredients, image);
        }

        private void SetProperties(string? name, EnumProductCategory category, decimal price, ICollection<CustomIngredient>? ingredients, ImageProduct? image)
        {
            ValidateFields(name, price);

            Name = name;
            Category = category;
            Price = price;
            Ingredients = ingredients ?? new List<CustomIngredient>();
            Image = image;
        }
        private void ValidateFields(string? name, decimal price)
        {
            DomainValidation.ThrowIfNullOrWhiteSpace(name, "Product name is required.");
            DomainValidation.ThrowIf(price <= 0, "Price must be greater than zero.");
        }
    }
}
