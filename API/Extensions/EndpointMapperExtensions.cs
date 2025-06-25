using API.Endpoints;

namespace API.Extensions;

public static class EndpointMapperExtensions
{
    public static void MapAllEndpoints(this WebApplication app)
    {
        app.MapProductEndpoints();
        app.MapClientEndpoints();
        app.MapOrderEndpoint();
    }
}
