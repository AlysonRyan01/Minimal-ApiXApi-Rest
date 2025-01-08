using Test.Core.Handlers;
using Test.Core.Requests.Categories;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Category;

public class GetAllCategoriesEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Carrega todas as categorias")
            .WithDescription("Carrega todas as categorias")
            .WithOrder(5)
            .Produces<Response<Core.Models.Category>>();
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = "alyson@gmail.com"
        };
        
        var result = await handler.GetAllCategoriesAsync(request);
        
        return result.IsSuccess ? Results.Ok(result) : Results.NotFound();
    }
}