using System;
using System.Collections.Generic;

namespace BudgetApplication.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
    }
}
