using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IActionResult AddItem()
        {
            return View();
        }
    }
}