namespace ApiPlatform.Kernel.Core.Services
{
    public class SystemMetadata : ISystemMetadata
    {
        public CancellationToken CancellationToken { get; }

        public Dictionary<string, string> Metadata { get; }

        private SystemMetadata(CancellationToken cancellationToken)
        {
            CancellationToken = default;
            Metadata = [];
        }

        public void Add(string key, string value)
        {
            Metadata.TryAdd(key, value);
        }

        public static ISystemMetadata Create(CancellationToken cancellationToken = default)
        {
            return new SystemMetadata(cancellationToken);
        }
    }
}
