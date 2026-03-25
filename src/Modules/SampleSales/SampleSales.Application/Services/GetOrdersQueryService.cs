using SampleSales.Domain.Entities;

namespace SampleSales.Application.Services;

public interface IOrderReadRepository
{
    IReadOnlyList<Order> GetRecent(int take);
}

public sealed class GetOrdersQueryService
{
    private readonly IOrderReadRepository _repository;

    public GetOrdersQueryService(IOrderReadRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<Order> Execute(int take = 10)
    {
        return _repository.GetRecent(take);
    }
}
