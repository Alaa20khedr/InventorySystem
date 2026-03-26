using Inventory_System.service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.service.Abstracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> Products, int TotalCount)> GetProductsAsync(int page, int pageSize, string? search);
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto);
    }
}
