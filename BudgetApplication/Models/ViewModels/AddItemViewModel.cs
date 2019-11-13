using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace BudgetApplication.Models.ViewModels
{
    public class AddItemViewModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string PurchaseDate { get; set; }

    }
}
