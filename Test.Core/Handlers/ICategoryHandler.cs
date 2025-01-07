using Test.Core.Models;
using Test.Core.Requests.Categories;
using Test.Core.Responses;

namespace Test.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category?>> PostCategoryAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateCategoryAsync(UpdateCategoryRequest request);
    Task<Response<Category?>> DeleteCategoryAsync(DeleteCategoryRequest request);
    Task<Response<Category?>> GetByIdCategoryAsync(GetByIdCategoryRequest request);
    Task<Response<List<Category>?>> GetAllCategoriesAsync(GetAllCategoriesRequest request);
}