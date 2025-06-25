using Shared.Enum;

namespace Shared.Dtos.Order;

public class OrderWithoutDetailsDto
{
    public int Id { get; set; }
    public required OrderStateEnum State { get; set; }
    public DateTime Date { get; set; }
    public required int ClientId { get; set; }
}
