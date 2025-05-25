using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.OrderManagement;

public class OrderedProduct
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }
    public ICollection<CustomIngredient> AddedIngredients { get; private set; } = new List<CustomIngredient>();
    public ICollection<CustomIngredient> RemovedIngredients { get; private set; } = new List<CustomIngredient>();
    public string? Observation { get; private set; }
    public decimal FinalPrice { get; private set; }

    protected OrderedProduct() { }

    public OrderedProduct(Guid id, Product product, string? observation, ICollection<CustomIngredient>? addedIngredients = null, ICollection<CustomIngredient>? removedIngredients = null)
    {
        Id = id;
        SetProperties(product, observation, addedIngredients, removedIngredients);
    }

    public void AddOrderedProduct(Product? product, string? observation, ICollection<CustomIngredient>? addedIngredients = null, ICollection<CustomIngredient>? removedIngredients = null)
    {
        Id = Guid.NewGuid();
        SetProperties(product, observation, addedIngredients, removedIngredients);
    }

    private void SetProperties(Product? product, string? observation, ICollection<CustomIngredient>? addedIngredients, ICollection<CustomIngredient>? removedIngredients)
    {
        DomainValidation.ThrowIfNull(product, "Product is required.");
        DomainValidation.ThrowIf(product?.Price <= 0, "Product must have a valid price.");

        Product = product;
        ProductId = product!.Id;
        Observation = observation;
        AddedIngredients = addedIngredients ?? new List<CustomIngredient>();
        RemovedIngredients = removedIngredients ?? new List<CustomIngredient>();

        CalculateFinalPrice();
    }

    public void AddNewIngredient(CustomIngredient ingredient)
    {
        AddedIngredients.Add(ingredient);
        CalculateFinalPrice();
    }

    public void RemoveNewIngredient(CustomIngredient ingredient)
    {
        var customIngredientToRemove = AddedIngredients.FirstOrDefault(i => i.Id == ingredient.Id);

        if (customIngredientToRemove is not null)
        {
            AddedIngredients.Remove(customIngredientToRemove);
            CalculateFinalPrice();
        }
    }


    public void CalculateFinalPrice()
    {
        FinalPrice = Product?.Price ?? 0;

        if (AddedIngredients.Any())
        {
            FinalPrice += AddedIngredients.Sum(i => i.Price);
        }
    }
}