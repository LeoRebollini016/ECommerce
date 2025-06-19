using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRAESTRUCTURE.Configuration.EntitiesConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.State)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Date)
            .IsRequired()
            .HasColumnType("datetime");

        builder.HasOne(p => p.Client)
            .WithMany(d => d.Orders)
            .HasForeignKey(d => d.ClientId);

        builder.HasMany(p => p.Details)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId);
    }
}
