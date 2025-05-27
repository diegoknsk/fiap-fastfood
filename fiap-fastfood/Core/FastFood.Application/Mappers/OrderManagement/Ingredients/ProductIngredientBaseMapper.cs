using FastFood.Application.Models.OrderManagement.Ingredients;
using FastFood.Domain.Entities.OrderManagement.Ingredients;

namespace FastFood.Application.Mappers.OrderManagement.Ingredients
{
    public static class ProductBaseIngredientMapper
    {
        public static ProductBaseIngredient ToEntity(this ProductBaseIngredientModel model, Guid productId)
        {
            return new ProductBaseIngredient(model.Id, model.Name, model.Price, productId);
        }

        public static ProductBaseIngredientModel ToModel(this ProductBaseIngredient entity)
        {
            return new ProductBaseIngredientModel
            {
                Id = entity.Id,
                Name = entity.Name ?? string.Empty,
                Price = entity.Price
            };
        }
    }
}
