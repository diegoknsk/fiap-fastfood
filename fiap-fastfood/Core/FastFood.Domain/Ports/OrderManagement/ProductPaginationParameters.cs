using FastFood.Domain.Ports.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Ports.OrderManagement
{
    public class ProductPaginationParameters : PaginationParameters
    {
        public int? Category { get; set; }
    }
}
