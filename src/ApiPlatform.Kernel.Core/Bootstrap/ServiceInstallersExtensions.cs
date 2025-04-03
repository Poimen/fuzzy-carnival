using ApiPlatform.Kernel.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPlatform.Kernel.Core.Bootstrap;

public static class ServiceInstallersExtensions
{
    public static IServiceCollection AddInstaller<T>(this IServiceCollection services)
    {
        var installerTypes = typeof(T).Assembly
            .ExportedTypes
            .Where(t => t.IsClass && t.IsImplementationOf<IInstaller>());

        foreach (var installerType in installerTypes)
        {
            var installer = (IInstaller?) Activator.CreateInstance(installerType);

            installer?.Install(services);
        }

        return services;
    }
}
