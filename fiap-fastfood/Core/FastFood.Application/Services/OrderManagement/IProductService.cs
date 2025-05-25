using FastFood.Application.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Services.OrderManagement
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
    }
}
