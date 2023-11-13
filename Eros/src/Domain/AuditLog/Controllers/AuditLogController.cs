using Eros.src.Domain.AuditLog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.AuditLog.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.AuditLog>>> Get()
        {
            var entity = await _auditLogService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.AuditLog>> Get(int id)
        {
            var entity = await _auditLogService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.AuditLog>> Create(Models.AuditLog entity)
        {
            var createdDistrict = await _auditLogService.Create(entity);
            return Ok(createdDistrict);
        }

        [HttpPut]
        public async Task<ActionResult<Models.AuditLog>> Update(Models.AuditLog entity)
        {
            var updatedDistrict = await _auditLogService.Update(entity);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var auditLog = await _auditLogService.Get(id);

            if (auditLog == null)
            {
                return NotFound();
            }

            _auditLogService.Delete(auditLog);

            return NoContent();
        }
    }
}