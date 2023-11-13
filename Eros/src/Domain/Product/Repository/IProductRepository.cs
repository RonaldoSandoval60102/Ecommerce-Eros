using Eros.src.DB;

namespace Eros.src.Domain.Product.Repository
{
    public interface IProductRepository : IDbAccess<Models.Product>
    {
    }
}