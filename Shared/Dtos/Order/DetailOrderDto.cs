using Shared.Enum;

namespace Shared.Dtos.Order;

public class DetailOrderDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
}
