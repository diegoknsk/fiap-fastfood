using FastFood.Domain.Entities.CustomerIdentification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Infra.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.CustomerType)
                .HasConversion<int>();

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("Email")
                    .HasMaxLength(150)
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(c => c.Value)
                    .HasColumnName("Cpf")
                    .HasMaxLength(11)
                    .IsRequired();
            });

        }
    }
}
