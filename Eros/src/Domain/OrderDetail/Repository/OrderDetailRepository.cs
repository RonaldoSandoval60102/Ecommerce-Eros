using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.OrderDetail.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataDbContext _context;

        public OrderDetailRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.OrderDetail> Create(Models.OrderDetail entity)
        {
            var result = await _context.OrderDetails.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.OrderDetail entity)
        {
            _context.OrderDetails.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.OrderDetail>> Get()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<Models.OrderDetail?> Get(long id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task<Models.OrderDetail> Update(Models.OrderDetail entity)
        {
            var result = await _context.OrderDetails.FindAsync(entity.ID_OrderDetail);

            if (result == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            result.ID_Order = entity.ID_Order;
            result.Quantity = entity.Quantity;
            result.Price = entity.Price;

            await _context.SaveChangesAsync();
            return result;
        }
    }
}