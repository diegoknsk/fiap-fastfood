using FastFood.Application.Mappers;
using FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Ports.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Services.OrderManagement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _productRepository.ListAll().Select(p => p.ToModel());
        }
    }
}
