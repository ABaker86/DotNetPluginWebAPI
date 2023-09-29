using System.Reflection;

namespace Plugin.API.Extensions;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Loads Controllers from external libraries and scans plugin directory for registries.
    /// </summary>
    public static IServiceCollection AddPlugins(this IServiceCollection services)
    {
        var pluginDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Plugins");

        if (!string.IsNullOrWhiteSpace(pluginDirectory) && Directory.Exists(pluginDirectory))
        {
            var pluginAssemblies = services.AddMvc().AddControllersAsPluginFromExternalLibrary(pluginDirectory);

            services.Scan(_ =>
                _.FromAssemblies(pluginAssemblies).AddClasses().AsImplementedInterfaces().WithTransientLifetime()
            );
        }

        return services;
    }

}