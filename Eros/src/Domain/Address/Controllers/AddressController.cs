using Eros.src.Domain.Address.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.Address.Controllers
{
    [ApiController]
    [Route("/api/[controller]es")]

    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Address>>> Get()
        {
            var entity = await _addressService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Address>> Get(int id)
        {
            var entity = await _addressService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Address>> Create(Models.Address entity)
        {
            var createdDistrict = await _addressService.Create(entity);
            return Ok(createdDistrict);
        }

        [HttpPut]
        public async Task<ActionResult<Models.Address>> Update(Models.Address entity)
        {
            var updatedDistrict = await _addressService.Update(entity);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var address = await _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            _addressService.Delete(address);

            return NoContent();
        }
    }
}