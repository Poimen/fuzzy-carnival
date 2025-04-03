using ApiPlatform.Kernel.Core.Endpoints;
using ApiPlatform.Rental.Api.Features.Locations;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiPlatform.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class WeatherForecastController : ControllerBase
//{
//    private static readonly string[] Summaries = new[]
//    {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//    private readonly ILogger<WeatherForecastController> _logger;

//    public WeatherForecastController(ILogger<WeatherForecastController> logger)
//    {
//        _logger = logger;
//    }

//    [HttpGet(Name = "GetWeatherForecast")]
//    public IEnumerable<WeatherForecast> Get()
//    {
//        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        {
//            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            TemperatureC = Random.Shared.Next(-20, 55),
//            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//        })
//        .ToArray();
//    }
//}

public class Get : EndpointBaseSync.WithoutRequest.WithActionResult<IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = [ "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" ];

    private readonly ILogger<Get> _logger;

    public Get(ILogger<Get> logger)
    {
        _logger = logger;
    }

    [HttpGet("/WeatherForecast")]
    public override ActionResult<IEnumerable<WeatherForecast>> Handle()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }
}

public class Req
{
    public string Name { get; init; }

    public int ProductId { get; init; }
}

public class WeatherPost : EndpointBaseSync.WithRequest<Req>.WithActionResult<WeatherForecast>
{
    private readonly ILogger<Get> _logger;

    public WeatherPost(ILogger<Get> logger)
    {
        _logger = logger;
    }

    [HttpPost("/WeatherForecast")]
    public override ActionResult<WeatherForecast> Handle(Req req)
    {
        return new WeatherForecast();
    }

}

public class MyFastEndpointTester : FastEndpoints.Endpoint<Req, WeatherForecast>
{
    public override void Configure()
    {
        Post("/FastWeather");
        AllowAnonymous();
    }

    public override Task HandleAsync(Req req, CancellationToken ct)
    {
        return Task.FromResult(new WeatherForecast());
    }
}

public record PostReq(string Name);

public class PostWrapper<T>
{
    public Results<Ok<T>, NoContent, BadRequest, NotFound> HandlePost(T req, GetLocations getLoc)
    {
        return TypedResults.Ok(req);
    }
}

public class PostWrapper2<TEndpoint, TRequest, TResponse>
    where TEndpoint : IPostEndpoint<TRequest, TResponse>
{
    public async Task<Results<Ok<TResponse>, NoContent, BadRequest, NotFound, ValidationProblem>> HandlePost(TEndpoint service, TRequest request)
    {
        return TypedResults.ValidationProblem(new Dictionary<string, string[]> { { "Name", ["The Name field is required."] } });

        //var result = await service.HandleAsync(request);

        //if (result is null)
        //{
        //    throw new Exception("Internal Server Error");
        //}

        //return TypedResults.Ok<TResponse>(result.Result);
    }
}


