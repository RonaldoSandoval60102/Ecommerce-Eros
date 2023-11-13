using Eros.src.Domain.Order.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.Order.Controllers
{    
    [ApiController]
    [Route("/api/[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Order>>> Get()
        {
            var districts = await _orderService.Get();
            return Ok(districts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Order>> Get(int id)
        {
            var district = await _orderService.Get(id);
            return Ok(district);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Order>> Post(Models.Order district)
        {
            var result = await _orderService.Create(district);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.Order>> Put(Models.Order district)
        {
            var result = await _orderService.Update(district);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var district = await _orderService.Get(id);
            if (district == null)
            {
                return NotFound();
            }

            _orderService.Delete(district);
            return Ok();
        }
    }
}