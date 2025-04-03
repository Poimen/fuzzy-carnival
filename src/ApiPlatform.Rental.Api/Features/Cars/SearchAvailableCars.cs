using ApiPlatform.Kernel.Core.Endpoints;
using ApiPlatform.Kernel.Core.Results;
using ApiPlatform.Rental.Api.Constants;

namespace ApiPlatform.Rental.Api.Features.Cars;

public record AvailableCarsResponse;

public class SearchAvailableCars : IGetEndpoint<AvailableCarsResponse>
{
    public string Endpoint => $"${ApiConstant.ApiBaseUrl}/cars";

    public ValueTask<IApplicationResult<AvailableCarsResponse>> HandleAsync()
    {
        throw new NotImplementedException();
    }
}
