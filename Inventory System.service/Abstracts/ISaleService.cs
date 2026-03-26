using Inventory_System.service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.service.Abstracts
{
    public interface ISaleService
    {
        Task<SaleResult> CreateSaleAsync(SaleDto saleDto);
    }

    public class SaleResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int? NewQuantity { get; set; }
    }
}
