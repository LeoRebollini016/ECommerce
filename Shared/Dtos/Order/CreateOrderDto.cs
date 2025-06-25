using Shared.Enum;

namespace Shared.Dtos.Order;

public class CreateOrderDto
{
    public required OrderStateEnum State { get; set; }
    public DateTime Date { get; set; }
    public required int ClientId { get; set; }
    public List<DetailOrderDto> Details { get; set; } = [];
}
