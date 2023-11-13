namespace Eros.src.Domain.PaymentTransaction.Services
{
    public interface IPaymentTransactionService
    {
        Task<List<Models.PaymentTransaction>> Get();
        Task<Models.PaymentTransaction?> Get(long id);
        Task<Models.PaymentTransaction> Create(Models.PaymentTransaction entity);
        Task<Models.PaymentTransaction> Update(Models.PaymentTransaction entity);
        void Delete(Models.PaymentTransaction entity);
    }
}