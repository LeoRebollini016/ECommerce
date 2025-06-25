using DOMAIN.Entities;
using DOMAIN.Interfaces.Repositories;
using INFRAESTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Order;

namespace INFRAESTRUCTURE.Repositories.EF;

public class OrderRepository(ApplicationDbContext _context) : IOrderRepository
{
    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var entity = _context.Orders.FirstOrDefault(o => o.Id == id);
        _context.Orders.Remove(entity!);
        await _context.SaveChangesAsync(ct);
    }


    public async Task<IEnumerable<Order>> GetAllSummaryAsync(CancellationToken ct)
        => await _context.Orders.Include(x => x.Details).ToListAsync(ct);

    public async Task<Order?> GetOrderWithDetailsById(int id)
        => await _context.Orders
            .Include(x => x.Details)
            .FirstOrDefaultAsync(x => x.Id == id);
    public async Task<bool> ExistOrderById(int id, CancellationToken ct)
        => await _context.Orders.AnyAsync(x => x.Id == id, ct);
}
