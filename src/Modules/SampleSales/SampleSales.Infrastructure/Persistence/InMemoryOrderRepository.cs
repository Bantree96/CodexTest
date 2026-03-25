using SampleSales.Application.Services;
using SampleSales.Domain.Entities;

namespace SampleSales.Infrastructure.Persistence;

public sealed class InMemoryOrderRepository : IOrderReadRepository
{
    private static readonly IReadOnlyList<Order> Seed =
    [
        new() { Id = Guid.NewGuid(), CustomerName = "Alice", TotalAmount = 120_000m, OrderedAtUtc = DateTime.UtcNow.AddDays(-1) },
        new() { Id = Guid.NewGuid(), CustomerName = "Bob", TotalAmount = 89_000m, OrderedAtUtc = DateTime.UtcNow.AddHours(-2) }
    ];

    public IReadOnlyList<Order> GetRecent(int take)
    {
        return Seed.OrderByDescending(x => x.OrderedAtUtc).Take(take).ToList();
    }
}
