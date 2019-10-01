using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Data.Repositories;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models.JSModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public IActionResult ChartView()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach (var category in _categoryRepository.GetAllCategories())
            {
                dataPoints.Add(new DataPoint(category.Name, _itemRepository.GetItemValueTotalByCategory(category.CategoryId)));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
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