using FastFood.Domain.Entities.OrderManagement;
using FastFood.Infra.Data.Context;
using FastFood.Infra.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Ports.OrderManagement;

namespace FastFood.Infra.Data.Repositories.OrderManagement
{
    public class OrderedProductRepository : BaseRepository<OrderedProduct>, IOrderedProductRepository
    {
        public OrderedProductRepository(FastFoodDbContext context) : base(context)
        {
        }
    }
}
