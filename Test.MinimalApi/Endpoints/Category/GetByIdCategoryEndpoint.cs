using Test.Core.Handlers;
using Test.Core.Requests.Categories;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Category;

public class GetByIdCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: Get By Id")
            .WithSummary("Carrega uma categoria")
            .WithDescription("Carrega uma categoria")
            .WithOrder(4)
            .Produces<Response<Core.Models.Category>>();
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
    {
        var request = new GetByIdCategoryRequest
        {
            Id = id,
            UserId = "alyson@gmail.com"
        };
        
        var result = await handler.GetByIdCategoryAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}