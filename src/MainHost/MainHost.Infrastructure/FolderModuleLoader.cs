using System.Reflection;
using Module.Abstractions;

namespace MainHost.Infrastructure;

public sealed class FolderModuleLoader
{
    public IEnumerable<IModule> LoadFrom(string modulesPath)
    {
        if (!Directory.Exists(modulesPath))
        {
            yield break;
        }

        foreach (var dll in Directory.GetFiles(modulesPath, "*.dll", SearchOption.TopDirectoryOnly))
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(dll);
            }
            catch
            {
                continue;
            }

            var moduleTypes = assembly.GetTypes()
                .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in moduleTypes)
            {
                if (Activator.CreateInstance(type) is IModule module)
                {
                    yield return module;
                }
            }
        }
    }
}
