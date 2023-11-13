
using Eros.src.Domain.OrderDetail.Repository;

namespace Eros.src.Domain.OrderDetail.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Models.OrderDetail> Create(Models.OrderDetail entity)
        {
            return await _orderDetailRepository.Create(entity);
        }

        public void Delete(Models.OrderDetail entity)
        {
            _orderDetailRepository.Delete(entity);
        }

        public async Task<List<Models.OrderDetail>> Get()
        {
            return await _orderDetailRepository.Get();
        }

        public async Task<Models.OrderDetail?> Get(long id)
        {
            return await _orderDetailRepository.Get(id);
        }

        public async Task<Models.OrderDetail> Update(Models.OrderDetail entity)
        {
            return await _orderDetailRepository.Update(entity);
        }
    }
}