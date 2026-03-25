namespace Module.Abstractions;

public interface IModule
{
    string Name { get; }

    void RegisterServices(IServiceCollection services);

    void RegisterViews(IRegionRegistry regionRegistry);
}

public interface IServiceCollection
{
    void AddSingleton<TService, TImplementation>() where TImplementation : TService;
}

public interface IRegionRegistry
{
    void Register(string regionName, object view);
}
