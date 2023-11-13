using Eros.src.Domain.OrderStatus.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.OrderStatus.Controllers
{
    [ApiController]
    [Route("/api/[controller]es")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.OrderStatus>>> Get()
        {
            var entity = await _orderStatusService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.OrderStatus>> Get(int id)
        {
            var entity = await _orderStatusService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.OrderStatus>> Post(Models.OrderStatus entity)
        {
            var result = await _orderStatusService.Create(entity);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.OrderStatus>> Put(Models.OrderStatus entity)
        {
            var result = await _orderStatusService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _orderStatusService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderStatusService.Delete(entity);
            return Ok();
        }
    }
}