using Eros.src.Domain.AuditLog.Repository;

namespace Eros.src.Domain.AuditLog.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<Models.AuditLog> Create(Models.AuditLog entity)
        {
            return await _auditLogRepository.Create(entity);
        }

        public void Delete(Models.AuditLog entity)
        {
            _auditLogRepository.Delete(entity);
        }

        public async Task<List<Models.AuditLog>> Get()
        {
            return await _auditLogRepository.Get();
        }

        public async Task<Models.AuditLog?> Get(long id)
        {
            return await _auditLogRepository.Get(id);
        }

        public async Task<Models.AuditLog> Update(Models.AuditLog entity)
        {
            return  await _auditLogRepository.Update(entity);
        }
    }
}