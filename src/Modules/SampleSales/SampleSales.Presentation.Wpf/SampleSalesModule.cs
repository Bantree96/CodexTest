using Module.Abstractions;
using SampleSales.Application.Services;
using SampleSales.Infrastructure.Persistence;

namespace SampleSales.Presentation.Wpf;

public sealed class SampleSalesModule : IModule
{
    public string Name => "SampleSales";

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IOrderReadRepository, InMemoryOrderRepository>();
        services.AddSingleton<GetOrdersQueryService, GetOrdersQueryService>();
    }

    public void RegisterViews(IRegionRegistry regionRegistry)
    {
        regionRegistry.Register("DashboardRegion", new Views.SalesDashboardView());
    }
}
