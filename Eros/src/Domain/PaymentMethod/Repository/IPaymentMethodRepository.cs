using Eros.src.DB;

namespace Eros.src.Domain.PaymentMethod.Repository
{
    public interface IPaymentMethodRepository : IDbAccess<Models.PaymentMethod>
    {
        
    }
}