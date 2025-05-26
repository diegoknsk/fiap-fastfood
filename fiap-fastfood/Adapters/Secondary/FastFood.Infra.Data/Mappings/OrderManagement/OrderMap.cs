using FastFood.Domain.Entities.OrderManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.Property(x => x.CustomerId);

            builder.HasMany(x => x.OrderedMealProducts)
                .WithOne()
                .HasForeignKey("OrderId_Meal");

            builder.HasMany(x => x.OrderedSideDish)
                .WithOne()
                .HasForeignKey("OrderId_SideDish");

            builder.HasMany(x => x.OrderedDrink)
                .WithOne()
                .HasForeignKey("OrderId_Drink");

            builder.HasMany(x => x.OrderedDessert)
                .WithOne()
                .HasForeignKey("OrderId_Dessert");
        }
    }
}
