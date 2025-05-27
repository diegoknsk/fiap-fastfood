using FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.ValueObjects;

namespace FastFood.Application.Mappers.OrderManagement
{
    public static class ImageProductMapper
    {
        public static ImageProduct? ToEntity(this ImageProductModel? model)
        {
            if (model == null || (string.IsNullOrWhiteSpace(model.Name) && string.IsNullOrWhiteSpace(model.Url)))
                return null;

            return new ImageProduct(model.Name, model.Url);
        }

        public static ImageProductModel? ToModel(this ImageProduct? entity)
        {
            if (entity == null)
                return null;

            return new ImageProductModel
            {
                Name = entity.Name,
                Url = entity.Url
            };
        }
    }
}
