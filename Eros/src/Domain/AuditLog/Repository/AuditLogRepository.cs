
using Eros.src.DB;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.AuditLog.Repository
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly DataDbContext _context;

        public AuditLogRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Models.AuditLog> Create(Models.AuditLog entity)
        {
            var result = await _context.AuditLogs.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Models.AuditLog entity)
        {
            _context.AuditLogs.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<Models.AuditLog>> Get()
        {
            return await _context.AuditLogs.ToListAsync();
        }

        public async Task<Models.AuditLog?> Get(long id)
        {
            return await _context.AuditLogs.FindAsync(id);
        }

        public async Task<Models.AuditLog> Update(Models.AuditLog entity)
        {
            var entry = await _context.AuditLogs.FindAsync(entity.ID_AuditLog);
            if (entry == null)
            {
                throw new InvalidOperationException("The entity does not exists");
            }
            entry.ID_User = entity.ID_User;
            entry.Action = entity.Action;
            entry.TableName = entity.TableName;
            entry.RecordID = entity.RecordID;
            entry.Timestamp = entity.Timestamp;

            await _context.SaveChangesAsync();
            return entry;
        }
    }
}