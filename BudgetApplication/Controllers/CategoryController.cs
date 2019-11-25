using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;
using BudgetApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult AddNewCategory(AddCategoryViewModel model)
        {
            // Creating New Item
            Category newCategory = new Category()
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
            };

            // Adding Item to DB
            _categoryRepository.AddNewCategory(newCategory);

            return RedirectToAction("ChartView", "Chart");
        }

    }
}