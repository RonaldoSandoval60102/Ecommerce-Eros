using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.Address.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataDbContext _context;

        public AddressRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Address> Create(Models.Address entity)
        {
            var result = await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.Address entity)
        {
            _context.Addresses.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.Address>> Get()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Models.Address?> Get(long id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Models.Address> Update(Models.Address entity)
        {
            var entry = await _context.Addresses.FindAsync(entity.ID_Address);
            if (entry == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }
            entry.ID_User = entity.ID_User;
            entry.Type = entity.Type;
            entry.StreetAddress = entity.StreetAddress;
            entry.City = entity.City;
            entry.State = entity.State;
            entry.PostalCode = entity.PostalCode;

            await _context.SaveChangesAsync();
            return entry;
        }
    }
}