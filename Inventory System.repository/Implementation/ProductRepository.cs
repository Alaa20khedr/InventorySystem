using Inventory_System.data.Context;
using Inventory_System.data.Entities;
using Inventory_System.repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.repository.Implementation
{
    
        public class ProductRepository : IProductRepository
        {
            private readonly AppDbContext _context;

            public ProductRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Product?> GetByIdAsync(int id)
            {
                return await _context.Products.FindAsync(id);
            }

            public async Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string? search)
            {
                var query = _context.Products.AsQueryable();
                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(p => p.Name.Contains(search));

                return await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }

            public async Task<int> GetTotalCountAsync(string? search)
            {
                var query = _context.Products.AsQueryable();
                if (!string.IsNullOrWhiteSpace(search))
                    query = query.Where(p => p.Name.Contains(search));
                return await query.CountAsync();
            }

            public async Task AddAsync(Product product)
            {
                await _context.Products.AddAsync(product);
            }

            public Task UpdateAsync(Product product)
            {
                _context.Products.Update(product);
                return Task.CompletedTask;
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }

