using FastFood.Application.Mappers.OrderManagement.Ingredients;
using FastFood.Application.Models.OrderManagement;
using FastFood.Application.Models.OrderManagement.Ingredients;
using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.Ingredients;

namespace FastFood.Application.Mappers.OrderManagement
{
    public static class ProductMapper
    {
        public static ProductModel ToModel(this Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name ?? string.Empty,
                Category = product.Category,
                Price = product.Price,
                Ingredients = product.Ingredients?.Select(i => new ProductBaseIngredientModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price
                }).ToList() ?? new List<ProductBaseIngredientModel>(),
                Image = product.Image is not null ? new ImageProductModel
                {
                    Name = product.Image.Name,
                    Url = product.Image.Url
                } : null
            };
        }
        public static Product ToEntity(this ProductModel model)
        {
            var product = new Product(
                model.Id == Guid.Empty ? null : model.Id,
                model.Name,
                model.Category,
                model.Price,
                new List<ProductBaseIngredient>(),
                model.Image?.ToEntity()

            );

            foreach (var ingredientModel in model.Ingredients)
            {
                var ingredient = ingredientModel.ToEntity(product.Id);
                product.Ingredients.Add(ingredient);
            }

            return product;
        }
    }
}

