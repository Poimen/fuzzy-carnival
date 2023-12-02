using Microsoft.AspNetCore.Mvc;

namespace ApiPlatform.Kernel.Core.Endpoints;

public interface IPostEndpoint : IEndpoint
{
    ActionResult HandlePost();
}

public interface IPostEndpoint<TRequest, TResponse> : IEndpoint<TRequest, TResponse>
{
    ActionResult<TResponse> HandlePost(TRequest request);
}

public interface IPostEndpoint<TResponse> : IEndpoint<TResponse>
{
    ActionResult<TResponse> HandlePost();
}

