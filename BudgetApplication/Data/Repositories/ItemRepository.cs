using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Models;

namespace BudgetApplication.Data.Repositories
{
    public class ItemRepository
    {
        private readonly BudgetAppContext _context;

        public ItemRepository(BudgetAppContext context)
        {
            _context = context;
        }

    }
}
