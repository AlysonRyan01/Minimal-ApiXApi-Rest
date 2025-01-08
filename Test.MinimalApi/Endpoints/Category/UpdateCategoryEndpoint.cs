using Test.Core.Handlers;
using Test.Core.Requests.Categories;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Category;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Atualiza uma categoria")
            .WithDescription("Atualiza uma categoria")
            .WithOrder(3)
            .Produces<Response<Core.Models.Category>>();
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryRequest request, long id)
    {
        request.UserId = "alyson@gmail.com";
        request.Id = id;
        
        var result = await handler.UpdateCategoryAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}