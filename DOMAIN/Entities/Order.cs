using Shared.Enum;
namespace DOMAIN.Entities;

public class Order
{
    public int Id { get; set; }
    public required OrderStateEnum State { get; set; }
    public DateTime Date { get; set; }
    public required int ClientId { get; set; }

    public virtual Client Client { get; set; }
    public virtual required ICollection<DetailOrder> Details { get; set; } = new List<DetailOrder>();
}
