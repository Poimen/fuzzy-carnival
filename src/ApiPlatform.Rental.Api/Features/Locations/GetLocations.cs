using ApiPlatform.Kernel.Core.Endpoints;
using ApiPlatform.Kernel.Core.Results;
using ApiPlatform.Rental.Api.Constants;

namespace ApiPlatform.Rental.Api.Features.Locations;

public record LocationsResponse;

public class GetLocations : IGetEndpoint<LocationsResponse>
{
    public string Endpoint => $"${ApiConstant.ApiBaseUrl}/locations";

    public ValueTask<IApplicationResult<LocationsResponse>> HandleAsync()
    {
        throw new NotImplementedException();
    }
}
