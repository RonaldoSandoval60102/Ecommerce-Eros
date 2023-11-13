using Eros.src.Domain.Cart.Repository;

namespace Eros.src.Domain.Cart.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Models.Cart>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Models.Cart?> Get(long id)
        {
            return await _repository.Get(id);
        }

        public async Task<Models.Cart> Create(Models.Cart entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<Models.Cart> Update(Models.Cart entity)
        {
            return await _repository.Update(entity);
        }

        public void Delete(Models.Cart entity)
        {
            _repository.Delete(entity);
        }
    }
}