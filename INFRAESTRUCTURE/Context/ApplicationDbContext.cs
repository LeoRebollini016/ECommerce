using DOMAIN.Entities;
using INFRAESTRUCTURE.Configuration.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Context;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<DetailOrder> DetailsOrders { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new DetailOrderConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}
