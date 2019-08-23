using System;
using System.Collections.Generic;

namespace BudgetApplication.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Items = new HashSet<Items>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
