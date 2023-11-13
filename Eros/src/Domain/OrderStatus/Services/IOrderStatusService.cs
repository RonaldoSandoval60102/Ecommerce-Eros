using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eros.src.Domain.OrderStatus.Services
{
    public interface IOrderStatusService
    {
        Task<List<Models.OrderStatus>> Get();
        Task<Models.OrderStatus?> Get(long id);
        Task<Models.OrderStatus> Create(Models.OrderStatus entity);
        Task<Models.OrderStatus> Update(Models.OrderStatus entity);
        void Delete(Models.OrderStatus entity);
    }
}