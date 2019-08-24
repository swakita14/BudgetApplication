using System;
using System.Collections.Generic;

namespace BudgetApplication.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
