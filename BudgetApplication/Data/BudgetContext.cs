
using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
        }
    }
}
