using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models.DatabaseModels;
using BudgetApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetApplication.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            List<Category> categories = _categoryRepository.GetAllCategories();

            ViewBag.Category = new SelectList(_categoryRepository.GetAllCategories());

            return View();
        }

        [HttpPost]
        public IActionResult AddItem(AddItemViewModel item)
        {


            return View();
        }
    }
}