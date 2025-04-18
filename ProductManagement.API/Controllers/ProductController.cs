using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.DTO;
using ProductManagement.API.Models;
using ProductManagement.API.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }



        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var product = await _productRepository.GetByIdAsync(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]ProductCreateDto payload)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var product = _mapper.Map<Product>(payload);
            // Optional: Set CreatedAt if not handled inside repo
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            var createdProduct = await _productRepository.AddAsync(product);

            // Return 201 Created with location header
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, ProductUpdateDto payload)
        {
            if (id != payload.Id) return BadRequest();

            var product = _mapper.Map<Product>(payload);

            product.UpdatedAt = DateTime.UtcNow;
            var updated = await _productRepository.UpdateAsync(product);
            return Ok(updated);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productRepository.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
