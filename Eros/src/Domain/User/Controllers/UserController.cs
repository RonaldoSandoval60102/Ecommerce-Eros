using Eros.src.Domain.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.User.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.User>>> Get()
        {
            var entity = await _userService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.User>> Get(int id)
        {
            var entity = await _userService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.User>> Post(Models.User entity)
        {
            var result = await _userService.Create(entity);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.User>> Put(Models.User entity)
        {
            var result = await _userService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var entity = await _userService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            _userService.Delete(entity);
            return Ok();
        }
    }
}