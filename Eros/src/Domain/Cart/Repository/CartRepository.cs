using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.Cart.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataDbContext _context;

        public CartRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Cart> Create(Models.Cart entity)
        {
            var entry = await _context.Carts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public void Delete(Models.Cart entity)
        {
            _context.Carts.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.Cart>> Get()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Models.Cart?> Get(long id)
        {
            return await _context.Carts.FindAsync(id);
        }

        public async Task<Models.Cart> Update(Models.Cart entity)
        {
            var entry = await _context.Carts.FindAsync(entity.ID_Cart);
            if (entry == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }
            entry.ID_User = entity.ID_User;
            entry.ID_Product = entity.ID_Product;
            entry.Quantity = entity.Quantity;
            await _context.SaveChangesAsync();
            return entry;
        }
    }
}