using FastFood.Application.Models.OrderManagement.Ingredients;
using FastFood.Domain.Entities.OrderManagement.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Mappers.OrderManagement.Ingredients
{
    public static class AddedIngredientMapper
    {
        public static AddedIngredient ToEntity(this AddedIngredientModel model, Guid orderedProductId)
        {
            return new AddedIngredient(model.Id, model.Name, model.Price, orderedProductId);
        }

        public static AddedIngredientModel ToModel(this AddedIngredient entity)
        {
            return new AddedIngredientModel
            {
                Id = entity.Id,
                Name = entity.Name ?? string.Empty,
                Price = entity.Price
            };
        }
    }
}
