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
            // Adding the dropdown to the view
            CategoryDropDown();

            return View();
        }

        [HttpPost]
        public IActionResult AddItem(AddItemViewModel item)
        {
            // Adding the dropdown to the view
            CategoryDropDown();

            // Creating New Item
            Item newItem = new Item()
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Price = item.Price.ToString(),
                Category = _categoryRepository.GetCategoryByName(item.Category),
                CategoryId = _categoryRepository.GetCategoryByName(item.Category).CategoryId,
                DatePurchased = DateTime.Parse(item.PurchaseDate)
            };

            // Adding Item to DB
            _itemRepository.AddItem(newItem);

            return RedirectToAction("ChartView", "Chart");
        }

        public void CategoryDropDown()
        {
            ViewBag.Category = new SelectList(_categoryRepository.GetAllCategoryName());
        }
    }
}