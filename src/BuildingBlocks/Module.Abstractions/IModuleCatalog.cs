namespace Module.Abstractions;

public interface IModuleCatalog
{
    IReadOnlyCollection<IModule> Modules { get; }

    void Add(IModule module);
}
