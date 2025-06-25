using Shared.Enum;

namespace Shared.Dtos.Order;

public class OrderDto
{
    public int Id { get; set; }
    public required OrderStateEnum State { get; set; }
    public DateTime Date { get; set; }
    public required int ClientId { get; set; }
    public List<DetailOrderDto> Details { get; set; } = [];
}
