using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataDbContext _context;

        public OrderRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Order> Create(Models.Order entity)
        {
            var result = await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }


        public async Task<Models.Order?> Get(long id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Models.Order> Update(Models.Order entity)
        {
            var result = await _context.Orders.FindAsync(entity.ID_Order);

            if (result == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            result.ID_OrderStatus = entity.ID_OrderStatus;
            result.ID_PaymentMethod = entity.ID_PaymentMethod;
            result.ID_User = entity.ID_User;
            result.ID_Order = entity.ID_Order;
            result.DateOrder = entity.DateOrder;
            result.TotalPrice = entity.TotalPrice;

            await _context.SaveChangesAsync();
            return result;
        }
    }
}