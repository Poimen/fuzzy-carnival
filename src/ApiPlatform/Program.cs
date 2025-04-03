using ApiPlatform.Controllers;
using ApiPlatform.Kernel.Core.Bootstrap;
using ApiPlatform.Kernel.Core.Endpoints;
using ApiPlatform.Kernel.Core.Extensions;
using ApiPlatform.Kernel.Core.Results;
using ApiPlatform.Rental.Api;
using ApiPlatform.Rental.Api.Features.Bookings;
using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using System.Reflection;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

//var r = NoContentApplicationResult.Success();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.AllowEmptyInputInBodyModelBinding = false;
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInstaller<RentalApiInstaller>();
builder.Services.AddHttpEndpoints();

builder.Services.AddProblemDetails();

builder.Services.AddFastEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();


app.MapControllers();

app.MapGet("/", () => "");

var postw = new PostWrapper2<CreateBooking, CreateBookingRequest, CreateBookResponse>();

var createBooking = new CreateBooking();
app.MapPost("/", postw.HandlePost)
    .AddEndpointFilterFactory((filterFactoryContext, next) => 
    {
        var parameters = filterFactoryContext.MethodInfo.GetParameters();

        //var request = parameters[1].ParameterType.ImplementsInterface<IPostEndpoint>();
        //var request = parameters.FirstOrDefault(x => !x.ParameterType.IsImplementationOf(typeof (IPostEndpoint<,>)));
        
        var request = parameters.FirstOrDefault(x => !x.ParameterType.IsImplementationOf<IHttpEndpoint>());

        //var rt = request.GetType();
        //var tt = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(p => (p.PropertyType, p.Name));

        var requiredParameters = request.ParameterType.GetProperties().Where(p => Nullable.GetUnderlyingType(p.PropertyType) == null);

        return async invocationContext =>
        {
            var context = invocationContext.HttpContext;
            var jsonBody = invocationContext.Arguments[0] as JsonElement?;
            var jsonObject = invocationContext.Arguments[2];
            var jsonProps = jsonObject.GetType().GetProperties().ToDictionary(k => k.Name);

            var requiredFieldsNotNull = requiredParameters.Where(rp =>
            {
                var hasKey = jsonProps.TryGetValue(rp.Name, out var jsonProp);

                if (!hasKey)
                {
                    return true;
                }

                return jsonProp.GetValue(jsonObject, null) == null;
            }).ToList();

            if (requiredFieldsNotNull.Count > 0)
            {
                var res = requiredFieldsNotNull.ToDictionary(k => k.Name, v => new[] { $"The {v.Name} field is required." });
                return TypedResults.ValidationProblem(requiredFieldsNotNull.ToDictionary(k => k.Name, v => new[] { $"The {v.Name} field is required." }));
            }

            return await next(invocationContext);
        };
    });

//app.MapPost("/help", async (CreateBookingRequest request) => 
//{
//    var result = await createBooking.HandleAsync(request);

//    if (result.Result.IsSome)
//    {
//        return TypedResults.Ok(result.Result);
//    }

//    return TypedResults.UnprocessableEntity();
//});

//app.MapGet("/weatherOrNot", );

app.MapEndpoints();

app.UseApiInstallers();

app.Run();
