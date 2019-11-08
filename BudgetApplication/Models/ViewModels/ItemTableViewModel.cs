using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApplication.Models.ViewModels
{
    public class ItemTableViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public DateTime PurchasedDate { get; set; }
    }
}
