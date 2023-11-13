using Eros.src.Domain.Category.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.Category.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Category>>> Get()
        {
            var entity = await _categoryService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Category>> Get(int id)
        {
            var entity = await _categoryService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Category>> Create(Models.Category entity)
        {
            var createdDistrict = await _categoryService.Create(entity);
            return Ok(createdDistrict);
        }

        [HttpPut]
        public async Task<ActionResult<Models.Category>> Update(Models.Category entity)
        {
            var updatedDistrict = await _categoryService.Update(entity);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Delete(category);

            return NoContent();
        }

    }
}