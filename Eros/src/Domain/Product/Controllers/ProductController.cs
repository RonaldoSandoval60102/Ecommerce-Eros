using Microsoft.AspNetCore.Mvc;

namespace Eros.src.Domain.Product.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly Services.IProductService _productService;

        public ProductController(Services.IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Product>>> Get()
        {
            var entity = await _productService.Get();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Product>> Get(long id)
        {
            var entity = await _productService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Product>> Post(Models.Product entity)
        {
            var result = await _productService.Create(entity);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.Product>> Put(Models.Product entity)
        {
            var result = await _productService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var entity = await _productService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            _productService.Delete(entity);
            return Ok();
        }
    }
}