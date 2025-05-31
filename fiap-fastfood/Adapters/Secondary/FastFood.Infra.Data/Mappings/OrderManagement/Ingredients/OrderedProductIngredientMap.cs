using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.OrderManagement.Ingredients
{
    public class OrderedProductIngredientMap : IEntityTypeConfiguration<OrderedProductIngredient>
    {
        public void Configure(EntityTypeBuilder<OrderedProductIngredient> builder)
        {
            builder.ToTable("OrderedProductIngredients");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.OrderedProductId)
                .IsRequired();
            
            builder.Property(p => p.ProductBaseIngredientId)
                .HasColumnName("ProductBaseIngredientId");

            builder.HasOne<OrderedProduct>()
                .WithMany(p => p.CustomIngredients)
                .HasForeignKey(p => p.OrderedProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
