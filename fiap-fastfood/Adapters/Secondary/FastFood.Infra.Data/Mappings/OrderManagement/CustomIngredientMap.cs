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
    public class CustomIngredientMap : IEntityTypeConfiguration<CustomIngredient>
    {
        public void Configure(EntityTypeBuilder<CustomIngredient> builder)
        {
            builder.ToTable("CustomIngredients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        }
    }
}
