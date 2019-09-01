using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Data.Repositories;
using BudgetApplication.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    public class ChartController : Controller
    {

        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ChartController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

    }
}