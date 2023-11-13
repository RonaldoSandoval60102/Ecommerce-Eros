using Eros.src.Domain.PaymentMethod.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.PaymentMethod.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.PaymentMethod>>> Get()
        {
            var entity = await _paymentMethodService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.PaymentMethod>> Get(int id)
        {
            var entity = await _paymentMethodService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.PaymentMethod>> Create(Models.PaymentMethod entity)
        {
            var createdDistrict = await _paymentMethodService.Create(entity);
            return Ok(createdDistrict);
        }

        [HttpPut]
        public async Task<ActionResult<Models.PaymentMethod>> Update(Models.PaymentMethod entity)
        {
            var updatedDistrict = await _paymentMethodService.Update(entity);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var paymentMethod = await _paymentMethodService.Get(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            _paymentMethodService.Delete(paymentMethod);

            return NoContent();
        }
    }
}