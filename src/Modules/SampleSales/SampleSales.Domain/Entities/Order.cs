namespace SampleSales.Domain.Entities;

public sealed class Order
{
    public Guid Id { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public decimal TotalAmount { get; init; }
    public DateTime OrderedAtUtc { get; init; }
}
