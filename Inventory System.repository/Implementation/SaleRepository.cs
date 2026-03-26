using Inventory_System.data.Context;
using Inventory_System.data.Entities;
using Inventory_System.repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.repository.Implementation
{
   
        public class SaleRepository : ISaleRepository
        {
            private readonly AppDbContext _context;

            public SaleRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task AddSaleAsync(Sale sale)
            {
                await _context.Sales.AddAsync(sale);
            }
        }
    }

