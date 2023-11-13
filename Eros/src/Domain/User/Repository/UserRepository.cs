using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataDbContext _context;

        public UserRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.User> Create(Models.User entity)
        {
            var result = await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Models.User?> Get(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Models.User> Update(Models.User entity)
        {
            var result = await _context.Users.FindAsync(entity.ID_User);

            if (result == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }

            result.NameUser = entity.NameUser;
            result.LastNameUser = entity.LastNameUser;
            result.EmailUser = entity.EmailUser;
            result.PasswordUser = entity.PasswordUser;
            result.Cash = entity.Cash;
            
            await _context.SaveChangesAsync();
            return result;
        }
    }
}