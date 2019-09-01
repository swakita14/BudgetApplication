using System;
using BudgetApplication.Data.Configurations;
using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BudgetApplication.Data
{
    public partial class BudgetAppContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BudgetAppContext(DbContextOptions<BudgetAppContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BudgetAppDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            // Registering the separate configuration files 
            modelBuilder.ApplyConfiguration(new ItemsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());

        }
    }
}
