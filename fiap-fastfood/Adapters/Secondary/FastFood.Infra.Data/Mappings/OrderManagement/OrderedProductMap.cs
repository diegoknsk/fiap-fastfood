using FastFood.Domain.Entities.OrderManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.OrderManagement
{
    public class OrderedProductMap : IEntityTypeConfiguration<OrderedProduct>
    {
        public void Configure(EntityTypeBuilder<OrderedProduct> builder)
        {
            builder.ToTable("OrderedProducts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Observation)
                .HasMaxLength(300);

            builder.Property(x => x.FinalPrice)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();
            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany(o => o.OrderedProducts)
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.CustomIngredients)
                .WithOne(i => i.OrderedProduct)
                .HasForeignKey(i => i.OrderedProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
