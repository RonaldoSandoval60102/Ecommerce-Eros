namespace Eros.src.Domain.Product.Services
{
    public interface IProductService
    {
        Task<List<Models.Product>> Get();
        Task<Models.Product?> Get(long id);
        Task<Models.Product> Create(Models.Product entity);
        Task<Models.Product> Update(Models.Product entity);
        void Delete(Models.Product entity);
    }
}