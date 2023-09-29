using System.Reflection;

namespace Plugin.API.Extensions;

public static class IMvcBuilderExtensions
{
    /// <summary>
    /// Cycle through all assemblies in the plugin directory, load the library and add found controllers as Services.
    /// </summary>
    public static IEnumerable<Assembly> AddControllersAsPluginFromExternalLibrary(this IMvcBuilder builder, string pluginPath)
    {
        List<Assembly> assemblies = new();
        Directory
            .GetFiles(pluginPath, "*.dll")
            .ToList()
            .ForEach(x =>
            {
                var pluginAssembly = Assembly.LoadFile(x);
                builder.AddApplicationPart(pluginAssembly);
                assemblies.Add(pluginAssembly);
            });
        builder.AddControllersAsServices();
        return assemblies;
    }
}
