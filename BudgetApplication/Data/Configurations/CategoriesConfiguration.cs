using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApplication.Data.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId)
                .HasName("PK_Category");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
