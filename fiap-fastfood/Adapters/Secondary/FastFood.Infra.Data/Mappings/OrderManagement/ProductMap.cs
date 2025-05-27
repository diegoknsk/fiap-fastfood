using FastFood.Domain.Entities.OrderManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.OrderManagement
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.Category)
                .HasConversion<int>()
                .IsRequired();

            // VO: ImageProduct
            builder.OwnsOne(x => x.Image, img =>
            {
                img.Property(i => i.Name).HasColumnName("ImageName").HasMaxLength(150);
                img.Property(i => i.Url).HasColumnName("ImageUrl").HasMaxLength(300);
            });

            builder.HasMany(p => p.Ingredients)
                .WithOne()
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
