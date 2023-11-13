using Eros.src.DB;

namespace Eros.src.Domain.PaymentTransaction.Repository
{
    public interface IPaymentTransactionRepository : IDbAccess<Models.PaymentTransaction>
    {
        
    }
}