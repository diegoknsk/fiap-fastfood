using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Ports.Common;

namespace FastFood.Application.Models.OrderManagement
{
    public class ProductFilterParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public EnumProductCategory? Category { get; set; }

        public PaginationParameters ToPaginationParameters()
        {
            return new PaginationParameters
            {
                PageNumber = this.PageNumber,
                PageSize = this.PageSize
            };
        }
    }
}
