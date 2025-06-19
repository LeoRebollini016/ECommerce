using System.ComponentModel.DataAnnotations;

namespace DOMAIN.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
}
