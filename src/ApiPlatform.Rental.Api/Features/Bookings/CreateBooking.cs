using ApiPlatform.Kernel.Core.Endpoints;
using ApiPlatform.Kernel.Core.Results;
using ApiPlatform.Rental.Api.Constants;

namespace ApiPlatform.Rental.Api.Features.Bookings;

public class CreateBookingRequest
{
    public string Name { get; init; }
    
    public int ProductId { get; init; }
    
    public int SectionId { get; init; }
}

public record CreateBookResponse();

public class CreateBooking : IPostEndpoint<CreateBookingRequest, CreateBookResponse>, IPostEndpoint
{
    public string Endpoint => $"${ApiConstant.ApiBaseUrl}/bookings";

    public ValueTask<IApplicationResult<CreateBookResponse>> HandleAsync(CreateBookingRequest request)
    {
        //throw new NotImplementedException();
        return ValueTask.FromResult(ApplicationResult.Success(new CreateBookResponse()));
    }

    public ValueTask<IApplicationResult> HandleAsync()
    {
        throw new NotImplementedException();
        //return NoContentApplicationResult.Success();
    }
}
