using ApiPlatform.Kernel.Core.Results;

namespace ApiPlatform.Kernel.Core.Endpoints;

public interface IGetEndpoint<TRequest, TResponse> : IHttpEndpoint<TRequest, TResponse>
{
    ValueTask<IApplicationResult<TResponse>> HandleAsync(TRequest request);
}

public interface IGetEndpoint<TResponse> : IHttpEndpoint<TResponse>
{
    ValueTask<IApplicationResult<TResponse>> HandleAsync();
}
