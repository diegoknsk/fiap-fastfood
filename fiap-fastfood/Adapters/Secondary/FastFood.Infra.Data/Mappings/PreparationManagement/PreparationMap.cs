using FastFood.Domain.Entities.PreparationManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings.PreparationManagement
{
    public class PreparationMap : IEntityTypeConfiguration<Preparation>
    {
        public void Configure(EntityTypeBuilder<Preparation> builder)
        {
            builder.ToTable("Preparations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.StartedAt);

            builder.Property(x => x.FinishedAt);
        }
    }
}
