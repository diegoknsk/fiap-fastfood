using FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Ports.OrderManagement;

namespace FastFood.Application.Mappers.Filters
{
    public static class ProductFilterMapper
    {
        public static ProductPaginationParameters ToDomain(this ProductFilterParameters filter)
        {
            return new ProductPaginationParameters
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Category = (int?)filter.Category
            };
        }
    }
}
