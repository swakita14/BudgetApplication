using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Data.Repositories;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models.DatabaseModels;
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
            // Initializing data points list
            List<DataPoint> dataPoints = new List<DataPoint>();

            // Used to find the total double value for pie chart percentage
            double totalPercent = ReturnTotalPercent(_categoryRepository.GetAllCategories());

            // Getting the category datapoints to the view
            foreach (var category in _categoryRepository.GetAllCategories())
            {
                dataPoints.Add(new DataPoint(category.Name, Math.Round(((_itemRepository.GetItemValueTotalByCategory(category.CategoryId) / totalPercent) * 100), MidpointRounding.AwayFromZero)));
            }

            // Return Json Data to View
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            // Returning all items to be sorted out in the view
            return View(_itemRepository.GetAllItems());
        }

        /**
         * Helper method to return the total value of the category 
         */
        public double ReturnTotalPercent(List<Category> categories)
        {
            // Initializing variable
            double totalPercent = 0;

            // Adding up all the totals from each category
            foreach (var category in categories)
            {
                totalPercent += _itemRepository.GetItemValueTotalByCategory(category.CategoryId);
            }


            return totalPercent;
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