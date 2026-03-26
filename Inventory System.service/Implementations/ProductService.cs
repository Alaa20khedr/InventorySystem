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
   
        public class ProductService : IProductService
        {
            private readonly IProductRepository _productRepository;
            private readonly ISaleRepository _saleRepository; 

            public ProductService(IProductRepository productRepository, ISaleRepository saleRepository)
            {
                _productRepository = productRepository;
                _saleRepository = saleRepository;
            }

            public async Task<(IEnumerable<ProductDto> Products, int TotalCount)> GetProductsAsync(int page, int pageSize, string? search)
            {
                var products = await _productRepository.GetAllAsync(page, pageSize, search);
                var totalCount = await _productRepository.GetTotalCountAsync(search);

                var productDtos = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity
                });

                return (productDtos, totalCount);
            }

            public async Task<ProductDto> CreateProductAsync(CreateProductDto createDto)
            {
                var product = new Product
                {
                    Name = createDto.Name,
                    Quantity = createDto.Quantity
                };

                await _productRepository.AddAsync(product);
                await _productRepository.SaveChangesAsync();

                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Quantity = product.Quantity
                };
            }
        }
    }

