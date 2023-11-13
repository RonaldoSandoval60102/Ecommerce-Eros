using Eros.src.Domain.Category.Services;
using Eros.src.Domain.PaymentMethod.Services;
using Eros.src.Domain.PaymentTransaction.Services;
using Microsoft.AspNetCore.Mvc;


namespace Eros.src.Domain.PaymentTransaction.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly IPaymentTransactionService _paymentTransactionsService;

        public PaymentTransactionController(IPaymentTransactionService paymentTransactionsService)
        {
            _paymentTransactionsService = paymentTransactionsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.PaymentTransaction>>> Get()
        {
            var entity = await _paymentTransactionsService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.PaymentTransaction>> Get(int id)
        {
            var entity = await _paymentTransactionsService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.PaymentTransaction>> Create(Models.PaymentTransaction entity)
        {
            var createdDistrict = await _paymentTransactionsService.Create(entity);
            return Ok(createdDistrict);
        }

        [HttpPut]
        public async Task<ActionResult<Models.PaymentTransaction>> Update(Models.PaymentTransaction entity)
        {
            var updatedDistrict = await _paymentTransactionsService.Update(entity);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var paymentTransaction = await _paymentTransactionsService.Get(id);

            if (paymentTransaction == null)
            {
                return NotFound();
            }

            _paymentTransactionsService.Delete(paymentTransaction);

            return NoContent();
        }
    }
}