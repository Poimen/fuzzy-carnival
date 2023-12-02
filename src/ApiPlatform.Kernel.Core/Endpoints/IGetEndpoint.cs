using Microsoft.AspNetCore.Mvc;

namespace ApiPlatform.Kernel.Core.Endpoints;

public interface IGetEndpoint : IEndpoint
{
    ActionResult HandleGet();
}

public interface IGetEndpoint<TRequest, TResponse> : IEndpoint<TRequest, TResponse>
{
    ActionResult<TResponse> HandleGet(TRequest request);
}

public interface IGetEndpoint<TResponse> : IEndpoint<TResponse>
{
    ActionResult<TResponse> HandleGet();
}

