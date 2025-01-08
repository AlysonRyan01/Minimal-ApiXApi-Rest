using Test.Core.Handlers;
using Test.Core.Requests.Categories;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Category;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Remove uma categoria")
            .WithDescription("Remove uma categoria")
            .WithOrder(2)
            .Produces<Response<Core.Models.Category>>();
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
    {
        var request = new DeleteCategoryRequest
        {
            Id = id,
            UserId = "alyson@gmail.com"
        };
        var result = await handler.DeleteCategoryAsync(request);
        
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}