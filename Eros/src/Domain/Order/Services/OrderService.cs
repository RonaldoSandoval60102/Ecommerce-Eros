using Eros.src.Domain.Order.Repository;

namespace Eros.src.Domain.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Models.Order> Create(Models.Order entity)
        {
            return await _orderRepository.Create(entity);
        }

        public void Delete(Models.Order entity)
        {
            _orderRepository.Delete(entity);
        }

        public async Task<List<Models.Order>> Get()
        {
            return await _orderRepository.Get();
        }

        public async Task<Models.Order?> Get(long id)
        {
            return await _orderRepository.Get(id);
        }

        public async Task<Models.Order> Update(Models.Order entity)
        {
            return await _orderRepository.Update(entity);
        }
    }
}