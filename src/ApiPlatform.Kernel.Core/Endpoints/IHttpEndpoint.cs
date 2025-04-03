namespace ApiPlatform.Kernel.Core.Endpoints;

public interface IHttpEndpoint
{
    string Endpoint { get; }
}

public interface IHttpEndpoint<TResponse> : IHttpEndpoint;

public interface IHttpEndpoint<TRequest, TResponse> : IHttpEndpoint;
