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

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasMany(x => x.AddedIngredients)
                .WithOne()
                .HasForeignKey("OrderedProductId_Added")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.RemovedIngredients)
                .WithOne()
                .HasForeignKey("OrderedProductId_Removed")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
