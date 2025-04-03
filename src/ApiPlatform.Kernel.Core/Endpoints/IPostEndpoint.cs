using ApiPlatform.Kernel.Core.Results;

namespace ApiPlatform.Kernel.Core.Endpoints;

public interface IPostEndpoint : IHttpEndpoint
{
    ValueTask<IApplicationResult> HandleAsync();
}

public interface IPostEndpoint<TRequest, TResponse> : IHttpEndpoint<TRequest, TResponse>
{
    ValueTask<IApplicationResult<TResponse>> HandleAsync(TRequest request);
}

public interface IPostEndpoint<TResponse> : IHttpEndpoint<TResponse>
{
    ValueTask<IApplicationResult<TResponse>> HandleAsync();
}

