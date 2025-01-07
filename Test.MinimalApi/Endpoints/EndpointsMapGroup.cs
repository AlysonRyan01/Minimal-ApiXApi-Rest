namespace Test.MinimalApi.Endpoints;

public static class EndpointsMapGroup
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}