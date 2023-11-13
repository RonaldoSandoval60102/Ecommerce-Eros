using Eros.src.Domain.PaymentTransaction.Repository;

namespace Eros.src.Domain.PaymentTransaction.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IPaymentTransactionRepository _repository;

        public PaymentTransactionService(IPaymentTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Models.PaymentTransaction> Create(Models.PaymentTransaction entity)
        {
            return await _repository.Create(entity);
        }

        public void Delete(Models.PaymentTransaction entity)
        {
            _repository.Delete(entity);
        }

        public async Task<List<Models.PaymentTransaction>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Models.PaymentTransaction?> Get(long id)
        {
            return await _repository.Get(id);
        }

        public async Task<Models.PaymentTransaction> Update(Models.PaymentTransaction entity)
        {
            return await _repository.Update(entity);
        }
    }
}