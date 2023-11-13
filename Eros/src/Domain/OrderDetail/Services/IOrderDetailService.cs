
namespace Eros.src.Domain.OrderDetail.Services
{
    public interface IOrderDetailService
    {
        Task<List<Models.OrderDetail>> Get();
        Task<Models.OrderDetail?> Get(long id);
        Task<Models.OrderDetail> Create(Models.OrderDetail entity);
        Task<Models.OrderDetail> Update(Models.OrderDetail entity);
        void Delete(Models.OrderDetail entity);
        
    }
}