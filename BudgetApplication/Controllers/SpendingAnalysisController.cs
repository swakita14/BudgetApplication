using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    public class SpendingAnalysisController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SpendingAnalysisController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult SpendingPerMonth()
        {
            // Initializing a new list with all the totals of month
            List<decimal> yearlySpending = new List<decimal>();

            // Adding the total of each month 
            for (int i = 1; i < 13; i++)
            {
                yearlySpending.Add(_itemRepository.TotalSpendingByMonth(i));
            }

            return View();
        }

    }
}