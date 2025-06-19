using System.ComponentModel.DataAnnotations;

namespace DOMAIN.Entities;

public class Invoice
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public decimal Total { get; set; }
    [Required]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
}
