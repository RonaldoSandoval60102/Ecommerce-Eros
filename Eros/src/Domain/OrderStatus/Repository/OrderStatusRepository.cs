using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.OrderStatus.Repository
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly DataDbContext _context;

        public OrderStatusRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.OrderStatus> Create(Models.OrderStatus entity)
        {
            var result = await _context.OrderStatus.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.OrderStatus entity)
        {
            _context.OrderStatus.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.OrderStatus>> Get()
        {
            return await _context.OrderStatus.ToListAsync();
        }

        public async Task<Models.OrderStatus?> Get(long id)
        {
            return await _context.OrderStatus.FindAsync(id);
        }

        public async Task<Models.OrderStatus> Update(Models.OrderStatus entity)
        {
            var result = await _context.OrderStatus.FindAsync(entity.ID_OrderStatus);
            if (result == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            result.NameOrderStatus = entity.NameOrderStatus;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}