namespace Eros.src.Domain.AuditLog.Services
{
    public interface IAuditLogService
    {
        Task<List<Models.AuditLog>> Get();
        Task<Models.AuditLog?> Get(long id);
        Task<Models.AuditLog> Create(Models.AuditLog entity);
        Task<Models.AuditLog> Update(Models.AuditLog entity);
        void Delete(Models.AuditLog entity);       
    }
}