using CRUDApiDotNet.src.DTOs;
using CRUDApiDotNet.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApiDotNet.src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsControllers: ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductsControllers(IProductServices productServices)
        {
            _productService = productServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createDto)
        {
            var newProduct = await _productService.CreateProduct(createDto);
            return CreatedAtAction(nameof(GetProductById), new {id = newProduct.ID}, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, CreateProductDto updateDto)
        {
            var product = await _productService.UpdateProduct(id, updateDto);
            if (product == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProduct(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}