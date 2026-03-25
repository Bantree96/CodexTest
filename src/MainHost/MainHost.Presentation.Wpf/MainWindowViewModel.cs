using Module.Abstractions;

namespace MainHost.Presentation.Wpf;

public sealed class MainWindowViewModel
{
    public IReadOnlyList<string> ModuleNames { get; }

    public MainWindowViewModel(IModuleCatalog moduleCatalog)
    {
        ModuleNames = moduleCatalog.Modules.Select(m => m.Name).ToList();
    }
}
