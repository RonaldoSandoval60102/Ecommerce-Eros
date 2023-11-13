using Eros.src.Domain.OrderStatus.Repository;

namespace Eros.src.Domain.OrderStatus.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<Models.OrderStatus> Create(Models.OrderStatus entity)
        {
            return await _orderStatusRepository.Create(entity);
        }

        public void Delete(Models.OrderStatus entity)
        {
            _orderStatusRepository.Delete(entity);
        }

        public async Task<List<Models.OrderStatus>> Get()
        {
            return await _orderStatusRepository.Get();
        }

        public async Task<Models.OrderStatus?> Get(long id)
        {
            return await _orderStatusRepository.Get(id);
        }

        public async Task<Models.OrderStatus> Update(Models.OrderStatus entity)
        {
            return await _orderStatusRepository.Update(entity);
        }
    }
}