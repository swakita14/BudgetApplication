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

        public ChartController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
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