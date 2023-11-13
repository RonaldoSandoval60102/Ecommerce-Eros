using Eros.src.Domain.Cart.Services;
using Eros.src.Event;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Eros.src.Domain.Cart.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        private readonly EventSender _eventSender;

        public CartController(ICartService cartService,EventSender eventSender)
        {
            _cartService = cartService;
            _eventSender = eventSender;
        }
        [HttpGet]
        public async Task<ActionResult<List<Models.Cart>>> Get()
        {
            var entity = await _cartService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Cart>> Get(int id)
        {
            var entity = await _cartService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Cart>> Create(Models.Cart entity)
        {
            var createdDistrict = await _cartService.Create(entity);
            await _eventSender.SendEventAsync("eros", JsonConvert.SerializeObject(entity), "add_cart");
            return Ok(createdDistrict);
        }


        [HttpPut]
        public async Task<ActionResult<Models.Cart>> Update(Models.Cart entity)
        {
            var updatedDistrict = await _cartService.Update(entity);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var cart = await _cartService.Get(id);

            if (cart == null)
            {
                return NotFound();
            }

            _cartService.Delete(cart);
            return NoContent();
        }
    }
}