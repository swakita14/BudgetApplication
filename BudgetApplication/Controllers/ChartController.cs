using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    public class ChartController : Controller
    {

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