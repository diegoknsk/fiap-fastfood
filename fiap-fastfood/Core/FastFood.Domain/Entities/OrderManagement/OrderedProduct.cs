using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.OrderManagement.Ingredients;

namespace FastFood.Domain.Entities.OrderManagement;

public class OrderedProduct
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }
    public ICollection<AddedIngredient> AddedIngredients { get; private set; } = new List<AddedIngredient>();
    public ICollection<RemovedIngredient> RemovedIngredients { get; private set; } = new List<RemovedIngredient>();
    public string? Observation { get; private set; }
    public decimal FinalPrice { get; private set; }

    protected OrderedProduct() { }

    public OrderedProduct(Guid id, Product product, string? observation, ICollection<AddedIngredient>? addedIngredients = null, ICollection<RemovedIngredient>? removedIngredients = null)
    {
        Id = id;
        SetProperties(product, observation, addedIngredients, removedIngredients);
    }

    public void AddOrderedProduct(Product? product, string? observation, ICollection<AddedIngredient>? addedIngredients = null, ICollection<RemovedIngredient>? removedIngredients = null)
    {
        Id = Guid.NewGuid();
        SetProperties(product, observation, addedIngredients, removedIngredients);
    }

    private void SetProperties(Product? product, string? observation, ICollection<AddedIngredient>? addedIngredients, ICollection<RemovedIngredient>? removedIngredients)
    {
        DomainValidation.ThrowIfNull(product, "Product is required.");
        DomainValidation.ThrowIf(product?.Price <= 0, "Product must have a valid price.");

        Product = product;
        ProductId = product!.Id;
        Observation = observation;
        AddedIngredients = addedIngredients ?? new List<AddedIngredient>();
        RemovedIngredients = removedIngredients ?? new List<RemovedIngredient>();

        CalculateFinalPrice();
    }

    public void AddNewIngredient(AddedIngredient ingredient)
    {
        AddedIngredients.Add(ingredient);
        CalculateFinalPrice();
    }

    public void RemoveNewIngredient(RemovedIngredient ingredient)
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