using Inventory_System.data.Context;
using Inventory_System.data.Entities;
using Inventory_System.repository.Abstracts;
using Inventory_System.service.Abstracts;
using Inventory_System.service.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.service.Implementations
{
   
        public class SaleService : ISaleService
        {
            private readonly IProductRepository _productRepository;
            private readonly ISaleRepository _saleRepository;

            public SaleService(IProductRepository productRepository, ISaleRepository saleRepository)
            {
                _productRepository = productRepository;
                _saleRepository = saleRepository;
            }

            public async Task<SaleResult> CreateSaleAsync(SaleDto saleDto)
            {
                var product = await _productRepository.GetByIdAsync(saleDto.ProductId);
                if (product == null)
                    return new SaleResult { Success = false, Message = $"Product with ID {saleDto.ProductId} not found." };

                if (product.Quantity < saleDto.Quantity)
                    return new SaleResult { Success = false, Message = "Not enough stock available." };

              
                product.Quantity -= saleDto.Quantity;
                await _productRepository.UpdateAsync(product);

             
                var sale = new Sale
                {
                    ProductId = product.Id,
                    Quantity = saleDto.Quantity,
                    CreatedAt = DateTime.UtcNow
                };
                await _saleRepository.AddSaleAsync(sale);

            
                try
                {
                    await _productRepository.SaveChangesAsync(); 
                    return new SaleResult { Success = true, Message = "Sale recorded successfully." };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new SaleResult { Success = false, Message = "The stock was modified by another request. Please try again." };
                }
            }
        }
    }

