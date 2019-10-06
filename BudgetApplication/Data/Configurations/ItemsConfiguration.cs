using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApplication.Data.Configurations
{
    public class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(e => e.ItemId)
                .HasName("PK_Item");

            builder.Property(e => e.ItemId).HasColumnName("ItemID");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Price)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.DatePurchased)
                .IsRequired();

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category");
        }
    }
}
