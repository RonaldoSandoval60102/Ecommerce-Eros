using Eros.src.DB;

namespace Eros.src.Domain.AuditLog.Repository
{
    public interface IAuditLogRepository : IDbAccess<Models.AuditLog>
    {
        
    }
}