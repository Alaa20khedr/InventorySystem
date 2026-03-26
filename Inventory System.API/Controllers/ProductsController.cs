using Inventory_System.service.Abstracts;
using Inventory_System.service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
            int page = 1, int pageSize = 10, string? search = null)
        {
            var (products, totalCount) = await _productService.GetProductsAsync(page, pageSize, search);
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductDto>> CreateProduct(CreateProductDto productDto)
        {
            var created = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetProducts), created);
        }
    }
}

