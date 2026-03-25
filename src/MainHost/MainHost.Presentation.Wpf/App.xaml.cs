using MainHost.Application;
using MainHost.Infrastructure;
using Module.Abstractions;

namespace MainHost.Presentation.Wpf;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IModuleCatalog catalog = new ModuleCatalog();
        var loader = new FolderModuleLoader();

        var modulesDirectory = Path.Combine(AppContext.BaseDirectory, "Modules");

        foreach (var module in loader.LoadFrom(modulesDirectory))
        {
            catalog.Add(module);
        }

        var mainWindow = new MainWindow
        {
            DataContext = new MainWindowViewModel(catalog)
        };

        mainWindow.Show();
    }
}
