using Test.Core.Handlers;
using Test.Core.Requests.Categories;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Category;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("Cria uma nova categoria")
            .WithOrder(1)
            .Produces<Response<Core.Models.Category>>();
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryRequest request)
    {
        request.UserId = "alyson@gmail.com";
        var result = await handler.UpdateCategoryAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}