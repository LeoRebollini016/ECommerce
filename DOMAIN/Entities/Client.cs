using System.ComponentModel.DataAnnotations;
namespace DOMAIN.Entities;

public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Direccion { get; set; }
    public string? Cuit { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
