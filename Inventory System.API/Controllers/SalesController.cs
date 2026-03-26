using Inventory_System.service.Abstracts;
using Inventory_System.service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleDto saleDto)
        {
            var result = await _saleService.CreateSaleAsync(saleDto);

            if (!result.Success)
            {
                if (result.Message?.Contains("not found") == true)
                    return NotFound(result.Message);
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
