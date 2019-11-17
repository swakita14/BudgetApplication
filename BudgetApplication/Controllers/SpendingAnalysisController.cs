using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;

            Debug.Write(names);
            return View();
        }

        [HttpGet]
        public JsonResult GetMonthlySpendingByYear()
        {
            // Initialized month name list 
            List<string> monthNameList = new List<string>();

            // Added month individually since there is a blank at index#13
            for (int i = 0; i < 12; i++)
            {
                monthNameList.Add(DateTimeFormatInfo.CurrentInfo.MonthNames[i]);
            }

            var monthlySpending = _itemRepository.GetYearSpendingMonthly();
            var monthNames = monthNameList;

            return Json(new {monthNames, monthlySpending});
        }



    }
}