using Eros.src.DB;
using Eros.src.Domain.Product.Repository;

namespace Eros.src.Domain.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Models.Product> Create(Models.Product entity)
        {
            return await _productRepository.Create(entity);
        }

        public void Delete(Models.Product entity)
        {
            _productRepository.Delete(entity);
        }

        public async Task<List<Models.Product>> Get()
        {
            return await _productRepository.Get();
        }

        public async Task<Models.Product?> Get(long id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<Models.Product> Update(Models.Product entity)
        {
            return await _productRepository.Update(entity);
        }
    }
}