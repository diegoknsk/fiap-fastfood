using FastFood.Domain.Entities.OrderManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.OrderManagement
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .HasMaxLength(20);

            builder.Property(x => x.PaymentStatus)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.OrderStatus)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.TotalPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired(false);

            builder.HasOne(x => x.Customer)
                .WithMany() 
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderedProducts)
                .WithOne(x => x.Order) // mapeia a propriedade corretamente
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.Meals);
            builder.Ignore(x => x.SideDishes);
            builder.Ignore(x => x.Drinks);
            builder.Ignore(x => x.Desserts);
        }
    }
}
