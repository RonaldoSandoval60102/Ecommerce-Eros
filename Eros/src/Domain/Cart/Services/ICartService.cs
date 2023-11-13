namespace Eros.src.Domain.Cart.Services
{
    public interface ICartService
    {
        Task<List<Models.Cart>> Get();
        Task<Models.Cart?> Get(long id);
        Task<Models.Cart> Create(Models.Cart entity);
        Task<Models.Cart> Update(Models.Cart entity);
        void Delete(Models.Cart entity);
    }
}