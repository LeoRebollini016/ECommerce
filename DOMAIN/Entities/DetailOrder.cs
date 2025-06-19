using System.ComponentModel.DataAnnotations;

namespace DOMAIN.Entities;

public class DetailOrder
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public virtual required Product Product { get; set; }
    public virtual required Order Order { get; set; }
}
