using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRAESTRUCTURE.Configuration.EntitiesConfiguration;

public class DetailOrderConfiguration : IEntityTypeConfiguration<DetailOrder>
{
    public void Configure(EntityTypeBuilder<DetailOrder> builder)
    {
        builder.ToTable("DetailOrders");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.SubTotal)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Order)
            .WithMany(d => d.Details)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Product)
            .WithMany(d => d.DetailOrders)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
