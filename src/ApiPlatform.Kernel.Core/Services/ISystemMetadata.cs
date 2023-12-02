
namespace ApiPlatform.Kernel.Core.Services
{
    public interface ISystemMetadata
    {
        CancellationToken CancellationToken { get; }
        Dictionary<string, string> Metadata { get; }
    }
}