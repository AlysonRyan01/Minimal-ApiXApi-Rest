using System.ComponentModel.DataAnnotations;

namespace Test.Core.Requests.Categories;

public class GetByIdCategoryRequest : BaseRequest
{
    [Required(ErrorMessage = "CategoryId is required")]
    public long Id { get; set; }
}