using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eros.src.Domain.Order.Services
{
    public interface IOrderService
    {
        Task<List<Models.Order>> Get();
        Task<Models.Order?> Get(long id);
        Task<Models.Order> Create(Models.Order entity);
        Task<Models.Order> Update(Models.Order entity);
        void Delete(Models.Order entity);
    }
}