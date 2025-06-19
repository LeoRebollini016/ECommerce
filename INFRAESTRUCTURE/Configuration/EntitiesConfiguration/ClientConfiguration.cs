using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRAESTRUCTURE.Configuration.EntitiesConfiguration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Cuit)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasMany(p => p.Orders)
            .WithOne(d => d.Client)
            .HasForeignKey(d => d.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
