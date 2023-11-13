using Eros.src.Domain.OrderDetail.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.OrderDetail.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.OrderDetail>>> Get()
        {
            var entity = await _orderDetailService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.OrderDetail>> Get(long id)
        {
            var entity = await _orderDetailService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.OrderDetail>> Post(Models.OrderDetail entity)
        {
            var result = await _orderDetailService.Create(entity);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.OrderDetail>> Put(Models.OrderDetail entity)
        {
            var result = await _orderDetailService.Update(entity);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var entity = await _orderDetailService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderDetailService.Delete(entity);
            return Ok();
        }
    }
}
