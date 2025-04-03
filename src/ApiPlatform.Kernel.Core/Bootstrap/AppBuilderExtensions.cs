using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPlatform.Kernel.Core.Bootstrap;

public static class AppBuilderExtensions
{
    public static void UseApiInstallers(this IApplicationBuilder application)
    {
        //var installers = application.ApplicationServices.GetServices<IInstaller>();

        //foreach (var installer in installers)
        //{
        //    installer.Install(application.ApplicationServices);
        //}

        //application.
    }
}
