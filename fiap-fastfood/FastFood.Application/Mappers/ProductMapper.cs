using FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Entities.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Mappers
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
                Ingredients = product.Ingredients?.Select(i => new CustomIngredientModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price
                }).ToList() ?? new List<CustomIngredientModel>(),
                Image = product.Image is not null ? new ImageProductModel
                {
                    Name = product.Image.Name,
                    Url = product.Image.Url
                } : null
            };
        }
    }
}
