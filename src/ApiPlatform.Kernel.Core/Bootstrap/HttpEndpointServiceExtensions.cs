using ApiPlatform.Kernel.Core.Endpoints;
using ApiPlatform.Kernel.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApiPlatform.Kernel.Core.Bootstrap
{
    public static class HttpEndpointServiceExtensions
    {
        public static IServiceCollection AddHttpEndpoints(this IServiceCollection services)
        {
            var endpoints = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetExportedTypes())
                .Where(a => a.IsImplementationOf<IHttpEndpoint>() && a.IsClass);

            foreach(var endpoint in endpoints)
            {
                //services.TryAddTransient(typeof(IHttpEndpoint), endpoint);
                services.TryAddTransient(endpoint);
            }

            return services;
        }
    }
}
