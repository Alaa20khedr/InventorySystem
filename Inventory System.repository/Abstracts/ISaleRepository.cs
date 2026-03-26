using Inventory_System.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.repository.Abstracts
{
    public interface ISaleRepository
    {
        Task AddSaleAsync(Sale sale);
        
    }
}
