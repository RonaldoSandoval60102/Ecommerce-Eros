using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eros.src.Domain.PaymentMethod.Services
{
    public interface IPaymentMethodService
    {
        Task<List<Models.PaymentMethod>> Get();
        Task<Models.PaymentMethod?> Get(long id);
        Task<Models.PaymentMethod> Create(Models.PaymentMethod entity);
        Task<Models.PaymentMethod> Update(Models.PaymentMethod entity);
        void Delete(Models.PaymentMethod entity);
    }
}