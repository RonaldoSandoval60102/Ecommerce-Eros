using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.PaymentMethod.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly DataDbContext _context;

        public PaymentMethodRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.PaymentMethod> Create(Models.PaymentMethod entity)
        {
            var result = await _context.PaymentMethods.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.PaymentMethod entity)
        {
            _context.PaymentMethods.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.PaymentMethod>> Get()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<Models.PaymentMethod?> Get(long id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<Models.PaymentMethod> Update(Models.PaymentMethod entity)
        {
            var entry = await _context.PaymentMethods.FindAsync(entity.ID_PaymentMethod);

            if (entry == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            entry.NamePaymentMethod = entity.NamePaymentMethod;
            await _context.SaveChangesAsync();
            return entry;
        }
    }
}