using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataDbContext _context;

        public ProductRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Product> Create(Models.Product entity)
        {
            var result = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Models.Product?> Get(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Models.Product> Update(Models.Product entity)
        {
            var result = await _context.Products.FindAsync(entity.ID_Product);
            if (result == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            result.NameProduct = entity.NameProduct;
            result.DescriptionProduct = entity.DescriptionProduct;
            result.PriceProduct = entity.PriceProduct;
            result.StockProduct = entity.StockProduct;
            result.ImageProduct = entity.ImageProduct;
            result.ID_Category = entity.ID_Category;

            await _context.SaveChangesAsync();
            return result;
        }
    }
}