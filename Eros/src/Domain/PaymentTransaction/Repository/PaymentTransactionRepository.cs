using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.PaymentTransaction.Repository
{
    public class PaymentTransactionRepository : IPaymentTransactionRepository
    {
        private readonly DataDbContext _context;

        public PaymentTransactionRepository(DataDbContext context)
        {
            _context = context;
        }


        public async Task<Models.PaymentTransaction> Create(Models.PaymentTransaction entity)
        {
            var entry = await _context.PaymentTransactions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public void Delete(Models.PaymentTransaction entity)
        {
            _context.PaymentTransactions.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.PaymentTransaction>> Get()
        {
            return await _context.PaymentTransactions.ToListAsync();
        }

        public async Task<Models.PaymentTransaction?> Get(long id)
        {
            return await _context.PaymentTransactions.FindAsync(id);
        }

        public async Task<Models.PaymentTransaction> Update(Models.PaymentTransaction entity)
        {
            var entry = await _context.PaymentTransactions.FindAsync(entity.ID_PaymentTransaction);
            if (entry == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            entry.ID_PaymentTransaction = entity.ID_PaymentTransaction;
            entry.ID_Order = entity.ID_Order;
            entry.Amount = entity.Amount;
            entry.PaymentDate = entity.PaymentDate;
            entry.Status = entity.Status;

            await _context.SaveChangesAsync();
            return entry;
        }
    }
}