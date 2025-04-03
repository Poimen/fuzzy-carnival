using ApiPlatform.Kernel.Core.Endpoints;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPlatform.Kernel.Core.Bootstrap;

public static class EndpointRoutingExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var https = app.ServiceProvider.GetServices<IHttpEndpoint>();


        //var installer = (IInstaller?) endpoints.ServiceProvider.GetService(typeof(IInstaller));

        //var i = AppDomain.CurrentDomain.GetAssemblies()
        //    .SelectMany(a => a.GetExportedTypes())
        //    .SelectMany(t => t.GetInterfaces());

        //var e = Assembly.GetCallingAssembly()
        //    .ExportedTypes
        //    .Where(t => t.IsClass)
        //    .SelectMany(t => t.GetInterfaces(), (c, i) => new { Class = c, Interface = i })
        //    .ToList();
    }
}
