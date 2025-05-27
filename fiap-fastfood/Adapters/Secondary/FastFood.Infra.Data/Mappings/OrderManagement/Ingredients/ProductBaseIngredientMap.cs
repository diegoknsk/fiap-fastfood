using FastFood.Domain.Entities.OrderManagement.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.OrderManagement.Ingredients
{
    public class ProductBaseIngredientMap : IEntityTypeConfiguration<ProductBaseIngredient>
    {
        public void Configure(EntityTypeBuilder<ProductBaseIngredient> builder)
        {
            builder.ToTable("ProductBaseIngredients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.ProductId)
                .IsRequired();
        }
    }
}
