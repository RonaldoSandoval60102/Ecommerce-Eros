using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eros.src.DB;

namespace Eros.src.Domain.OrderStatus.Repository
{
    public interface IOrderStatusRepository : IDbAccess<Models.OrderStatus>
    {
        
    }
}