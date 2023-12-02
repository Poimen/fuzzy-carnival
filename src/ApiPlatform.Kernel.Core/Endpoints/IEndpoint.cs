using Microsoft.AspNetCore.Mvc;

namespace ApiPlatform.Kernel.Core.Endpoints;

public interface IRequest;

public interface IResponse;

public interface IEndpoint;

public interface IEndpoint<TResponse>;

public interface IEndpoint<TRequest, TResponse>;



