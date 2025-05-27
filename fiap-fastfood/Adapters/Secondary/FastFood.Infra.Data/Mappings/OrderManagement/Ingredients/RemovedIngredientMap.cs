using FastFood.Domain.Entities.OrderManagement.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.OrderManagement.Ingredients
{
    public class RemovedIngredientMap : IEntityTypeConfiguration<RemovedIngredient>
    {
        public void Configure(EntityTypeBuilder<RemovedIngredient> builder)
        {
            builder.ToTable("RemovedIngredients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.OrderedProductId)
                .IsRequired();
        }
    }
}
