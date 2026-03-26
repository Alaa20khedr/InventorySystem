using Inventory_System.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.repository.Abstracts
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string? search);
        Task<int> GetTotalCountAsync(string? search);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task SaveChangesAsync(); 
    }
}
