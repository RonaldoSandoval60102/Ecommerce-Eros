using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eros.src.Domain.PaymentMethod.Repository;

namespace Eros.src.Domain.PaymentMethod.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _repository;

        public PaymentMethodService(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<Models.PaymentMethod> Create(Models.PaymentMethod entity)
        {
            return await _repository.Create(entity);
        }

        public void Delete(Models.PaymentMethod entity)
        {
            _repository.Delete(entity);
        }

        public async Task<List<Models.PaymentMethod>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Models.PaymentMethod?> Get(long id)
        {
            return await _repository.Get(id);
        }

        public async Task<Models.PaymentMethod> Update(Models.PaymentMethod entity)
        {
            return await _repository.Update(entity);
        }
    }
}