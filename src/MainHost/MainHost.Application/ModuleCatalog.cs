using Module.Abstractions;

namespace MainHost.Application;

public sealed class ModuleCatalog : IModuleCatalog
{
    private readonly List<IModule> _modules = new();

    public IReadOnlyCollection<IModule> Modules => _modules;

    public void Add(IModule module)
    {
        if (_modules.Any(m => m.Name == module.Name))
        {
            return;
        }

        _modules.Add(module);
    }
}
