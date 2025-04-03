using Microsoft.Extensions.DependencyInjection;

namespace ApiPlatform.Kernel.Core.Bootstrap;

public interface IInstaller
{
    void Install(IServiceCollection services);
}
