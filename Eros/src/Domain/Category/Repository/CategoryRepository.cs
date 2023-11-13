using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.Category.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataDbContext _context;

        public CategoryRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Category> Create(Models.Category entity)
        {
            var entry = await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public void Delete(Models.Category entity)
        {
            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Models.Category?> Get(long id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Models.Category> Update(Models.Category entity)
        {
            var entry = await _context.Categories.FindAsync(entity.ID_Category);
            if (entry == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }
            entry.NameCategory = entity.NameCategory;
            await _context.SaveChangesAsync();
            return entry;
        }
    }
}