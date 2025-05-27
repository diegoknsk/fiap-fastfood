using FastFood.Application.Mappers.Filters;
using FastFood.Application.Mappers.OrderManagement;
using FastFood.Application.Mappers.OrderManagement.Ingredients;
using FastFood.Application.Models.Common;
using FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Ports.Common;
using FastFood.Domain.Ports.OrderManagement;


namespace FastFood.Application.Services.OrderManagement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedList<ProductModel>> GetPagedAsync(ProductFilterParameters filter)
        {
            var domainParams = filter.ToDomain();
            var (entities, totalCount) = await _productRepository.GetPagedAsync(domainParams);

            var models = entities.Select(p => p.ToModel()).ToList();

            return new PagedList<ProductModel>(models, totalCount, filter.PageNumber, filter.PageSize);
        }


        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => p.ToModel());
        }

        public async Task<ProductModel?> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product?.ToModel();
        }

        public async Task<bool> CreateAsync(ProductModel model)
        {
            var entity = model.ToEntity();
            await _productRepository.AddAsync(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateAsync(ProductModel model)
        {
            var entity = model.ToEntity();
            _productRepository.Update(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _productRepository.Remove(entity);
            return await _unitOfWork.CommitAsync();
        }
    }
}
