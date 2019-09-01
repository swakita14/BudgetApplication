using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models;
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

    }
}